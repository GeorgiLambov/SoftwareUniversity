USE Forum
GO

-- 1.Display all question titles in ascending order. Name the columns exactly like in the table below.
SELECT Title
FROM Questions
ORDER BY Title;

-- 2.Find all answers created between 15-June-2012 (00:00:00) and 21-Mart-2013 (23:59:59) sorted by date, then by id. 
SELECT Content, CreatedOn
	FROM Answers
	WHERE CreatedOn BETWEEN '2012-06-15 00:00:00' AND '2013-03-21 23:59:59'
ORDER BY CreatedOn, Id;

-- 3.Display usernames and last names along with a column named "Has Phone" holding "1" or "0" for all 
-- users sorted by their last name, then by id.
SELECT Username, LastName, (case when PhoneNumber IS NULL then '0' else '1' end) AS [Has Phone]
	FROM Users
ORDER BY LastName, Id

-- 4.Find all questions along with their user sorted by Id. Display the question title and author username.
SELECT q.Title AS [Question Title], u.Username AS [Author]
	FROM Questions q JOIN Users u
	ON q.UserId = u.Id

-- 5*.Find all answers along with their questions, along with question category, along with question author sorted by Category Name,
-- then by Answer Author, then by CreatedOn. Display the answer content, created on, question title, category name and author username. 
SELECT a.Content AS [Answer Content], a.CreatedOn, u.Username AS [Answer Author], q.Title AS [Question Title], c.Name AS [Category Name]
	FROM Answers a 
	JOIN Questions q
	ON a.QuestionId = q.Id
	JOIN Categories c
	ON q.CategoryId = c.Id
	JOIN Users u 
	ON u.Id = a.UserId
ORDER BY c.Name, u.Username, a.CreatedOn

-- 6.Find all categories along with their questions sorted by category name and question title.
-- Display the category name, question title and created on columns.
SELECT c.Name, q.Title, q.CreatedOn
	FROM Categories c LEFT JOIN Questions q
	ON c.Id = q.CategoryId
ORDER BY c.Name

-- 7*.Find all users that have no phone and no questions sorted by RegistrationDate. Show all user data. 
SELECT u.Id, u.Username, u.FirstName, u.PhoneNumber, u.RegistrationDate, u.Email
	FROM Users u
	WHERE PhoneNumber IS NULL 
	AND u.Id <> ALL(SELECT UserId FROM Questions WHERE UserId IS NOT NULL)
ORDER BY RegistrationDate

-- 8.Find the dates of the earliest answer for 2012 year and the latest answer for 2014 year.
SELECT MIN(CreatedOn) AS [MinDate], MAX(CreatedOn) AS MaxDate
	FROM Answers
	WHERE CreatedOn BETWEEN '2012-01-01' and '2012-12-31'
		OR CreatedOn BETWEEN '2014-01-01' AND '2014-12-31'

-- 9.Find the last 10 answers sorted by date of creation in descending order. Display for each ad its content, date and author.	
SELECT TOP 10 Content, CreatedOn, Users.Username
	FROM Answers, Users
	WHERE Answers.UserId = Users.Id
ORDER BY CreatedOn

-- 10.Find the answers which is hidden from the first and last month where there are any published answer, 
-- from the last year where there are any published answers. Display for each ad its answer content, question title and category name. 
SELECT a.Content AS [Answer Content], q.Title  AS [Question], c.Name AS [Category]
	FROM Answers a 
	JOIN Questions q
	ON a.QuestionId = q.Id
	JOIN Categories c
	ON q.CategoryId = c.Id
	WHERE a.IsHidden = '1' 
	AND YEAR(a.CreatedOn) = (SELECT YEAR(MAX(CreatedOn)) FROM Answers)
		AND (MONTH(a.CreatedOn) = (SELECT MONTH(MIN(CreatedOn)) FROM Answers)
		OR MONTH(a.CreatedOn) =(SELECT MONTH(MAX(CreatedOn)) FROM Answers))
ORDER BY c.Name

-- 11.Display the count of answers in each category. Sort the results by answers count in descending order.
SELECT c.Name AS [Category], COUNT(a.Id) AS [Answers Count]
	 FROM Categories c 
	 LEFT JOIN Questions q
	 ON c.Id = q.CategoryId
	 LEFT JOIN Answers a
	 ON q.Id = a.QuestionId
GROUP BY C.Name
ORDER BY [Answers Count] DESC

-- 12.Display the count of answers for category and each username. 
-- Sort the results by Answers count. Display only non-zero counts. Display only users with phone number. 
SELECT c.Name AS [Category], u.Username, u.PhoneNumber, COUNT(a.Id) AS [Answers Count]
	 FROM Categories c 
	 LEFT JOIN Questions q
	 ON c.Id = q.CategoryId
	 JOIN Answers a
	 ON q.Id = a.QuestionId
	 JOIN Users u 
	 ON a.UserId = u.Id
	 WHERE u.PhoneNumber IS NOT NULL 
GROUP BY C.Name, u.Username, u.PhoneNumber
ORDER BY [Answers Count] DESC


-- 13.Answers for the users from town
-- 1.Create a table Towns(Id, Name). Use auto-increment for the primary key. Add a new column TownId in the Users table
-- to link each user to some town (non-mandatory link). Create a foreign key between the Users and Towns tables.
CREATE TABLE Towns(
	Id int NOT NULL IDENTITY PRIMARY KEY,
	Name nvarchar(50) NOT NULL
)
GO

ALTER TABLE Users ADD TownId int
GO

