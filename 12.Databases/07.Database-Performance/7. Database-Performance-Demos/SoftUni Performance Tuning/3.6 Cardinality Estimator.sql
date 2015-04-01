/*============================================================================
	File:		3.6 - Cardinality Estimator.sql

	Summary:	The script demonstrates what performance impact the new
				cardinality estimator in SQL Server 2014 can have.

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
============================================================================*/--- Now we talk about problems

-- New CE
-- Estimated rows = 58,949,200 
-- Actual rows = 70,470,090
-- Only show Estimated Execution Plan

DBCC DROPCLEANBUFFERS
USE AdventureWorksDW2012
GO 

SELECT [fs].[ProductKey]
	,[fs].[OrderDateKey]
	,[fs].[DueDateKey]
	,[fs].[ShipDateKey]
	,[fc].[DateKey]
	,[fc].[AverageRate]
	,[fc].[EndOfDayRate]
	,[fc].[Date]
FROM dbo.[FactResellerSales] AS [fs]
INNER JOIN dbo.[FactCurrencyRate] AS [fc] ON [fs].[CurrencyKey] = [fc].[CurrencyKey]
-- OPTION  (QUERYTRACEON 2312);
OPTION (QUERYTRACEON 9481)


--- Rollback
USE [master];
GO

-- SQL Server 2014 compatibility level
ALTER DATABASE [AdventureWorks2012] SET COMPATIBILITY_LEVEL = 110;
GO
