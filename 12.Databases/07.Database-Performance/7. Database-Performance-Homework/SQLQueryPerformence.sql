USE master
GO

CREATE DATABASE PerformanceDB
GO

USE PerformanceDB
GO

-- 1.Create a table in SQL Server with 10 000 000 entries (date + text). 
-- Search in the table by date range. Check the speed (without caching).

CREATE TABLE PerformanceLogs(
  Id int NOT NULL PRIMARY KEY IDENTITY,
  [Text] varchar(100) NOT NULL,
  [Date] datetime NOT NULL
)

INSERT INTO PerformanceLogs ([Text], [Date])
	VALUES ('Sample Text', '2001-01-01 00:00:00.000')
GO

DECLARE @Counter int = 0
WHILE ( SELECT 	COUNT(*) FROM PerformanceLogs) < 1000000
 BEGIN
	INSERT INTO PerformanceLogs ([Text], [Date])
	SELECT [Text] + Convert(NVARCHAR, @Counter), DATEADD(MONTH, @Counter + 3, [Date])
	FROM PerformanceLogs
	SET @Counter = @Counter + 1;
 END

 CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

 SELECT [Text], [Date] FROM PerformanceLogs
 WHERE [Date] BETWEEN '2002-01-01 00:00:00.000' AND '2020-01-01 00:00:00.000';

 -- 2.Add an index to speed-up the search by date.
 -- Test the search speed (after cleaning the cache).
 
 CREATE INDEX IDX_PerformanceLogs_LogsDates ON PerformanceLogs([Date])

 CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
 
  SELECT [Text], [Date] FROM PerformanceLogs
 WHERE [Date] BETWEEN '2002-01-01 00:00:00.000' AND '2030-01-01 00:00:00.000';