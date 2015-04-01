/*============================================================================
	File:		2.5 Leading %.sql

	Summary:	The script demonstrates how querying a column and starting with 
				% for the filter can dramatically decrease the performance of
				the query by actually using a scan operator instead of seek.

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

EXEC sp_helpindex 'dbo.member';
GO

CREATE INDEX [IX_member_lastname] 
ON [dbo].[member] ([lastname])
INCLUDE ([firstname], [middleinitial], [street]);
GO

-- Include actual plan
-- Is our index used?
SELECT  [member_no], [firstname], [middleinitial], [street]
FROM [dbo].[member]
WHERE [lastname] = 'CHEN';

-- What about this?
SELECT  [member_no], [lastname], [firstname], [middleinitial],
	[street]
FROM [dbo].[member]
WHERE [lastname] LIKE 'CHEN%';

-- And this?
SELECT  [member_no], [lastname], [firstname], [middleinitial],
	[street]
FROM [dbo].[member]
WHERE [lastname] LIKE '%CHEN%';

-- Takeaway:
-- Big tables, coupled with leading wildcards means you'll be
-- scanning (index or heap).

-- If you can re-write without the leading wildcard, great,
-- otherwise you might need to consider other methods like
-- Full Text Search (FTS).

-- Rollback:


DROP INDEX dbo.member.[IX_member_lastname]