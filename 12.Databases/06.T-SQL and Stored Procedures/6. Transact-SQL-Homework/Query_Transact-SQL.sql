USE master
GO

CREATE DATABASE Bank
GO

USE Bank
GO

-- 1.Create a database with two tables. Persons (id (PK), first name, last name, SSN) and Accounts (id (PK), person id (FK), balance).
-- Insert few records for testing. Write a stored procedure that selects the full names of all persons.
CREATE TABLE [dbo].[Persons](
		PersonID int IDENTITY NOT NULL,
		FirstName nvarchar(30) NOT NULL,
		LastNAme nvarchar(30) NOT NULL,
		SSN nvarchar(30) NOT NULL,
		CONSTRAINT PK_Person PRIMARY KEY CLUSTERED(PersonID ASC)
)
GO

CREATE TABLE [dbo].[Accounts](
		AccountID int IDENTITY NOT NULL,
		PersonID int NOT NULL,
		Balance money NOT NUll,
		CONSTRAINT PK_Accounts PRIMARY KEY CLUSTERED(AccountID),
		CONSTRAINT chk_Accounts CHECK (Balance >= 0)
)
GO

ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Persons] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons]([PersonID])
GO

INSERT INTO Persons(FirstName, LastNAme, SSN)
VALUES('Gogo', 'Gogov', '222-333-44')

INSERT INTO Persons(FirstName, LastNAme, SSN)
VALUES('Pesho', 'Peshov', '2111-1333-04')

INSERT INTO Persons(FirstName, LastNAme, SSN)
VALUES('Minka', 'Svirka', '1-555-44')

INSERT INTO Persons(FirstName, LastNAme, SSN)
VALUES('Niki', 'Nikov', '11111-2-44')
GO

INSERT INTO Accounts(PersonID, Balance)
VALUES(1, 500)

INSERT INTO Accounts(PersonID, Balance)
VALUES(2, 1500)

INSERT INTO Accounts(PersonID, Balance)
VALUES(3, 5500)

INSERT INTO Accounts(PersonID, Balance)
VALUES(1, 500)
GO

CREATE PROCEDURE dbo.usp_SelectPersonsFullNames 
AS
  SELECT FirstName + ' ' + LastName AS [Full Name]
  FROM Persons
GO

EXEC dbo.usp_SelectPersonsFullNames 
GO

-- 2.Create a stored procedure that accepts a number as a parameter and returns all persons
-- who have more money in their accounts than the supplied number.
ALTER PROCEDURE dbo.usp_SelectPeopleWithMoreThanSpecifiedMoney(@money money = 0)
AS
	SELECT p.FirstName + ' ' + p.LastName AS [Full Name], a.Balance
	FROM Persons p JOIN Accounts a
	ON p.PersonID = a.PersonID
	WHERE a.Balance > @money
GO

EXEC dbo.usp_SelectPeopleWithMoreThanSpecifiedMoney 1100
GO

-- 3. Create a function that accepts as parameters – sum, yearly interest rate and number of months.
-- It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
CREATE FUNCTION ufn_CalculateSumWithInterestRate(@sum money, @interest float, @mounts int)
	RETURNS money
AS
BEGIN
	RETURN @sum * (1 + ((@interest / 100.0) / 12) * @mounts)
END
GO

SELECT dbo.ufn_CalculateSumWithInterestRate(Balance, 6.5, 12) AS [Calculate Sum], Balance 
	FROM Accounts
GO

-- 4.Create a stored procedure that uses the function from the previous example.
-- to give an interest to a person's account for one month. It should take the 
-- AccountId and the interest rate as parameters.
CREATE PROCEDURE usp_UpdatePersonsBalanceWithOneMonthRate(@accountID int, @interest float)
AS
	UPDATE Accounts
	SET Balance = dbo.ufn_CalculateSumWithInterestRate(Balance, @interest, 1)
	WHERE AccountID = @accountID
