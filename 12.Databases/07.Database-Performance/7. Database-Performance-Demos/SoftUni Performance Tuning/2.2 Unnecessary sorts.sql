/*============================================================================
	File:		2.2 Unneccessary sorts.sql

	Summary:	The script demonstrates the performance difference between
				having an Order by clause and not needing it. 

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

-- Include Actual Execution Plan
SET STATISTICS IO ON;

SELECT  [charge_no], [member_no], [provider_no], [category_no],
		[charge_dt], [charge_amt], [statement_no], [charge_code]
FROM    [dbo].[charge]
WHERE   [charge_dt] >= '1999-09-09 10:43:38.333'
ORDER BY [category_no];  -- Do you really need this sorted?


-- If not...
SELECT  [charge_no], [member_no], [provider_no], [category_no],
		[charge_dt], [charge_amt], [statement_no], [charge_code]
FROM    [dbo].[charge]
WHERE   [charge_dt] >= '1999-09-09 10:43:38.333';

SET STATISTICS IO OFF;

-- Takeaway:
-- Ask if ORDER BY is truly being used (you will be surprised
-- how often it isn't)