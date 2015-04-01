/*============================================================================
	File:		2.1 SELECT *.sql

	Summary:	The script demonstrates the bad select * pratice and what
				an impact it can have on the performance of the application.

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

-- Do you need all columns?
SELECT  *
FROM    [dbo].[charge]
WHERE   [statement_no] = 18408;

-- What if all you just needed the charge_no?
SELECT  [charge_no]
FROM    [dbo].[charge]
WHERE   [statement_no] = 18408;

-- Additional columns?
SELECT  [charge_no], [charge_amt]
FROM    [dbo].[charge]
WHERE   [statement_no] = 18408;

-- Takeaway:
-- Only retrieve columns you will actually need and use
-- That's also true because of SELECT * can brake your app (new column)