GO

EXEC usp_UpdatePersonsBalanceWithOneMonthRate 2, 10.0
GO

-- 5.Add two more stored procedures WithdrawMoney(AccountId, money)
-- and DepositMoney(AccountId, money) that operate in transactions.
CREATE PROCEDURE usp_WithdrawMoney(@accountID int, @money money)
AS
	DECLARE @currentBalnce money;
	SET @currentBalnce = (SELECT Balance FROM Accounts
							WHERE AccountID = @accountID)
	BEGIN TRANSACTION
		  UPDATE Accounts
		  SET Balance = @currentBalnce - @money
		  WHERE AccountID = @accountID

		  IF((@currentBalnce >= @money) AND (@money >= 0))
				COMMIT TRANSACTION
		  ELSE
				ROLLBACK TRANSACTION
GO

EXEC usp_WithdrawMoney 1, 500
GO

CREATE PROCEDURE usp_DepositMoney(@accountID int, @money money)
AS
	DECLARE @currentBalnce money;
	SET @currentBalnce = (SELECT Balance FROM Accounts
							WHERE AccountID = @accountID)
	BEGIN TRANSACTION
		  UPDATE Accounts
		  SET Balance = @currentBalnce + @money
		  WHERE AccountID = @accountID

		  IF(@money >= 0)
				COMMIT TRANSACTION
		  ELSE
				ROLLBACK TRANSACTION
GO

EXEC usp_DepositMoney 2, 500
GO

-- 6.Create another table – Logs (LogID, AccountID, OldSum, NewSum). Add a trigger to the Accounts table that enters 
-- a new entry into the Logs table every time the sum on an account changes.
CREATE TABLE Logs(
	LogID int IDENTITY,
	AccountID int NOT NULL,
	OldSum money NOT NULL,
	NewSum money NOT NULL,
	CONSTRAINT PK_Logs PRIMARY KEY(LogID)
)
GO

CREATE TRIGGER tr_AccountSumChange  ON Accounts FOR UPDATE
AS 
	IF UPDATE(Balance)
	BEGIN
		INSERT INTO Logs (AccountID, OldSum, NewSum)
		VALUES ((SELECT AccountID FROM INSERTED), (SELECT Balance FROM DELETED), (SELECT Balance FROM INSERTED))
		END
GO

EXEC usp_WithdrawMoney 2, 500
GO

-- 7. Define a function in the database SoftUni  that returns all Employee's names (first or middle or last name) 
-- and all town's names that are comprised of given set of letters. Example 'oistmiahf' will return 'Sofia', 
-- 'Smith', … but not 'Rob' and 'Guy'.
USE SoftUni
GO

CREATE FUNCTION dbo.ufn_NameContainingLetters(@name nvarchar(50), @letters nvarchar(50))
	RETURNS bit
AS
BEGIN
	DECLARE @contains bit
	SET @contains = 1
	DECLARE	@counter int
	SET @counter = 1

	WHILE(@counter <= LEN(@name))
			BEGIN
			IF(CHARINDEX(SUBSTRING(@name, @counter, 1), @letters) = 0)
				SET @contains = 0
		SET @counter = @counter + 1
		END
		RETURN @contains
END
GO

CREATE PROC dbo.usp_FindFirstNames(@LettersToSearch NVARCHAR(50))
AS
	DECLARE @Valid bit
	SET @Valid = 0
                                       
			SELECT e.FirstName AS [First name]
			FROM Employees e
			WHERE
					1 = (SELECT dbo.ufn_NameContainingLetters(e.FirstName, @LettersToSearch))
GO

CREATE PROC dbo.usp_FindMiddleNames(@LettersToSearch NVARCHAR(50))
AS
    DECLARE @Valid bit
    SET @Valid = 0

		SELECT e.FirstName AS [Middle name]
		FROM Employees e
		WHERE
		    1 = (SELECT dbo.ufn_NameContainingLetters(e.FirstName, @LettersToSearch))
