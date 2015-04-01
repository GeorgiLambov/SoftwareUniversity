/*============================================================================
	File:		3.9 - Columnstore Index.sql

	Summary:	The script demonstrates how to implement and what are the
				benefints of a nonclustered columnstore index in 2012.

				THIS SCRIPT IS PART OF THE Lecture: 
				"Performance Tuning" for SoftUni, Sofia

	Date:		February 2015

	SQL Server Version: 2012 / 2014
------------------------------------------------------------------------------
	Written by Boris Hristov, SQL Server MVP

	This script is intended only as a supplement to demos and lectures
	given by Boris Hristov.  
  
	THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF 
	ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED 
	TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
	PARTICULAR PURPOSE.
============================================================================*/
-- Use 2012 instance!

/* ALREADY DONE 

--Create the Test Table
USE [AdventureWorks2012]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test_Person](
 [BusinessEntityID] [int] NOT NULL,
 [PersonType] [nchar](2) NOT NULL,
 [NameStyle] [dbo].[NameStyle] NOT NULL,
 [Title] [nvarchar](8) NULL,
 [FirstName] [dbo].[Name] NOT NULL,
 [MiddleName] [dbo].[Name] NULL,
 [LastName] [dbo].[Name] NOT NULL,
 [Suffix] [nvarchar](10) NULL,
 [EmailPromotion] [int] NOT NULL,
 [AdditionalContactInfo] [xml](CONTENT [Person].[AdditionalContactInfoSchemaCollection]) NULL,
 [Demographics] [xml](CONTENT [Person].[IndividualSurveySchemaCollection]) NULL,
 [rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 [ModifiedDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
-- We Populated this table with the Data Stored in Table Person.Person.
-- As we need Plenty of data so we ran the loop 100 times.
INSERT INTO [dbo].[Test_Person] 
SELECT P1.*
FROM Person.Person P1
GO 100
-- At this point we have 1,997,200 rows in the table.
-- Create Clustered Index  on Coloun [BusinessEntityID] 
CREATE CLUSTERED INDEX [CL_Test_Person] ON [dbo].[Test_Person]
( [BusinessEntityID])
GO
-- Creating Non - CLustered Index on 3 Columns
CREATE NONCLUSTERED INDEX [ColumnStore__Test_Person]
ON [dbo].[Test_Person]
([FirstName] , [MiddleName],[LastName])

-- Creating Non - CLustered  ColumnStore Index on 3 Columns
CREATE NONCLUSTERED COLUMNSTORE INDEX [ColumnStore__Test_Person_New]
ON [dbo].[Test_Person]
([FirstName] , [MiddleName],[LastName])
*/


select [LastName],Count([FirstName]),Count([MiddleName])
from dbo.Test_Person 
group by [LastName]
Order by [LastName]
OPTION (IGNORE_NONCLUSTERED_COLUMNSTORE_INDEX)



select [LastName],Count([FirstName]),Count([MiddleName])
from dbo.Test_Person 
group by [LastName]
Order by [LastName]