---------------------------------------------------------------------

SELECT Name FROM Departments

---------------------------------------------------------------------

SELECT FirstName, LastName, JobTitle
FROM Employees

---------------------------------------------------------------------

INSERT INTO Projects(Name, StartDate)
VALUES('Introduction to SQL Course', '1/1/2006')

---------------------------------------------------------------------

UPDATE Projects
SET EndDate = '8/31/2006'
WHERE StartDate = '1/1/2006'

---------------------------------------------------------------------

DELETE FROM Projects
WHERE StartDate = '1/1/2006'

---------------------------------------------------------------------

CREATE PROCEDURE EmpDump AS
  DECLARE @EmpId INT, @EmpFName NVARCHAR(100), 
    @EmpLName NVARCHAR(100)
  DECLARE emps CURSOR FOR
    SELECT EmployeeID, FirstName, LastName FROM Employees
  OPEN emps
  FETCH NEXT FROM emps INTO @EmpId, @EmpFName, @EmpLName
  WHILE (@@FETCH_STATUS = 0) BEGIN
    PRINT CAST(@EmpId AS VARCHAR(10)) + ' '
      + @EmpFName + ' ' + @EmpLName
    FETCH NEXT FROM emps INTO @EmpId, @EmpFName, @EmpLName
  END
  CLOSE emps
  DEALLOCATE emps
GO

---------------------------------------------------------------------

EXEC EmpDump

---------------------------------------------------------------------

SELECT * FROM Departments

---------------------------------------------------------------------

SELECT
  DepartmentID,
  Name
FROM Departments

---------------------------------------------------------------------

SELECT (2 + 3) * 4

---------------------------------------------------------------------

SELECT LastName, Salary, Salary + 300
FROM Employees

---------------------------------------------------------------------

SELECT LastName, ManagerID FROM Employees

---------------------------------------------------------------------

SELECT FirstName, LastName, Salary, Salary*0.2 AS Bonus,
Salary * 0.2 / 12 AS "Monthly Bonus" FROM Employees

---------------------------------------------------------------------

SELECT FirstName + ' ' + LastName AS [Full Name],
EmployeeID as [No.] FROM Employees

---------------------------------------------------------------------