GO

CREATE PROC dbo.usp_FindLastNames(@LettersToSearch NVARCHAR(50))
AS
    DECLARE @Valid bit
    SET @Valid = 0

		SELECT e.FirstName AS [Last name]
		FROM Employees e
		WHERE
		    1 = (SELECT dbo.ufn_NameContainingLetters(e.FirstName, @LettersToSearch))
GO

CREATE PROC dbo.usp_FindTowns(@LettersToSearch NVARCHAR(50))
AS
    DECLARE @Valid bit
    SET @Valid = 0

		SELECT t.Name AS [Town]
		FROM Towns t
		WHERE
		    1 = (SELECT dbo.ufn_NameContainingLetters(t.Name, @LettersToSearch))
GO

EXEC dbo.usp_FindFirstNames 'oistmiahf'
EXEC dbo.usp_FindMiddleNames 'oistmiahf'
EXEC dbo.usp_FindLastNames 'asgas'
EXEC dbo.usp_FindTowns 'oistmiahf'

-- 8. Using database cursor write a T-SQL script that scans all employees and their addresses 
-- and prints all pairs of employees that live in the same town.
DECLARE empCursor CURSOR READ_ONLY FOR
        SELECT e1.FirstName, e1.LastName, t.Name, e2.FirstName, e2.LastName
        FROM Employees e1
                INNER JOIN Addresses a
                        ON a.AddressID = e1.AddressID
                INNER JOIN Towns t
                        ON t.TownID = a.TownID,
        Employees e2
                INNER JOIN Addresses a1
                        ON a1.AddressID = e2.AddressID
                INNER JOIN Towns t1
                        ON t1.TownID = a1.TownID               
 
        OPEN empCursor
        DECLARE @e1fname NVARCHAR(50)
        DECLARE @e1lname NVARCHAR(50)
        DECLARE @e2fname NVARCHAR(50)
        DECLARE @e2lname NVARCHAR(50)
        DECLARE @town NVARCHAR(50)

-- Get all permutations of two employees in one town
        FETCH NEXT FROM empCursor
                INTO @e1fname, @e1lname, @e2fname, @e2lname, @town
 
        WHILE @@FETCH_STATUS = 0
                BEGIN
                        PRINT @town + ': ' + @e1fname + ' ' + @e1lname + ' ' + @e2fname + ' ' + @e2lname
                        FETCH NEXT FROM empCursor
                                INTO @e1fname, @e1lname, @e2fname, @e2lname, @town
                END
 
CLOSE empCursor
DEALLOCATE empCursor

-- 9*. Define a .NET aggregate function StrConcat that takes as input a sequence of strings and return a single string 
-- that consists of the input strings separated by ','. For example the following SQL statement should return a single string:
-- SELECT StrConcat(FirstName + ' ' + LastName)
-- FROM Employees
DECLARE @name nvarchar(MAX);
SET @name = N'';
SELECT @name+=e.FirstName+N','
FROM Employees e
SELECT LEFT(@name,LEN(@name)-1);

-- 10.* Write a T-SQL script that shows for each town a list of all employees that live in it. Sample output:
-- Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
-- Ottawa -> Jose Saraiva
CREATE TABLE UsersTowns (ID INT IDENTITY, FullName NVARCHAR(50), TownName NVARCHAR(50))
INSERT INTO UsersTowns
SELECT e.FirstName + ' ' + e.LastName, t.Name
                FROM Employees e
                        INNER JOIN Addresses a
                                ON a.AddressID = e.AddressID
                        INNER JOIN Towns t
                                ON t.TownID = a.TownID
                GROUP BY t.Name, e.FirstName, e.LastName

-- Nested cursors to fetch info
DECLARE @name NVARCHAR(50)
DECLARE @town NVARCHAR(50)
 
DECLARE empCursor1 CURSOR READ_ONLY FOR
        SELECT DISTINCT ut.TownName
                FROM UsersTowns ut     
 
