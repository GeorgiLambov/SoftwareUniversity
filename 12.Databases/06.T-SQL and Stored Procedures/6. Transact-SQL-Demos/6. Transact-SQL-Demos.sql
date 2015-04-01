USE SoftUni
GRANT SELECT ON Employees TO Public
GO

---------------------------------------------------------------------

USE SoftUni
SELECT
	FirstName,
	LastName,
	Salary,
	JobTitle
FROM Employees
WHERE Salary BETWEEN 10000 AND 20000
ORDER BY JobTitle

---------------------------------------------------------------------

EXEC sp_who

---------------------------------------------------------------------

USE SoftUni
GO

DECLARE @table VARCHAR(50) = 'Projects'
SELECT
	'The table is: ' + @table
DECLARE @query VARCHAR(50) = 'SELECT * FROM ' + @table;
EXEC (@query)
GO

-- The following will cause an error because @table is defined in different batch.
SELECT
	'The table is: ' + @table

---------------------------------------------------------------------

DECLARE 
	@EmpID varchar(11),
	@LastName char(20)
SET @LastName = 'King'
SELECT
	@EmpID = EmployeeId
FROM Employees
WHERE LastName = @LastName
SELECT
	@EmpID AS EmployeeID
GO

---------------------------------------------------------------------

USE SoftUni

DECLARE 
	@EmpID varchar(11),
	@LastName char(20)
SET @LastName = 'King'

SELECT
	@EmpID = EmployeeId
FROM Employees
WHERE LastName = @LastName

SELECT
	@EmpID AS EmployeeID

---------------------------------------------------------------------

SELECT
	AVG(Salary) AS AvgSalary
FROM Employees

---------------------------------------------------------------------

SELECT
	DB_NAME() AS [Active Database]

---------------------------------------------------------------------

SELECT
	DATEDIFF(YEAR, HireDate, GETDATE()) * Salary / 1000
	AS [Annual Bonus]
FROM Employees

---------------------------------------------------------------------

IF (( SELECT
	COUNT(*)
FROM Employees)
>= 100) BEGIN
PRINT 'Employees are at least 100'
END

---------------------------------------------------------------------

IF (( SELECT
	COUNT(*)
FROM Employees)
>= 100) BEGIN
PRINT 'Employees are at least 100'
END ELSE BEGIN
PRINT 'Employees are less than 100'
END

---------------------------------------------------------------------

DECLARE @n int = 10

PRINT 'The numbers from 10 down to 1 are:'
WHILE (@n > 0)
  BEGIN
    PRINT @n
SET @n = @n - 1
END

  ---------------------------------------------------------------------

DECLARE @n int = 10
PRINT 'Calculating factoriel of ' + 
  CAST(@n as varchar) + ' ...'

DECLARE @factorial numeric(38) = 1
WHILE (@n > 1)
  BEGIN
SET @factorial = @factorial * @n
SET @n = @n - 1
END

PRINT @factorial

---------------------------------------------------------------------

SELECT
	Salary,
	[Salary Level] =
					CASE
						WHEN Salary BETWEEN 0 AND 9999 THEN 'Low'
						WHEN Salary BETWEEN 10000 AND 30000 THEN 'Average'
						WHEN Salary > 30000 THEN 'High'
						ELSE 'Unknown'
					END
FROM Employees

---------------------------------------------------------------------

DECLARE @n tinyint
SET @n = 5
IF (@n BETWEEN 4 and 6)
 BEGIN
  WHILE (@n > 0)
   BEGIN
SELECT
	@n AS 'Number',
	CASE
		WHEN (@n % 2) = 1 THEN 'EVEN'
		ELSE 'ODD'
	END AS 'Type'
SET @n = @n - 1
END
END ELSE PRINT 'NO ANALYSIS'
GO

---------------------------------------------------------------------

USE SoftUni
GO

CREATE PROC usp_SelectEmployeesBySeniority
AS
SELECT
	*
FROM Employees
WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > 5
GO

---------------------------------------------------------------------

EXEC usp_SelectEmployeesBySeniority

---------------------------------------------------------------------

ALTER PROC usp_SelectEmployeesBySeniority
AS
SELECT
	FirstName,
	LastName,
	HireDate,
	DATEDIFF(YEAR, HireDate, GETDATE()) AS Years
FROM Employees
WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > 5
ORDER BY HireDate
GO

EXEC usp_SelectEmployeesBySeniority

---------------------------------------------------------------------

EXEC sp_depends 'usp_SelectEmployeesBySeniority'

---------------------------------------------------------------------

DROP PROC usp_SelectEmployeesBySeniority

---------------------------------------------------------------------

CREATE PROC usp_SelectEmployeesBySeniority(
  @minYearsAtWork int = 5)
AS
SELECT
	FirstName,
	LastName,
	HireDate,
	DATEDIFF(YEAR, HireDate, GETDATE()) AS Years
FROM Employees
WHERE DATEDIFF(YEAR, HireDate, GETDATE()) >
@minYearsAtWork
ORDER BY HireDate
GO

EXEC usp_SelectEmployeesBySeniority 10

EXEC usp_SelectEmployeesBySeniority

---------------------------------------------------------------------

