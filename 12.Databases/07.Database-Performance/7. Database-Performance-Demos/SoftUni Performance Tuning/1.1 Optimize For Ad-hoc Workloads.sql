/*============================================================================
	File:		1.1 - Optimize for Ad-hoc workload.sql

	Summary:	The script demonstrates how and what is the effect for turning
				on the option "Optimize for Ad-hoc Workloads" on a SQL Server
				instance.

				THIS SCRIPT IS PART OF THE Lecture: 
				"Performance Tuning" for SoftUni, Sofia

	Date:		February 2015

	SQL Server Version: 2008 / 2012 / 2014
------------------------------------------------------------------------------
	Written by Boris Hristov, SQL Server MVP

	This script is intended only as a supplement to demos and lectures
	given by Boris Hristov.  
  
	THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF 
	ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED 
	TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
	PARTICULAR PURPOSE.
============================================================================*/

--What do we have in the plan cache?
SELECT objtype AS [CacheType]
        , count_big(*) AS [Total Plans]
        , sum(cast(size_in_bytes as decimal(18,2)))/1024/1024 AS [Total MBs]
        , avg(usecounts) AS [Avg Use Count]
        , sum(cast((CASE WHEN usecounts = 1 THEN size_in_bytes ELSE 0 END) as decimal(18,2)))/1024/1024 AS [Total MBs - USE Count 1]
        , sum(CASE WHEN usecounts = 1 THEN 1 ELSE 0 END) AS [Total Plans - USE Count 1]
FROM sys.dm_exec_cached_plans
GROUP BY objtype
ORDER BY [Total MBs - USE Count 1] DESC
GO


--Let's see the caching now
--Clean Cache and Buffers
DBCC FREEPROCCACHE
DBCC DROPCLEANBUFFERS
GO
USE AdventureWorks2012
GO
-- Run Adhoc Query First Time
SELECT * FROM HumanResources.Shift
GO
/* Check if Adhoc query is cached.
It will return one result */
SELECT usecounts, cacheobjtype, objtype, text 
FROM sys.dm_exec_cached_plans 
CROSS APPLY sys.dm_exec_sql_text(plan_handle) 
WHERE usecounts > 0 AND 
			text like '%SELECT * FROM HumanResources.Shift%'
ORDER BY usecounts DESC;
GO


/* Enabling Advance Option */
    SP_CONFIGURE 'show advanced options',1
    RECONFIGURE
    GO
/* Enabling Advance Workload Option */
    SP_CONFIGURE 'optimize for ad hoc workloads',1
    RECONFIGURE
    GO

--Let's see the difference. Execute once and check the cache.
DBCC FREEPROCCACHE
DBCC DROPCLEANBUFFERS
GO

SELECT * FROM HumanResources.Shift

SELECT usecounts, cacheobjtype, objtype, text 
FROM sys.dm_exec_cached_plans 
CROSS APPLY sys.dm_exec_sql_text(plan_handle) 
WHERE usecounts > 0 AND 
		text like '%SELECT * FROM HumanResources.Shift%'
ORDER BY usecounts DESC;
GO

--Run it again and check the cache

--Rollback

SP_CONFIGURE 'show advanced options',1
RECONFIGURE
GO
SP_CONFIGURE 'optimize for ad hoc workloads',0
RECONFIGURE
GO
