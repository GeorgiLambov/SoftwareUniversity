/*============================================================================
	File:		2.3 Needless DISTINCT.sql

	Summary:	The script demonstrates the performance difference between
				using DISTINCT and not.

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
============================================================================*/USE [Credit];
GO

-- Include actual execution plan

-- Example where WE know the data is (likely) unique, but the
-- Query Optimizer does not
SET STATISTICS IO ON;

-- Include Actual Execution Plan
SELECT  DISTINCT 
		[lastname], [firstname], [middleinitial],
		[street], [city], [state_prov]
FROM dbo.[member] AS m;

SELECT  [lastname], [firstname], [middleinitial], [street],
        [city], [state_prov]
FROM dbo.[member] AS m;

SET STATISTICS IO OFF;

-- Takeaways:
-- Use DISTINCT when it is actually needed
-- Sometimes DISTINCT is used to hide duplicates from an
-- incorrect query design