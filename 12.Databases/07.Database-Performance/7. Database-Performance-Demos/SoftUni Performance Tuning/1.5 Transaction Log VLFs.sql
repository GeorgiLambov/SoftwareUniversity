/*============================================================================
	File:		1.5 Transaction Log VLFs.sql

	Summary:	The script demonstrates the performance boost coming from
				correctly presizing a database and its transaction log.

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

---- RUN AS ONE BATCH! 
USE master
GO

-- Create a database
CREATE DATABASE ns_lots_of_vlfs
GO

ALTER DATABASE ns_lots_of_vlfs SET recovery FULL
GO

-- Alter the transaction log to be 1mb and grow with 1mb step
ALTER DATABASE ns_lots_of_vlfs 
modify FILE (name=ns_lots_of_vlfs_log, size=1 mb, filegrowth=1mb)
GO

---- RUN AS ONE BATCH!

-- only three VLF's to start
BACKUP DATABASE ns_lots_of_vlfs 
TO DISK = 'E:\2012\ns_lots_of_vlfs_full.bak'
GO

-- Check the number of VLFs
DBCC loginfo('ns_lots_of_vlfs')
GO

-- Insert sample data
USE ns_lots_of_vlfs
GO

CREATE TABLE grow_quick (
id bigint NOT NULL IDENTITY(1,1),
fn NVARCHAR(255),
ln NVARCHAR(255),
aaaaaaas NVARCHAR(4000) DEFAULT (REPLICATE(N'a', 4000))
)
GO

DECLARE @i INT 
SET @i = 0

-- You may want fewer itterations
WHILE @i < 10 BEGIN

INSERT INTO grow_quick (fn, ln) 
SELECT TOP 2000 FirstName, LastName 
FROM AdventureWorks2012.Person.Person
DELETE FROM grow_quick

SET @i = @i + 1
END

-- 10 sec

DBCC loginfo('ns_lots_of_vlfs')
GO 

-- 1420 VLFs


BACKUP LOG [ns_lots_of_vlfs] TO  DISK = N'E:\2012\ns_lots_of_vlfs_full.bak' 
WITH NOFORMAT, NOINIT,  NAME = N'ns_lots_of_vlfs-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10
GO

USE [ns_lots_of_vlfs]
GO
DBCC SHRINKFILE (N'ns_lots_of_vlfs_log' , 0, TRUNCATEONLY)
GO



USE [master]
GO
ALTER DATABASE [ns_lots_of_vlfs] MODIFY FILE ( NAME = N'ns_lots_of_vlfs_log', SIZE = 1000000KB )
GO

-- 50 sec

USE ns_lots_of_vlfs
GO

TRUNCATE table grow_quick

-- insert data again
DECLARE @i INT 
SET @i = 0

WHILE @i < 10 BEGIN

INSERT INTO grow_quick (fn, ln) 
SELECT TOP 2000 FirstName, LastName 
FROM AdventureWorks2012.Person.Person
DELETE FROM grow_quick

SET @i = @i + 1
END

-- 4 seconds

-- Rollback:

DROP DATABASE ns_lots_of_vlfs
GO