/*============================================================================
	File:		1.3 MAXDOP and Cost Threshold for Parallelism.sql

	Summary:	The script demonstrates the performance difference between
				utilizing more than one core for the execution of query. It 
				also shows how to find the cost of a query and how to configure
				the cost threshold for parallelism instance option in order
				to make sure that the appropriate queries are being parallelized.

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

-- Turn on Actual Execution Plan
-- Forcing a parallel execution
-- Observe the execution plan

USE AdventureWorks2012
GO

SELECT sod.SalesOrderID, sod.OrderQty, 
        p.ProductID, p.Name
    FROM Production.Product p
        INNER MERGE JOIN Sales.SalesOrderDetail sod
            ON sod.ProductID = p.ProductID   

-- Check the query cost

SELECT sod.SalesOrderID, sod.OrderQty, 
        p.ProductID, p.Name
    FROM Production.Product p
        INNER MERGE JOIN Sales.SalesOrderDetail sod
            ON sod.ProductID = p.ProductID    
    OPTION (MAXDOP 1)

-- Cost:

-- Run the parallel execution again and compare the cost

-- Cost: 

-- See the actual rows and how they are spread accross the threads

-- Raise the cost threshold for parallelism and run the parallel plan again

EXEC sys.sp_configure N'cost threshold for parallelism', N'11'
GO
RECONFIGURE WITH OVERRIDE
GO


-- Script to find any query that run in parallel (searching the plan cache)

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; 

WITH XMLNAMESPACES   
   (DEFAULT 'http://schemas.microsoft.com/sqlserver/2004/07/showplan')  
SELECT  
        query_plan AS CompleteQueryPlan, 
        n.value('(@StatementText)[1]', 'VARCHAR(4000)') AS StatementText, 
        n.value('(@StatementOptmLevel)[1]', 'VARCHAR(25)') AS StatementOptimizationLevel, 
        n.value('(@StatementSubTreeCost)[1]', 'VARCHAR(128)') AS StatementSubTreeCost, 
        n.query('.') AS ParallelSubTreeXML,  
        ecp.usecounts, 
        ecp.size_in_bytes 
FROM sys.dm_exec_cached_plans AS ecp 
CROSS APPLY sys.dm_exec_query_plan(plan_handle) AS eqp 
CROSS APPLY query_plan.nodes('/ShowPlanXML/BatchSequence/Batch/Statements/StmtSimple') AS qn(n) 
WHERE  n.query('.').exist('//RelOp[@PhysicalOp="Parallelism"]') = 1 



-- Rollback:

EXEC sys.sp_configure N'cost threshold for parallelism', N'5'
GO
RECONFIGURE WITH OVERRIDE
GO