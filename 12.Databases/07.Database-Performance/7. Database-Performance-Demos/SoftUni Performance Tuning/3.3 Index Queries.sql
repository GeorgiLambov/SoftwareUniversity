/*============================================================================
	File:		3.3 - Diagnostic Index Queries.sql

	Summary:	The script helps diagnose issues within the indexes of the 
				database/tables.

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

--Fragmentation of all indexes
SELECT OBJECT_NAME(dt.object_id), si.name,
dt.avg_fragmentation_in_percent,
dt.avg_page_space_used_in_percent
FROM
(SELECT object_id, index_id, avg_fragmentation_in_percent, avg_page_space_used_in_percent
FROM sys.dm_db_index_physical_stats (DB_ID(6), NULL, NULL, NULL, 'DETAILED')
WHERE index_id <> 0) as dt --does not return information about heaps
INNER JOIN sys.indexes si
ON si.object_id = dt.object_id
AND si.index_id = dt.index_id
ORDER BY dt.avg_fragmentation_in_percent DESC


--Unused indexes?
SELECT  OBJECT_NAME(i.[object_id]) AS [Table Name] ,
        i.name
FROM    sys.indexes AS i
        INNER JOIN sys.objects AS o ON i.[object_id] = o.[object_id]
WHERE   i.index_id NOT IN ( SELECT  s.index_id
                            FROM    sys.dm_db_index_usage_stats AS s
                            WHERE   s.[object_id] = i.[object_id]
                                    AND i.index_id = s.index_id
                                    AND database_id = DB_ID() )
        AND o.[type] = 'U'
ORDER BY OBJECT_NAME(i.[object_id]) ASC ;

-- Possible Bad NC Indexes (writes > reads)
SELECT  OBJECT_NAME(s.[object_id]) AS [Table Name] ,
        i.name AS [Index Name] ,
        i.index_id ,
        user_updates AS [Total Writes] ,
        user_seeks + user_scans + user_lookups AS [Total Reads] ,
        user_updates - ( user_seeks + user_scans + user_lookups )
            AS [Difference]
FROM    sys.dm_db_index_usage_stats AS s WITH ( NOLOCK )
        INNER JOIN sys.indexes AS i WITH ( NOLOCK )
            ON s.[object_id] = i.[object_id]
            AND i.index_id = s.index_id
WHERE   OBJECTPROPERTY(s.[object_id], 'IsUserTable') = 1
        AND s.database_id = DB_ID()
        AND user_updates > ( user_seeks + user_scans + user_lookups )
        AND i.index_id > 1
ORDER BY [Difference] DESC ,
        [Total Writes] DESC ,
        [Total Reads] ASC ;


--Disabled indexes
USE TSQL2012
GO
SELECT name ,
index_id ,
type ,
type_desc ,
is_disabled
FROM sys.indexes
WHERE object_id = OBJECT_ID('dbo.Products')
