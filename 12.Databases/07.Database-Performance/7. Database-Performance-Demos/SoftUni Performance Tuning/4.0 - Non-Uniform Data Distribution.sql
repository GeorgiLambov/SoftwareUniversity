/*============================================================================
	File:		4.0 - Non-Uniform Data distribution.sql

	Summary:	The script demonstrates what is the effect on the DML operations
				when there are a lot of indexes on the table.

				THIS SCRIPT IS PART OF THE Lecture: 
				"Performance Tuning" for SoftUni, Sofia

	Date:		February 2015

	SQL Server Version: 2008 / 2012 / 2014
------------------------------------------------------------------------------
	Written by Guy Glantser, SQL Server MVP

	This script is intended only as a supplement to demos and lectures
	given by Boris Hristov.  
  
	THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF 
	ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED 
	TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
	PARTICULAR PURPOSE.
============================================================================*/

USE
	ParameterizationExample;
GO


-- Empty the procedure cache

DBCC FREEPROCCACHE;
GO


-- Display statistics information for the ix_Customers_nc_nu_Country index

DBCC SHOW_STATISTICS (N'Marketing.Customers' , ix_Customers_nc_nu_Country);
GO


-- Execute the "Marketing.usp_CustomersByCountry" stored procedure with the parameter "IL"

EXECUTE Marketing.usp_CustomersByCountry
	@Country = N'IL';
GO


-- Execute the "Marketing.usp_CustomersByCountry" stored procedure again,
-- this time with the parameter "US"

EXECUTE Marketing.usp_CustomersByCountry
	@Country = N'US';
GO


-- Solution #1:
-- Instruct the query processor to recompile the stored procedure next time it is executed

EXECUTE sys.sp_recompile
	@objname = N'Marketing.usp_CustomersByCountry';
GO


-- Execute the "Marketing.usp_CustomersByCountry" stored procedure with the parameter "US"

EXECUTE Marketing.usp_CustomersByCountry
	@Country = N'US';
GO


-- Execute the "Marketing.usp_CustomersByCountry" stored procedure again,
-- this time with the parameter "IL"

EXECUTE Marketing.usp_CustomersByCountry
	@Country = N'IL';
GO


-- Solution #2:
-- Add the "WITH RECOMPILE" option to the "Marketing.usp_CustomersByCountry" stored procedure.

ALTER PROCEDURE
	Marketing.usp_CustomersByCountry
(
	@Country AS NCHAR(2)
)
WITH
	RECOMPILE
AS

SELECT
	Id ,
	Name ,
	LastPurchaseDate
FROM
	Marketing.Customers
WHERE
	Country = @Country;
GO


-- Execute the "Marketing.usp_CustomersByCountry" stored procedure with the parameter "IL"

EXECUTE Marketing.usp_CustomersByCountry
	@Country = N'IL';
GO


-- Execute the "Marketing.usp_CustomersByCountry" stored procedure again,
-- this time with the parameter "US"

EXECUTE Marketing.usp_CustomersByCountry
	@Country = N'US';
GO


-- Solution #3:
-- Alter the "Marketing.usp_CustomersByCountry" stored procedure again, this time add the "RECOMPILE" option
-- to the query insead of the whole stored procedure

ALTER PROCEDURE
	Marketing.usp_CustomersByCountry
(
	@Country AS NCHAR(2)
)
AS

SELECT
	Id ,
	Name ,
	LastPurchaseDate
FROM
	Marketing.Customers
WHERE
	Country = @Country
OPTION
	(RECOMPILE);
GO


-- Execute the "Marketing.usp_CustomersByCountry" stored procedure with the parameter "IL"

EXECUTE Marketing.usp_CustomersByCountry
	@Country = N'IL';
GO


-- Execute the "Marketing.usp_CustomersByCountry" stored procedure again,
-- this time with the parameter "US"

EXECUTE Marketing.usp_CustomersByCountry
	@Country = N'US';
GO


-- Solution #4:
-- Alter the "Marketing.usp_CustomersByCountry" stored procedure again, this time add the "OPTIMIZE FOR" option
-- to the query using "US" as the parameter value

ALTER PROCEDURE
	Marketing.usp_CustomersByCountry
(
	@Country AS NCHAR(2)
)
AS

SELECT
	Id ,
	Name ,
	LastPurchaseDate
FROM
	Marketing.Customers
WHERE
	Country = @Country
OPTION
	(OPTIMIZE FOR (@Country = N'US'));
GO