OPEN empCursor1
FETCH NEXT FROM empCursor1
        INTO @town
 
        WHILE @@FETCH_STATUS = 0
        BEGIN
                PRINT @town
 
                DECLARE empCursor2 CURSOR READ_ONLY FOR
                        SELECT ut.FullName
                        FROM UsersTowns ut
                                WHERE ut.TownName = @town
                OPEN empCursor2
                       
                FETCH NEXT FROM empCursor2
                        INTO @name
                               
                        WHILE @@FETCH_STATUS = 0
                        BEGIN
                                PRINT '   ' + @name
                                FETCH NEXT FROM empCursor2 INTO @name
                        END
 
                        CLOSE empCursor2
                        DEALLOCATE empCursor2
                FETCH NEXT FROM empCursor1 INTO @town
        END
 
CLOSE empCursor1
DEALLOCATE empCursor1



-- One more version of HOMEWORK !!!!!!!---------------------------------------------------
------------------------------------------------------------------------------------------

/** 
  * 5. Add two more stored procedures WithdrawMoney( AccountId, money) 
  * and DepositMoney (AccountId, money) that operate in transactions.
  */

CREATE PROCEDURE ups_WithdrawMoney(@accountId int, @money money)
AS
	BEGIN TRANSACTION
	DECLARE @moneyInAccount MONEY = 
		(SELECT Balance FROM Accounts
		 WHERE AccountId = @accountId)
	IF(@moneyInAccount >= @money)
		BEGIN
			UPDATE Accounts
			SET Balance = Balance - @money
			WHERE AccountId = @accountId
			COMMIT
		END
	ELSE
		BEGIN
			RAISERROR ('Not enough money in account.', 16, 1)
            ROLLBACK TRAN
		END
GO

EXEC ups_WithdrawMoney 2, 3000
GO

CREATE PROCEDURE ups_DepositMoney(@accountId int, @money money)
AS
	BEGIN TRANSACTION
	BEGIN
		UPDATE Accounts
		SET Balance = Balance + @money
		WHERE AccountId = @accountId
		COMMIT
	END
GO

EXEC ups_DepositMoney 2, 3000

/**
  * 6. Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
  * Add a trigger to the Accounts table that enters a new entry into 
  * the Logs table every time the sum on an account changes
  */

CREATE TABLE Logs 
(
	LogId int IDENTITY,
	CONSTRAINT PK_LogId PRIMARY KEY(LogId),
	AccountId int NOT NULL,
	CONSTRAINT FK_AccountId FOREIGN KEY(AccountId)
                REFERENCES Accounts(AccountId),
	OldSum MONEY NOT NULL
	DEFAULT 0,
	NewSum MONEY NOT NULL
	DEFAULT 0,
	ChangeTime DATETIME NOT NULL
	DEFAULT GETDATE()
)
GO

CREATE TRIGGER tr_BalanceUpdate ON Accounts FOR UPDATE
AS
	DECLARE @accountId int = (SELECT AccountId FROM inserted)
	DECLARE @oldSum MONEY = (SELECT Balance FROM deleted)
	DECLARE @newSum MONEY = (SELECT Balance FROM inserted)
	INSERT INTO Logs
	(AccountId, OldSum, NewSum)
	VALUES 
		(@accountId, @oldSum, @newSum)
GO

EXEC ups_DepositMoney 2, 3000
EXEC ups_DepositMoney 5, 3000

SELECT * FROM Logs

/**
  * 7. Define a function in the database SoftUni that returns all Employee's names 
  * (first or middle or last name) and all town's names that are comprised of given set of letters. 
  * Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
  */
USE SoftUni
GO

