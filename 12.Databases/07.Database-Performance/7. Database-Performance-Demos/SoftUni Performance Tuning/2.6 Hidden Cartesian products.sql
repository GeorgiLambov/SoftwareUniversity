/*============================================================================
	File:		2.6 Hidden Cartesion Products.sql

	Summary:	The script demonstrates how using the old JOIN syntax(ANSI-89)
				can lead to unwanted query results.

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

-- See anything wrong about this query?
-- Let's look at the estimated plan
-- (the actual plan will take a long time!)
SELECT  [member].[member_no], [member].[lastname],
		[member].[firstname],
        [region].[region_no], [region].[region_name],
        [provider].[provider_name], [category].[category_desc],
        [charge].[charge_no], [charge].[provider_no],
		[charge].[category_no], [charge].[charge_dt],
		[charge].[charge_amt], [charge].[charge_code]
FROM    [dbo].[provider] ,
        [dbo].[member] ,
        [dbo].[region] ,
        [dbo].[category] ,
        [dbo].[charge]
WHERE   [member].[member_no] = [charge].[member_no]
        AND [region].[region_no] = [member].[region_no]
        AND [category].[category_no] = [charge].[category_no];
GO

-- And the estimated plan for this one?
SELECT  [m].[member_no], [m].[lastname], [m].[firstname],
		[r].[region_no], [r].[region_name], [p].[provider_name],
		[ca].[category_desc], [c].[charge_no], [c].[provider_no],
		[c].[category_no], [c].[charge_dt],
        [c].[charge_amt], [c].[charge_code]
FROM    [dbo].[provider] AS [p]
        INNER JOIN [dbo].[charge] AS [c]
			ON [p].[provider_no] = [c].[provider_no]
        INNER JOIN [dbo].[member] AS [m]
			ON [m].[member_no] = [c].[member_no]
        INNER JOIN [dbo].[region] AS [r]
			ON [r].[region_no] = [m].[region_no]
        INNER JOIN [dbo].[category] AS [ca]
			ON [c].[category_no] = [ca].[category_no];
GO

-- Takeaway:
--	The old-style WHERE clause join conditions - while often
--	result in identical plans, is a bit too error prone (easy
--  to miss unjoined tables).  
--	Use FROM / JOIN and join conditions.