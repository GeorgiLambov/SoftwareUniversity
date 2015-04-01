/*============================================================================
	File:		3.8 - Statistics.sql

	Summary:	The script demonstrates the Ascending Key problem that is
				caused by table statistics not being updated. It also shows
				how to update the stats.

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



USE [AdventureWorks2012];
GO

SELECT [SalesOrderID], [OrderDate] 
FROM Sales.[SalesOrderHeader]
WHERE [OrderDate] = '2005-07-01 00:00:00.000';

SELECT  [s].[object_id],
        [s].[name],
        [s].[auto_created]
FROM    sys.[stats] AS s
INNER JOIN sys.[stats_columns] AS [sc]
        ON [s].[stats_id] = [sc].[stats_id] AND
           [s].[object_id] = [sc].[object_id]
WHERE   [s].[object_id] = OBJECT_ID('Sales.SalesOrderHeader') AND
	    COL_NAME([s].[object_id], [sc].[column_id]) = 'OrderDate';


DBCC SHOW_STATISTICS('Sales.SalesOrderHeader', _WA_Sys_00000003_4B7734FF);


INSERT  INTO Sales.[SalesOrderHeader] ( [RevisionNumber], [OrderDate],
                                          [DueDate], [ShipDate], [Status],
                                          [OnlineOrderFlag],
                                          [PurchaseOrderNumber],
                                          [AccountNumber], [CustomerID],
                                          [SalesPersonID], [TerritoryID],
                                          [BillToAddressID], [ShipToAddressID],
                                          [ShipMethodID], [CreditCardID],
                                          [CreditCardApprovalCode],
                                          [CurrencyRateID], [SubTotal],
                                          [TaxAmt], [Freight], [Comment] )
VALUES  ( 3, '2014-02-02 00:00:00.000', '5/1/2014', '4/1/2014', 5, 0, 'SO43659', 'PO522145787',29825, 279, 5, 985, 985, 5, 21, 'Vi84182', NULL, 250.00,
25.00, 10.00, '' );
GO 20 -- INSERT 20 rows, representing very recent data, with a current OrderDate value

-- If the cardinality for a table is greater than 500, update statistics when (500 + 20 percent of the table) changes have occurred.

-- Run with the old CE then comment out the traceflag 
SELECT [SalesOrderID], [OrderDate] 
FROM Sales.[SalesOrderHeader]
WHERE [OrderDate] = '2014-02-02 00:00:00.000'

--let's update the stats!
USE AdventureWorks2012;
GO
UPDATE STATISTICS Sales.SalesOrderHeader _WA_Sys_00000003_4B7734FF
WITH FULLSCAN ;
GO