CREATE PROCEDURE dbo.usp_AddNumbers
   @firstNumber smallint,
   @secondNumber smallint,
   @result int OUTPUT
AS
SET @result = @firstNumber + @secondNumber
GO

DECLARE @answer smallint
EXECUTE usp_AddNumbers	5,
						6,
						@answer OUTPUT
SELECT
	'The result is: ',
	@answer

---------------------------------------------------------------------

CREATE PROC usp_NewEmployee(
  @firstName nvarchar(50), @lastName nvarchar(50),
  @jobTitle nvarchar(50), @deptId int, @salary money)
AS
INSERT INTO Employees (FirstName, LastName,
JobTitle, DepartmentID, HireDate, Salary)
	VALUES (@firstName, @lastName, @jobTitle, @deptId, GETDATE(), @salary)
RETURN SCOPE_IDENTITY()
GO

DECLARE @newEmployeeId int
EXEC @newEmployeeId = usp_NewEmployee	@firstName = 'Steve',
										@lastName = 'Jobs',
										@jobTitle = 'Trainee',
										@deptId = 1,
										@salary = 7500

SELECT
	EmployeeID,
	FirstName,
	LastName
FROM Employees
WHERE EmployeeId = @newEmployeeId

---------------------------------------------------------------------

CREATE TRIGGER tr_TownsUpdate ON Towns FOR UPDATE
AS
  IF (EXISTS (SELECT
	*
FROM inserted
WHERE Name IS NULL)
OR
EXISTS (SELECT
	*
FROM inserted
WHERE LEN(Name) = 0)
) BEGIN
RAISERROR ('Town name cannot be empty.', 16, 1)
ROLLBACK TRAN
RETURN
END
GO

UPDATE Towns
SET Name = 'Sofia'
WHERE TownId = 1

UPDATE Towns
SET Name = ''
WHERE TownId = 1

UPDATE Towns
SET Name = ''

UPDATE Towns
SET Name = NULL

---------------------------------------------------------------------

CREATE TABLE Accounts(
  Username varchar(10) NOT NULL PRIMARY KEY,
  [Password] varchar(20) NOT NULL,
  Active CHAR NOT NULL DEFAULT 'Y' )
GO
  
CREATE VIEW V_Active_Accounts AS
SELECT
	*
FROM Accounts
WHERE Active = 'Y'
GO
  

CREATE TRIGGER tr_AccountsDelete ON Accounts
  INSTEAD OF DELETE
AS
UPDATE a
SET Active = 'N'
FROM Accounts a
JOIN DELETED d
	ON d.Username = a.Username
WHERE a.Active = 'Y'
GO

INSERT INTO Accounts (Username, Password)
	VALUES ('pesho', 'qwerty123')

INSERT INTO Accounts (Username, Password)
	VALUES ('kiro', 'secret!')

SELECT
	*
FROM V_Active_Accounts

DELETE FROM Accounts
WHERE Username = 'kiro'

SELECT
	*
FROM V_Active_Accounts

SELECT
	*
FROM Accounts

---------------------------------------------------------------------

CREATE FUNCTION ufn_CalcBonus(@salary money)
  RETURNS money
AS
BEGIN
  IF (@salary < 10000)
    RETURN 1000
  ELSE IF (@salary BETWEEN 10000 and 30000)
    RETURN @salary / 20
  RETURN 3500
END
GO

SELECT
	Salary,
	dbo.ufn_CalcBonus(Salary) AS Bonus
FROM Employees

---------------------------------------------------------------------

USE SoftUni
GO
CREATE FUNCTION fn_EmployeeNamesForJobTitle
  ( @jobTitleParameter nvarchar(30) )
RETURNS TABLE
AS
RETURN (
SELECT
	FirstName,
	LastName,
	JobTitle
FROM SoftUni.dbo.Employees
WHERE JobTitle = @jobTitleParameter
)


SELECT
	*
FROM fn_EmployeeNamesForJobTitle(N'Stocker')

---------------------------------------------------------------------

CREATE FUNCTION fn_ListEmployees(@format nvarchar(5))
RETURNS @tbl_Employees TABLE
  (EmployeeID int PRIMARY KEY NOT NULL,
  [Employee Name] Nvarchar(61) NOT NULL)
AS
BEGIN
  IF @format = 'short'
INSERT @tbl_Employees
	SELECT
		EmployeeID,
		LastName
	FROM Employees ELSE IF @format = 'long' INSERT @tbl_Employees
	SELECT
		EmployeeID,
		(FirstName + ' ' + LastName)
	FROM Employees
RETURN
END
GO

SELECT
	*
FROM fn_ListEmployees('short')

SELECT
	*
FROM fn_ListEmployees('long')

---------------------------------------------------------------------

DECLARE empCursor CURSOR READ_ONLY FOR SELECT
	FirstName,
	LastName
FROM Employees

OPEN empCursor
DECLARE @firstName char(50), @lastName char(50)
FETCH NEXT FROM empCursor INTO @firstName, @lastName

WHILE @@FETCH_STATUS = 0
  BEGIN
    PRINT @firstName + ' ' + @lastName
    FETCH NEXT FROM empCursor 
    INTO @firstName, @lastName
  END

CLOSE empCursor
DEALLOCATE empCursor


---------------------------------------------------------------------