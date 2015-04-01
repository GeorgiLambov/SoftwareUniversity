/*============================================================================
	File:		2.4 UNION vs UNION ALL.sql

	Summary:	The script demonstrates the performance difference betwee
				UNION and UNION ALL in cases when the data that is being
				selected is unique.

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

-- How much overlap between these two sets?
SELECT  [member_no] ,
        [lastname] ,
        [firstname] ,
        [middleinitial] ,
        [street] ,
        [city] ,
        [state_prov] ,
        [country] ,
        [mail_code] ,
        [phone_no] ,
        [issue_dt] ,
        [expr_dt] ,
        [region_no] ,
        [corp_no] ,
        [prev_balance] ,
        [curr_balance] ,
        [member_code]
FROM    [dbo].[member]
INTERSECT
SELECT  [member_no] ,
        [lastname] ,
        [firstname] ,
        [middleinitial] ,
        [street] ,
        [city] ,
        [state_prov] ,
        [country] ,
        [mail_code] ,
        [phone_no] ,
        [issue_dt] ,
        [expr_dt] ,
        [region_no] ,
        [corp_no] ,
        [prev_balance] ,
        [curr_balance] ,
        [member_code]
FROM    [dbo].[member2];

-- Considering no overlap, what if we use UNION instead of
-- UNION ALL?
SELECT  [member_no] ,
        [lastname] ,
        [firstname] ,
        [middleinitial] ,
        [street] ,
        [city] ,
        [state_prov] ,
        [country] ,
        [mail_code] ,
        [phone_no] ,
        [issue_dt] ,
        [expr_dt] ,
        [region_no] ,
        [corp_no] ,
        [prev_balance] ,
        [curr_balance] ,
        [member_code]
FROM    [dbo].[member]
UNION
SELECT  [member_no] ,
        [lastname] ,
        [firstname] ,
        [middleinitial] ,
        [street] ,
        [city] ,
        [state_prov] ,
        [country] ,
        [mail_code] ,
        [phone_no] ,
        [issue_dt] ,
        [expr_dt] ,
        [region_no] ,
        [corp_no] ,
        [prev_balance] ,
        [curr_balance] ,
        [member_code]
FROM    [dbo].[member2];

SELECT  [member_no] ,
        [lastname] ,
        [firstname] ,
        [middleinitial] ,
        [street] ,
        [city] ,
        [state_prov] ,
        [country] ,
        [mail_code] ,
        [phone_no] ,
        [issue_dt] ,
        [expr_dt] ,
        [region_no] ,
        [corp_no] ,
        [prev_balance] ,
        [curr_balance] ,
        [member_code]
FROM    [dbo].[member]
UNION ALL
SELECT  [member_no] ,
        [lastname] ,
        [firstname] ,
        [middleinitial] ,
        [street] ,
        [city] ,
        [state_prov] ,
        [country] ,
        [mail_code] ,
        [phone_no] ,
        [issue_dt] ,
        [expr_dt] ,
        [region_no] ,
        [corp_no] ,
        [prev_balance] ,
        [curr_balance] ,
        [member_code]
FROM    [dbo].[member2];

-- Takeaway:
-- If you don't need de-duplication, UNION ALL
-- With the additional memory grants, consider concurrency