ALTER TABLE Users ADD CONSTRAINT FK_Users_Towns
FOREIGN KEY(TownId) REFERENCES Towns(Id)
GO

-- 2.Execute the following SQL script (it should pass without any errors):
INSERT INTO Towns(Name) VALUES ('Sofia'), ('Berlin'), ('Lyon')
UPDATE Users SET TownId = (SELECT Id FROM Towns WHERE Name='Sofia')
INSERT INTO Towns VALUES
('Munich'), ('Frankfurt'), ('Varna'), ('Hamburg'), ('Paris'), ('Lom'), ('Nantes')

-- 3.Write and execute a SQL command that changes the town to "Paris" for all users with registration date at Friday.
UPDATE Users
	SET TownId = (SELECT t.Id FROM Towns t WHERE t.Name = 'Paris')
	WHERE (DATENAME(WEEKDAY, RegistrationDate) = 'Friday')

-- 4.Write and execute a SQL command that changes the question to “Java += operator” 
-- of Answers, answered at Monday or Sunday in February.
UPDATE Answers
	SET QuestionId = (SELECT Id FROM Questions WHERE Title = 'Java += operator')
	WHERE ((DATENAME(WEEKDAY, CreatedOn) = 'Monday') OR
		   (DATENAME(WEEKDAY, CreatedOn) = 'Sunday')) AND
		   (DATENAME(MONTH, CreatedOn) = 'February')

-- 5.Delete all answers with negative sum of votes.
BEGIN TRAN

CREATE TABLE [#AnswerIds](
	AnswerID int NOT NULL
)

INSERT INTO [#AnswerIds]
	SELECT a.Id FROM Answers a 
				JOIN Votes v
				ON a.Id = v.AnswerId
				GROUP BY a.Id
				HAVING  SUM(v.Value) < 0

DELETE FROM Votes
	FROM Votes v JOIN [#AnswerIds] a
	ON v.AnswerId = a.AnswerID

DELETE FROM Answers
	FROM Answers a
	WHERE a.Id IN (SELECT AnswerID FROM [#AnswerIds])

DROP TABLE [#AnswerIds]

COMMIT TRAN

-- 6.Add a new question holding the following information: Title="Fetch NULL values in PDO query", 
-- Content="When I run the snippet, NULL values are converted to empty strings. How can fetch NULL values?", 
-- CreatedOn={current date and time}, Owner="darkcat", Category="Databases". 
INSERT INTO Questions([Title], [Content], [CreatedOn], [CategoryId], [UserId])
VALUES ('Fetch NULL values in PDO query', 
		'When I run the snippet, NULL values are converted to empty strings. How can fetch NULL values?',
		GETDATE(),
		(SELECT Id FROM Categories WHERE Name = 'Databases' ),
		(SELECT Id FROM Users WHERE Username = 'darkcat'))

-- 7.Find the count of the answers for the users from town. Display the town name, username and answers count. 
-- Sort the results by answers count in descending order, then by username. 
SELECT t.Name AS [Town], u.Username, COUNT(a.UserId) AS [AnswersCount]
	FROM Users u 
	FULL JOIN Towns t
	ON u.TownId = t.Id
	FULL JOIN Answers a
	ON u.Id = a.UserId
GROUP BY t.Name, u.Username
ORDER BY AnswersCount DESC, u.Username 


-- 14.Create a View and a Stored Function
-- 1.Create a view "AllQuestions" in the database that holds information about questions and users (use RIGHT OUTER JOIN):
USE Forum
GO

CREATE VIEW AllQuestions
 AS
 SELECT u.Id AS [UId], u.Username, u.FirstName, u.LastName, u.Email, u.PhoneNumber, u.RegistrationDate,
		q.Id AS [QId], q.Title, q.Content, q.CategoryId, q.UserId, q.CreatedOn 
	FROM Questions q RIGHT JOIN Users u
	ON q.UserId = u.Id
GO

SELECT * FROM AllQuestions

-- 2.Using the view above, create a stored function "fn_ListUsersQuestions" that returns a table,
-- holding all users in descending order as first column, along with all titles of their questions (in ascending order), 
-- separated by ", " as second column.
IF (object_id(N'fn_ListUsersQuestions') IS NOT NULL)
DROP FUNCTION fn_ListUsersQuestions
GO

CREATE FUNCTION fn_ListUsersQuestions()
		RETURNS @tbl_UsersQuestions TABLE(
			UserName NVARCHAR(MAX),
			Questions NVARCHAR(MAX)  )
		AS
		BEGIN

			DECLARE UsersCursor CURSOR FOR 
			SELECT DISTINCT	Username 
			FROM AllQuestions
			ORDER BY Username;

			OPEN UsersCursor;
			DECLARE @username NVARCHAR(MAX);
			FETCH NEXT FROM UsersCursor INTO @username;
			
			WHILE @@FETCH_STATUS = 0 
				BEGIN
			        DECLARE @question NVARCHAR(MAX) = NULL;
			        SELECT 	@question = CASE 
									WHEN @question IS NULL THEN CONVERT(NVARCHAR(MAX), Title, 112)
									ELSE @question + ', ' + CONVERT(NVARCHAR(MAX), Title, 112)
									END
					FROM AllQuestions
					WHERE Username = @username
					ORDER BY Title DESC;
				
					INSERT INTO @tbl_UsersQuestions VALUES (@username, @question)

					FETCH NEXT FROM UsersCursor INTO @username;
		       END;
		CLOSE UsersCursor;
		DEALLOCATE UsersCursor;
		RETURN;
		END
GO

SELECT * FROM fn_ListUsersQuestions()