-- Execute the "Marketing.usp_CustomersByCountry" stored procedure with the parameter "IL"

EXECUTE Marketing.usp_CustomersByCountry
	@Country = N'IL';
GO


-- Execute the "Marketing.usp_CustomersByCountry" stored procedure again,
-- this time with the parameter "US"

EXECUTE Marketing.usp_CustomersByCountry
	@Country = N'US';
GO


-- Solution #5:
-- Create a table to hold the histogram of the ix_Customers_nc_nu_Country index

CREATE TABLE
	Marketing.CommonCountries
(
	RANGE_HI_KEY		NCHAR(2)	NOT NULL ,
	RANGE_ROWS			INT			NOT NULL ,
	EQ_ROWS				INT			NOT NULL ,
	DISTINCT_RANGE_ROWS	INT			NOT NULL ,
	AVG_RANGE_ROWS		FLOAT		NOT NULL ,

	CONSTRAINT
		pk_CommonCountries_c_RANGEHIKEY
	PRIMARY KEY CLUSTERED
		(RANGE_HI_KEY ASC)
);
GO


-- Inserts the histogram into the "Marketing.CommonCountries" table

INSERT INTO
	Marketing.CommonCountries
(
	RANGE_HI_KEY ,
	RANGE_ROWS ,
	EQ_ROWS ,
	DISTINCT_RANGE_ROWS ,
	AVG_RANGE_ROWS
)
EXECUTE ('DBCC SHOW_STATISTICS (N''Marketing.Customers'' , ix_Customers_nc_nu_Country) WITH HISTOGRAM');
GO


-- View the contents of the "Marketing.CommonCountries" table

SELECT
	RANGE_HI_KEY ,
	RANGE_ROWS ,
	EQ_ROWS ,
	DISTINCT_RANGE_ROWS ,
	AVG_RANGE_ROWS
FROM
	Marketing.CommonCountries
ORDER BY
	RANGE_HI_KEY ASC;
GO


-- Leave only the common countries in the "Marketing.CommonCountries" table

DECLARE
	@RowCount AS INT;

SELECT
	@RowCount = COUNT (*)
FROM
	Marketing.Customers;

DELETE FROM
	Marketing.CommonCountries
WHERE
	EQ_ROWS < @RowCount * 0.01;
GO


-- View the contents of the "Marketing.CommonCountries" table again

SELECT
	RANGE_HI_KEY ,
	RANGE_ROWS ,
	EQ_ROWS ,
	DISTINCT_RANGE_ROWS ,
	AVG_RANGE_ROWS
FROM
	Marketing.CommonCountries
ORDER BY
	RANGE_HI_KEY ASC;
GO


-- Create an intrenal instance of the "Marketing.usp_CustomersByCountry" stored procedure
-- for common countries

CREATE PROCEDURE
	Marketing.usp_CustomersByCountry_Common
(
	@Country AS NCHAR(2)
)
AS

SELECT
	Id ,
	Name ,
	LastPurchaseDate
FROM
	Marketing.Customers
WHERE
	Country = @Country;
GO


-- Create an intrenal instance of the "Marketing.usp_CustomersByCountry" stored procedure
-- for uncommon countries

CREATE PROCEDURE
	Marketing.usp_CustomersByCountry_Uncommon
(
	@Country AS NCHAR(2)
)
AS

SELECT
	Id ,
	Name ,
	LastPurchaseDate
FROM
	Marketing.Customers
WHERE
	Country = @Country;
GO


-- Alter the "Marketing.usp_CustomersByCountry" stored procedure to only execute
-- one of the intrenal stored procedures

ALTER PROCEDURE
	Marketing.usp_CustomersByCountry
(
	@Country AS NCHAR(2)
)
AS

IF
	EXISTS
		(
			SELECT
				NULL
			FROM
				Marketing.CommonCountries
			WHERE
				RANGE_HI_KEY = @Country
		)
BEGIN

	EXECUTE Marketing.usp_CustomersByCountry_Common
		@Country = @Country;

END
ELSE
BEGIN

	EXECUTE Marketing.usp_CustomersByCountry_Uncommon
		@Country = @Country;

END;
GO


-- Execute the "Marketing.usp_CustomersByCountry" stored procedure with the parameter "IL"

EXECUTE Marketing.usp_CustomersByCountry
	@Country = N'IL';
GO


-- Execute the "Marketing.usp_CustomersByCountry" stored procedure again,
-- this time with the parameter "US"

EXECUTE Marketing.usp_CustomersByCountry
	@Country = N'US';
GO
