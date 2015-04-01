/*============================================================================
	File:		3.7 - Index on FK.sql

	Summary:	The script demonstrates the impact of having an index on the 
				FK column and how it affects the performance of the queries.

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

-- USE 2014! 
/* 

ALREADY DONE

USE [AdventureWorks2012];
GO
 
/* remove original clustered index */
ALTER TABLE [Sales].[SalesOrderDetailEnlarged] 
  DROP CONSTRAINT [PK_SalesOrderDetailEnlarged_SalesOrderID_SalesOrderDetailID];
GO
 
/* re-create clustered index with SalesOrderDetailID only */
ALTER TABLE [Sales].[SalesOrderDetailEnlarged] 
  ADD CONSTRAINT [PK_SalesOrderDetailEnlarged_SalesOrderDetailID] PRIMARY KEY CLUSTERED
  (
    [SalesOrderDetailID] ASC
  )
  WITH
  (
     PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, 
     IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON
  ) ON [PRIMARY];
GO
 
/* add foreign key constraint for SalesOrderID */
ALTER TABLE [Sales].[SalesOrderDetailEnlarged] WITH CHECK 
  ADD CONSTRAINT [FK_SalesOrderDetailEnlarged_SalesOrderHeaderEnlarged_SalesOrderID] 
  FOREIGN KEY([SalesOrderID])
  REFERENCES [Sales].[SalesOrderHeaderEnlarged] ([SalesOrderID])
  ON DELETE CASCADE;
GO
 
ALTER TABLE [Sales].[SalesOrderDetailEnlarged] 
  CHECK CONSTRAINT [FK_SalesOrderDetailEnlarged_SalesOrderHeaderEnlarged_SalesOrderID];
GO
*/ 
--Let's now try the performance

SET STATISTICS IO ON;
SET STATISTICS TIME ON;
 
DBCC DROPCLEANBUFFERS;
DBCC FREEPROCCACHE;
 
USE [AdventureWorks2012];
GO
 
DELETE FROM [Sales].[SalesOrderHeaderEnlarged] WHERE [SalesOrderID] = 292104;

--Hmmm... that SCAN?

USE [AdventureWorks2012];
GO
 
/* create nonclustered index */
CREATE NONCLUSTERED INDEX [IX_SalesOrderDetailEnlarged_SalesOrderID] 
ON [Sales].[SalesOrderDetailEnlarged]
(
  [SalesOrderID] ASC
)
WITH
(
  PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, 
  ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON
)
ON [PRIMARY];
 
GO

--Let's test again

SET STATISTICS IO ON;
SET STATISTICS TIME ON;
 
DBCC DROPCLEANBUFFERS;
DBCC FREEPROCCACHE;
 
USE [AdventureWorks2012];
GO
 
DELETE FROM [Sales].[SalesOrderHeaderEnlarged] WHERE [SalesOrderID] = 697505;