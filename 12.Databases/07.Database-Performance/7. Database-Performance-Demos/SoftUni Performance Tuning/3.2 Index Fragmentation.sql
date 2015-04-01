/*============================================================================
	File:		3.2 - Index Fragmentation.sql

	Summary:	The script demonstrates to cause an index fragmentation, 
				how to monitor for it and how to reogranize an index.
				
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


-- TSQL Script
create database indextest
go
 
 
use indextest
go
 
 
-- create the index after loading the data
drop table t_ci
go
 
create table t_ci (c1 int, c2 char (100), c3 int, c4 varchar(1000))
go
 
 
-- load the data
declare @i int
select @i = 0
while (@i < 1000)
begin
insert into t_ci values (@i, 'hello', @i+10000, replicate ('a', 100))
set @i = @i + 1
end
 
-- find fragmentation
select avg_fragmentation_in_percent, avg_fragment_size_in_pages, fragment_count, avg_page_space_used_in_percent
from sys.dm_db_index_physical_stats (DB_ID(), object_id('t_ci'), NULL, NULL, 'DETAILED')
 
 
-- create the clustered index
create clustered index ci on t_ci(c1)
go
 
-- measure the fragementation
select avg_fragmentation_in_percent, avg_fragment_size_in_pages, fragment_count, avg_page_space_used_in_percent
from sys.dm_db_index_physical_stats (DB_ID(), object_id('t_ci'), NULL, NULL, 'DETAILED')
 
 
-- create the index and load the data. This is different from the previous example
-- as here we create the index on the empty table and then load the data.
 
drop table t_ci
go
 
create table t_ci (c1 int, c2 char (100), c3 int, c4 varchar(1000))
go
 
-- create the clustered index
create clustered index ci on t_ci(c1)
go
 
-- load the data
declare @i int
select @i = 0
while (@i < 1000)
begin
insert into t_ci values (@i, 'hello', @i+10000, replicate ('a', 100))
set @i = @i + 1
end
 
 
-- measure the fragementation
select avg_fragmentation_in_percent, avg_fragment_size_in_pages, fragment_count, avg_page_space_used_in_percent
from sys.dm_db_index_physical_stats (DB_ID(), object_id('t_ci'), NULL, NULL, 'DETAILED')

DROP index ci on t_ci
-- create the clustered index to start with unfragmented data
create clustered index ci on t_ci(c1)
go
 
-- update all rows such that each row 900 bytes. This will cause page splits thereby
-- lead to fragmentation
update t_ci set c4 = replicate ('b', 1000)
 
-- measure the fragementation
select avg_fragmentation_in_percent, avg_fragment_size_in_pages, fragment_count, avg_page_space_used_in_percent
from sys.dm_db_index_physical_stats (DB_ID(), object_id('t_ci'), NULL, NULL, 'DETAILED')
 
-- Now do an index defrag.
alter index ci on t_ci reorganize
 
-- measure the fragementation
select avg_fragmentation_in_percent, avg_fragment_size_in_pages, fragment_count, avg_page_space_used_in_percent
from sys.dm_db_index_physical_stats (DB_ID(), object_id('t_ci'), NULL, NULL, 'DETAILED')
 