SELECT FirstName + '''s last name is ' +
LastName AS [Our Employees] FROM Employees

---------------------------------------------------------------------

SELECT DepartmentID
FROM Employees

---------------------------------------------------------------------

SELECT DISTINCT DepartmentID
FROM Employees

---------------------------------------------------------------------

SELECT FirstName AS Name
FROM Employees
UNION
SELECT LastName AS Name
FROM Employees

---------------------------------------------------------------------

SELECT FirstName AS Name
FROM Employees
INTERSECT
SELECT LastName AS Name
FROM Employees

---------------------------------------------------------------------

SELECT FirstName AS Name
FROM Employees
EXCEPT
SELECT LastName AS Name
FROM Employees

---------------------------------------------------------------------

SELECT LastName, DepartmentID 
FROM Employees 
WHERE DepartmentID = 1

---------------------------------------------------------------------

SELECT FirstName, LastName, DepartmentID
FROM Employees
WHERE LastName = 'Sullivan'

---------------------------------------------------------------------

SELECT LastName, Salary
FROM Employees
WHERE Salary <= 20000

---------------------------------------------------------------------

SELECT LastName, Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 22000

---------------------------------------------------------------------

SELECT FirstName, LastName, ManagerID
FROM Employees
WHERE ManagerID IN (109, 16, 3)

---------------------------------------------------------------------

SELECT FirstName FROM Employees
WHERE FirstName LIKE 'S%'

---------------------------------------------------------------------

SELECT LastName FROM Employees
WHERE ManagerID IS NULL

---------------------------------------------------------------------

SELECT LastName, ManagerId FROM Employees
WHERE ManagerId IS NOT NULL

---------------------------------------------------------------------

SELECT FirstName, LastName FROM Employees
WHERE Salary >= 20000 AND LastName LIKE 'C%'

---------------------------------------------------------------------

SELECT LastName FROM Employees
WHERE ManagerID IS NOT NULL OR LastName LIKE '%so_'

---------------------------------------------------------------------

SELECT LastName FROM Employees
WHERE NOT (ManagerID = 3 OR ManagerID = 4)

---------------------------------------------------------------------

SELECT FirstName, LastName FROM Employees
WHERE
    (ManagerID = 3 OR ManagerID = 4) AND
    (Salary >= 20000 OR ManagerID IS NULL)

---------------------------------------------------------------------

SELECT LastName, HireDate
FROM Employees
ORDER BY HireDate

---------------------------------------------------------------------

SELECT LastName, HireDate
FROM Employees
ORDER BY HireDate DESC

---------------------------------------------------------------------

SELECT TOP 5 * FROM Towns

---------------------------------------------------------------------

SELECT * FROM Towns
ORDER BY Name 
OFFSET 20 ROWS 
FETCH NEXT 5 ROWS ONLY

---------------------------------------------------------------------

SELECT LastName, Name AS DepartmentName
FROM Employees, Departments

---------------------------------------------------------------------

SELECT
  e.EmployeeID, e.LastName, e.DepartmentID, 
  d.DepartmentID, d.Name AS DepartmentName
FROM Employees e INNER JOIN Departments d 
  ON e.DepartmentID = d.DepartmentID

---------------------------------------------------------------------

SELECT 
  e.EmployeeID, e.LastName, e.DepartmentID, 
  d.DepartmentID, d.Name AS DepartmentName
FROM Employees e, Departments d 
WHERE e.DepartmentID = d.DepartmentID

---------------------------------------------------------------------

SELECT
  e.LastName EmpLastName,
  m.EmployeeID MgrID, m.LastName MgrLastName
FROM Employees e INNER JOIN Employees m
  ON e.ManagerID = m.EmployeeID

---------------------------------------------------------------------

SELECT
  e.LastName EmpLastName,
  m.EmployeeID MgrID, m.LastName MgrLastName
FROM Employees e LEFT OUTER JOIN Employees m
  ON e.ManagerID = m.EmployeeID


---------------------------------------------------------------------

SELECT
  e.LastName EmpLastName,
  m.EmployeeID MgrID, m.LastName MgrLastName
FROM Employees e RIGHT OUTER JOIN Employees m
  ON e.ManagerID = m.EmployeeID

---------------------------------------------------------------------

SELECT
  e.LastName EmpLastName,
  m.EmployeeID MgrID, m.LastName MgrLastName
FROM employee e FULL OUTER JOIN employee m
  ON e.ManagerID = m.EmployeeID

---------------------------------------------------------------------

SELECT e.FirstName, e.LastName, t.Name as Town, a.AddressText
FROM Employees e
  JOIN Address a
    ON e.AddressID = a.AddressID
  JOIN Town t
    ON a.TownID = t.TownID

---------------------------------------------------------------------

SELECT e.FirstName + ' ' + e.LastName +
 ' is managed by ' + m.LastName as Message
FROM Employees e JOIN Employees m
ON (e.ManagerId = m.EmployeeId)

---------------------------------------------------------------------

SELECT LastName [Last Name], Name [Dept Name]
FROM Employees CROSS JOIN Departments

---------------------------------------------------------------------

SELECT e.EmployeeID, e.LastName, e.DepartmentID, 
       d.DepartmentID, d.Name AS DepartmentName
FROM Employees e 
  INNER JOIN Departments d 
    ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

---------------------------------------------------------------------

SELECT e.FirstName, e.LastName, d.Name as DeptName
FROM Employees e
  INNER JOIN Departments d
  ON (e.DepartmentId = d.DepartmentId
  AND e.HireDate > '1/1/1999'
  AND d.Name IN ('Sales', 'Finance'))

---------------------------------------------------------------------

SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary = 
  (SELECT MAX(Salary) FROM Employees)

---------------------------------------------------------------------

SELECT FirstName, LastName, DepartmentID, Salary
FROM Employees
WHERE DepartmentID IN 
  (SELECT DepartmentID FROM Departments
   WHERE Name='Sales')

---------------------------------------------------------------------

SELECT FirstName, LastName, DepartmentID, Salary
FROM Employees e
WHERE Salary = 
  (SELECT MAX(Salary) FROM Employees 
   WHERE DepartmentID = e.DepartmentID)
ORDER BY DepartmentID

---------------------------------------------------------------------

SELECT FirstName, LastName, EmployeeID, ManagerID
FROM Employees e
WHERE EXISTS
  (SELECT EmployeeID
   FROM Employees m
   WHERE m.EmployeeID = e.ManagerID
     AND m.DepartmentID = 1)

---------------------------------------------------------------------

SELECT
  AVG(Salary) [Average Salary],
  MAX(Salary) [Max Salary],
  MIN(Salary) [Min Salary],
  SUM(Salary) [Salary Sum]
FROM Employees
WHERE JobTitle = 'Sales Representative'

---------------------------------------------------------------------

SELECT MIN(HireDate) MinHD, MAX(HireDate) MaxHD
FROM Employees

---------------------------------------------------------------------

SELECT MIN(LastName), MAX(LastName)
FROM employee

---------------------------------------------------------------------

SELECT COUNT(*) Cnt FROM Employees
WHERE DepartmentID = 3

---------------------------------------------------------------------

SELECT
  COUNT(ManagerID) MgrCount,
  COUNT(*) AllCount
FROM Employees
WHERE DepartmentID = 16

---------------------------------------------------------------------

SELECT
  AVG(ManagerID) Avg,
  SUM(ManagerID) / COUNT(*) AvgAll
FROM Employees

---------------------------------------------------------------------

SELECT e.FirstName, e.LastName, e.HireDate, d.Name
FROM Employees e 
  JOIN Departments d
    ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate = 
  (SELECT MIN(HireDate) FROM Employees 
   WHERE DepartmentID = d.DepartmentID)

---------------------------------------------------------------------

SELECT DepartmentID, SUM(Salary)
FROM Employees
GROUP BY DepartmentID

---------------------------------------------------------------------

SELECT 
  DepartmentID, JobTitle, 
  SUM(Salary) as Salaries,
  COUNT(*) as Count
FROM Employees
GROUP BY DepartmentID, JobTitle

---------------------------------------------------------------------

-- This SQL query is illegal!
SELECT DepartmentID, COUNT(LastName)
FROM Employees

---------------------------------------------------------------------

-- This SQL query is illegal!
SELECT DepartmentID, AVG(Salary)
FROM Employees
WHERE AVG(Salary) > 30
GROUP BY DepartmentID

---------------------------------------------------------------------

SELECT DepartmentID, JobTitle, 
  SUM(Salary) AS Cost, MIN(HireDate) as StartDate
FROM Employees
GROUP BY DepartmentID, JobTitle

---------------------------------------------------------------------

SELECT DepartmentID, COUNT(EmployeeID) as Count, 
  AVG(Salary) AverageSalary
FROM Employees
GROUP BY DepartmentID
HAVING COUNT(EmployeeID) BETWEEN 3 AND 5

---------------------------------------------------------------------

SELECT COUNT(*) AS EmpCount, d.Name AS DeptName
FROM Employees e 
  JOIN Departments d
    ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate BETWEEN '1999-2-1' AND '2002-12-31'
GROUP BY d.Name
HAVING COUNT(*) > 5
ORDER BY EmpCount DESC

---------------------------------------------------------------------

SELECT Name AS [Projects Name], 
  COALESCE(EndDate, GETDATE()) AS [End Date]
FROM Projects

---------------------------------------------------------------------

SELECT LastName, LEN(LastName) AS LastNameLen,
  UPPER(LastName) AS UpperLastName
FROM Employees
WHERE RIGHT(LastName, 3) = 'son'

---------------------------------------------------------------------

CREATE TABLE Persons (
  PersonID int IDENTITY,
  Name nvarchar(100) NOT NULL,
  CONSTRAINT PK_Persons PRIMARY KEY(PersonID)
)

GO

CREATE VIEW [First 10 Persons] AS
SELECT TOP 10 Name FROM Persons

---------------------------------------------------------------------

CREATE TABLE Countries (
  CountryID int IDENTITY,
  Name nvarchar(100) NOT NULL,
  CONSTRAINT PK_Countries PRIMARY KEY(CountryID)
)
GO
CREATE TABLE Cities (
  CityID int IDENTITY,
  Name nvarchar(100) NOT NULL,
  CountryID int NOT NULL,
  CONSTRAINT PK_Towns PRIMARY KEY(CityID)
)

---------------------------------------------------------------------

-- Add a foreign key constraint Cities --> Countries
ALTER TABLE Cities
ADD CONSTRAINT FK_Cities_Countries
  FOREIGN KEY (CountryID)
  REFERENCES Countries(CountryID)

-- Add column Population to the table Countries
ALTER TABLE Countries ADD Population int

-- Remove column Population from the table Countries
ALTER TABLE Countries DROP COLUMN Population

---------------------------------------------------------------------

DROP TABLE Persons

ALTER TABLE Cities
DROP CONSTRAINT FK_Cities_Countries

---------------------------------------------------------------------

REVOKE SELECT ON Employees FROM public

---------------------------------------------------------------------

CREATE TABLE Groups (
  GroupID int IDENTITY,
  Name nvarchar(100) NOT NULL,
  CONSTRAINT PK_Groups PRIMARY KEY(GroupID)
)

CREATE TABLE Users (
  UserID int IDENTITY,
  UserName nvarchar(100) NOT NULL,
  GroupID int NOT NULL,
  CONSTRAINT PK_Users PRIMARY KEY(UserID),
  CONSTRAINT FK_Users_Groups FOREIGN KEY(GroupID)
    REFERENCES Groups(GroupID)
)

---------------------------------------------------------------------

INSERT INTO EmployeesProjects
VALUES (229, 25)

INSERT INTO Projects(Name, StartDate)
VALUES ('New project', GETDATE())

INSERT INTO Projects(Name, StartDate)
  SELECT Name + ' Restructuring', GETDATE()
  FROM Departments
  
INSERT INTO EmployeesProjects VALUES
 (229, 1),
 (229, 2),
 (229, 3),
 (229, 4),
 (229, 5),
 (229, 6),
 (229, 8),
 (229, 9),
 (229, 10),
 (229, 11),
 (229, 12),
 (229, 26)

---------------------------------------------------------------------

UPDATE Employees
SET LastName = 'Brown'
WHERE EmployeeID = 1

UPDATE Employees
SET Salary = Salary * 1.10,
  JobTitle = 'Senior ' + JobTitle
WHERE DepartmentID = 3

---------------------------------------------------------------------

UPDATE Employees
SET JobTitle = 'Senior ' + JobTitle
FROM Employees e 
  JOIN Departments d
    ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

---------------------------------------------------------------------

-- This will execute successfully
DELETE FROM Employees WHERE EmployeeID = 293

-- This will fail due to foreign key constraint
DELETE FROM Employees WHERE EmployeeID = 1

---------------------------------------------------------------------

TRUNCATE TABLE Users

---------------------------------------------------------------------
