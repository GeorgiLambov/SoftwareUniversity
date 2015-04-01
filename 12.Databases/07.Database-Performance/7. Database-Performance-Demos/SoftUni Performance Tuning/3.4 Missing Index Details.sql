/*============================================================================
	File:		3.4 - Missing Index Details.sql

	Summary:	The script demonstrates how SQL Server would offer an index
				suggestion based on the query that was run and how it can be
				later on impelemtend.

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

--Include the actual execution plan
--See Missing Index Details
SELECT FirstName
FROM Person.Person
WHERE FirstName like 'S%'
GO


USE [AdventureWorks2012]
GO

/****** Object:  Index [NBU_INDEX]    Script Date: 2/15/2015 5:30:39 PM ******/
DROP INDEX [NBU_INDEX] ON [Person].[Person]
GO

/****** Object:  Index [NBU_INDEX]    Script Date: 2/15/2015 5:30:39 PM ******/
CREATE NONCLUSTERED INDEX [NBU_INDEX] ON [Person].[Person]
(
	[FirstName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

