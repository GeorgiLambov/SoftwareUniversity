/*============================================================================
	File:		3.1 - Bookmark Lookup.sql

	Summary:	The script demonstrates the concept of Covering Indexes and 
				how to mitigate the so called "Bookmark Operator" problem.

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


USE AdventureWorks2012
GO
-- CTRL + M 
-- Enforces Key Lookup
-- Step 0
SELECT NationalIDNumber, HireDate, MaritalStatus
FROM HumanResources.Employee
WHERE NationalIDNumber = 14417807
GO
-- Create Non clustered Index
CREATE NONCLUSTERED INDEX [IX_HumanResources_Employee_Example]
		 ON HumanResources.Employee 
(
	NationalIDNumber ASC, HireDate, MaritalStatus 
) ON [PRIMARY]
GO

-- Removes Key Lookup, but it still enforces Index Scan
-- Step 1
SELECT NationalIDNumber, HireDate, MaritalStatus
FROM HumanResources.Employee
WHERE NationalIDNumber = 14417807
GO

-- Removes Key Lookup and it enforces Index Seek
-- Step 2
SELECT NationalIDNumber, HireDate, MaritalStatus
FROM HumanResources.Employee
WHERE NationalIDNumber = '14417807'
GO

/* Removes Key Lookup and it enforces Index Seek 
	and no CONVERT_IMPLICIT */
-- Step 3
SELECT NationalIDNumber, HireDate, MaritalStatus
FROM HumanResources.Employee
WHERE NationalIDNumber = N'14417807'
GO
-- Clean up
-- Drop Index
DROP INDEX [IX_HumanResources_Employee_Example] 
			ON HumanResources.Employee  WITH ( ONLINE = OFF )
GO