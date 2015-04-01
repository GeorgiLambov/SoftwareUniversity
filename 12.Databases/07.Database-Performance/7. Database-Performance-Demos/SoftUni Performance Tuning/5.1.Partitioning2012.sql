/*============================================================================
	File:		5.1 Partitioning 2012.sql

	Summary:	The script demonstrates some of the maintenance problems that
				were present with partitioned tables in SQL Server 2012. The 
				code is used as part of a demo where the same behavior is
				compared with SQL Server 2014 where the ongoing index rebuild
				on the partitioned table actually does not bring the table 
				offline.

				THIS SCRIPT IS PART OF THE Lecture: 
				"Performance Tuning" for SoftUni, Sofia

	Date:		February 2015

	SQL Server Version: 2012, 2014
------------------------------------------------------------------------------
	Written by Boris Hristov, SQL Server MVP

	This script is intended only as a supplement to demos and lectures
	given by Boris Hristov.  
  
	THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF 
	ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED 
	TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
	PARTICULAR PURPOSE.
============================================================================*/

/* Build phase 

USE master
GO

-- Drop the database if it already exists
IF  EXISTS (
	SELECT name 
		FROM sys.databases 
		WHERE name = N'PartitioningDemo'
)
DROP DATABASE PartitioningDemo
GO

-- Create an empty database to play with

CREATE DATABASE PartitioningDemo;
GO 

USE PartitioningDemo;
GO 	

-- Create three partitions: up to 7999, 8000-15999, 16000+
CREATE PARTITION FUNCTION MyPartitionFunction (INT) AS RANGE RIGHT FOR VALUES (8000, 16000);
GO 

CREATE PARTITION SCHEME MyPartitionScheme AS PARTITION MyPartitionFunction
ALL TO ([PRIMARY]);
GO 

-- Create a partitioned table
CREATE TABLE MyPartitionedTable (c1 INT, c2 CHAR(5000));
GO 

CREATE CLUSTERED INDEX MPT_Clust 
ON MyPartitionedTable (c1)
ON MyPartitionScheme (c1);
GO 

-- Fill the table
SET NOCOUNT ON;
GO 

DECLARE @a INT = 1;
WHILE (@a < 1000000)
BEGIN
INSERT INTO MyPartitionedTable VALUES (@a, @a);
SELECT @a = @a + 1;
END;
GO

*/ 

--Connect to the 2012 (default) instance

EXEC sys.sp_configure 'show advanced options', 1
RECONFIGURE
GO

EXEC sys.sp_configure N'max server memory (MB)', N'1024'
GO
RECONFIGURE WITH OVERRIDE
GO

/* Check row count */ 

USE PartitioningDemo
GO

SELECT OBJECT_ID('[dbo].[MyPartitionedTable]') -- id: 

SELECT partition_id, partition_number, used_page_count, row_count from sys.dm_db_partition_stats
where object_id = 245575913 --- put the id here

-- select and show the partitioning properties
-- Partitioned: True
-- Actual Partition Count: 1
-- That's called Partitioning Elimination

SELECT c1, c2
FROM dbo.MyPartitionedTable
WHERE c1 > 1 AND c1 < 700 

-- Rollback

DROP DATABASE PartitioningDemo
GO