ALTER FUNCTION ufn_ContainsLetters (@setOfCharacters nvarchar(200), @word nvarchar(200))
RETURNS BIT
AS
BEGIN
	DECLARE @charIndex INT = 1
	DECLARE @containsLetters BIT = 0
	WHILE(@charIndex <= LEN(@word))
		BEGIN
			IF (NOT(@setOfCharacters LIKE ('%' + SUBSTRING(@word, @charIndex, 1) + '%')) AND (@word IS NOT NULL))
				BEGIN
					RETURN 0
				END
			SET @charIndex = @charIndex + 1
		END
	RETURN 1
END
GO


ALTER PROC usp_GetNameAndTownsMatchingCharacterSet(@setOfCharacters nvarchar(200))
AS
BEGIN
	SELECT e.FirstName, e.MiddleName, e.LastName, t.Name as Town
	FROM Employees e
		JOIN Addresses a
			ON e.AddressID = a.AddressID
		JOIN Towns t
			ON a.AddressID = t.TownID 
	WHERE 
		([dbo].ufn_ContainsLetters(@setOfCharacters, FirstName) = 1 OR 
		[dbo].ufn_ContainsLetters(@setOfCharacters, MiddleName) = 1 OR
		[dbo].ufn_ContainsLetters(@setOfCharacters, LastName) = 1) OR
		[dbo].ufn_ContainsLetters(@setOfCharacters, t.Name) = 1
END
GO

EXEC usp_GetNameAndTownsMatchingCharacterSet 'oistmiahf'
GO

/**
  * 8. Using database cursor write a T-SQL script that scans all employees and their 
  * addresses and prints all pairs of employees that live in the same town.
  */

DECLARE empCursor CURSOR READ_ONLY FOR
 
SELECT e1.FirstName, e1.LastName, t1.Name, e2.FirstName, e2.LastName
FROM Employees e1
	JOIN Addresses a1
		ON e1.AddressID = a1.AddressID
	JOIN Towns t1
		ON a1.TownID = t1.TownID,
		Employees e2
		JOIN Addresses a2
			ON e2.AddressID = a2.AddressID
		JOIN Towns t2
			ON a2.TownID = t2.TownID
WHERE t1.Name = t2.Name AND 
	e1.EmployeeID <> e2.EmployeeID
ORDER BY e1.FirstName, e2.FirstName
 
OPEN empCursor
DECLARE @firstName1 NVARCHAR(50)
DECLARE @lastName1 NVARCHAR(50)
DECLARE @town NVARCHAR(50)
DECLARE @firstName2 NVARCHAR(50)
DECLARE @lastName2 NVARCHAR(50)
FETCH NEXT FROM empCursor
        INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
 
WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT @firstName1 + ' ' + @lastName1 +
				'     ' + @town + '      ' + @firstName2 + ' ' + @lastName2
		FETCH NEXT FROM empCursor
				INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
	END
 
CLOSE empCursor
DEALLOCATE empCursor


/**
  * 10. Define a .NET aggregate function StrConcat that takes as input a sequence of strings and 
  * return a single string that consists of the input strings separated by ','. 
  * For example the following SQL statement should return a single string:
  * SELECT StrConcat(FirstName + ' ' + LastName)
  * FROM Employees
  */

IF OBJECT_ID('dbo.StrConcat') IS NOT NULL DROP Aggregate StrConcat 
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
       DROP assembly concat_assembly; 
GO      

CREATE Assembly concat_assembly 
   AUTHORIZATION dbo 
   FROM 'D:\Projects\SoftUni\Databases\Transact-SQL\StrConcat.dll' /* <= Here you put the absolute path to the dll*/
   WITH PERMISSION_SET = SAFE; 
GO 

CREATE AGGREGATE dbo.StrConcat ( 

    @Value NVARCHAR(MAX) 
  , @Delimiter NVARCHAR(4000) 

) RETURNS NVARCHAR(MAX) 
EXTERNAL Name concat_assembly.StrConcat; 
GO

sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO

SELECT dbo.StrConcat(FirstName + ' ' + LastName, ',') 
FROM Employees
