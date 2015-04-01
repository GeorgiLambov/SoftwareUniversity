/*============================================================================
	File:		2.7 Data type conversion.sql

	Summary:	The script demonstrates what performance issues can occur
				when there is a data mismatch.

				THIS SCRIPT IS PART OF THE Lecture: 
				"Performance Tuning" for SoftUni, Sofia

	Date:		February 2015

	SQL Server Version: 2012, 2014
------------------------------------------------------------------------------
	Written by Joe Sack, SQL Server MVP
	Modified by Boris Hristov, SQL Server MVP

	This script is intended only as a supplement to demos and lectures
	given by Boris Hristov.  
  
	THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF 
	ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED 
	TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
	PARTICULAR PURPOSE.
============================================================================*/

USE [Credit];
GO

UPDATE  [dbo].[charge]
SET     [charge_code] = N'XY'
WHERE   [charge_no] = 1342773;
GO

-- Show the schema of dbo.charge table
-- charge_code column is CHAR data type!

CREATE PROCEDURE [dbo].[Charge_Member]
    @charge_code NVARCHAR(2) 
AS
    SELECT  [m].[member_no], [c].[charge_amt]
    FROM    [dbo].[charge] AS [c]
            INNER JOIN [dbo].[member] AS [m]
			ON [m].[member_no] = [c].[member_no]
    WHERE   [c].[charge_code] = @charge_code;
GO

EXEC sp_helpindex 'dbo.charge';
GO

CREATE INDEX [IX_charge_charge_code] 
ON [dbo].[charge] ([charge_code])
INCLUDE ([charge_amt]);
GO

-- Include the plan
SET STATISTICS IO ON;

EXEC [dbo].[Charge_Member] N'XY';

SET STATISTICS IO OFF;
GO

-- And now?
ALTER PROCEDURE [dbo].[Charge_Member] @charge_code CHAR(2)
AS
    SELECT  [m].[member_no], [c].[charge_amt]
    FROM    [dbo].[charge] AS [c]
            INNER JOIN [dbo].[member] AS [m]
			ON [m].[member_no] = [c].[member_no]
    WHERE   [c].[charge_code] = @charge_code;
GO

-- Include the plan
SET STATISTICS IO ON;

EXEC [dbo].[Charge_Member] 'XY';

SET STATISTICS IO OFF;
GO


-- Takeaway:
-- Use matching data types for join and filter predicates

-- Naming conventions can help here
--	(t1.charge_code = t2.charge_code = @charge_code)

-- Rollback:

DROP PROCEDURE [dbo].[Charge_Member]
DROP INDEX dbo.charge.[IX_charge_charge_code] 