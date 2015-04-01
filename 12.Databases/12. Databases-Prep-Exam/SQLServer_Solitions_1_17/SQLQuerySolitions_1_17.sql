USE [Ads]
GO
-- 1.Display all ad titles in ascending order. Submit for evaluation the result grid with headers.
SELECT Title
	FROM Ads 
ORDER BY Title ASC;

-- 2.Find all ads created between 26-December-2014 (00:00:00) and 1-January-2015 (23:59:59) sorted by date.  
SELECT [Title], [Date]
	FROM Ads 
	WHERE [Date] BETWEEN '2014-12-26 00:00:00' AND '2015-01-01 23:59:59'
ORDER BY [Date];

-- 3.Display all ad titles and dates along with a column named "Has Image" holding "yes" or "no" for all ads sorted by their Id. 
SELECT Title, [Date], (case when ImageDataURL IS NULL then 'yes' else 'no' end) AS [Has Image]
	FROM Ads
ORDER BY Id; 

-- 4.Find all ads that have no town, no category or no image sorted by Id. Show all their data. 
SELECT *
	FROM Ads
	WHERE TownId IS NULL OR CategoryId IS NULL OR ImageDataURL IS NULL 
ORDER BY Id;

-- 5.Find all ads along with their towns sorted by Id. Display the ad title and town (even when there is no town). 
-- Name the columns exactly like in the table below. 
SELECT a.Title, t.Name AS Town
	FROM Ads a LEFT JOIN Towns t
	ON a.TownId = t.Id
ORDER BY a.Id;

-- 6.Find all ads along with their categories, towns and statuses sorted by Id. 
-- Display the ad title, category name, town name and status.
-- Include all ads without town or category or status. Name the columns exactly like in the table below. 
SELECT a.Title, c.Name AS [CategoryName], t.Name AS [TownName], st.Status AS [Status]
	FROM Ads a 
		LEFT JOIN Towns t
		ON a.TownId = t.Id
		LEFT JOIN Categories c
		ON a.CategoryId = c.Id
		JOIN AdStatuses st
		ON a.StatusId = st.Id
ORDER BY a.Id;

-- 7.Find all Published ads from Sofia, Blagoevgrad or Stara Zagora, along with their category, town and status sorted by title. 
-- Display the ad title, category name, town name and status. Name the columns exactly like in the table below.
SELECT a.Title, c.Name AS [CategoryName], t.Name AS [TownName], st.Status AS [Status]
	FROM Ads a
	    JOIN Towns t
		ON a.TownId = t.Id
		JOIN Categories c
		ON a.CategoryId = c.Id
		JOIN AdStatuses st
		ON a.StatusId = st.Id
    WHERE st.Status = 'Published' AND t.Name IN ('Sofia', 'Blagoevgrad', 'Stara Zagora')
ORDER BY a.Title;

-- 8.Find the dates of the earliest and the latest ads. Name the columns exactly like in the table below.
SELECT Min(Date) AS [MinDate], MAX(Date) AS [MaxDate]
	FROM Ads
	
-- 9.Find the latest 10 ads sorted by date in descending order. 
-- Display for each ad its title, date and status.
SELECT TOP 10 a.Title, a.[Date], st.Status
	FROM Ads a JOIN AdStatuses st
	ON a.StatusId = st.Id
ORDER BY a.[Date] DESC;

-- 10.Find all not published ads, created in the same month and year like the earliest ad.
-- Display for each ad its id, title, date and status. Sort the results by Id. 
SELECT a.Id, a.Title, a.Date, st.Status
	FROM Ads a JOIN AdStatuses st
	ON a.StatusId = st.Id
	WHERE st.Status <> 'Published' 
	    AND MONTH(a.Date) = (SELECT MONTH(MIN(DATE)) FROM Ads)
		AND YEAR(a.Date) = (SELECT YEAR(MIN(DATE)) FROM Ads)
ORDER BY a.Id;

-- 11.Display the count of ads in each status. Sort the results by status.
SELECT st.Status, COUNT(*) AS [Count]
	FROM Ads a JOIN AdStatuses st
	ON a.StatusId = st.Id
GROUP BY st.Status;

-- 12.Display the count of ads for each town and each status.
-- Sort the results by town, then by status. Display only non-zero counts.
SELECT t.Name AS [Town Name], st.Status, COUNT(*) AS [Count]
	FROM Ads a 
		JOIN AdStatuses st
		ON a.StatusId = st.Id
		JOIN Towns t
		ON a.TownId = t.Id
GROUP BY t.Name, st.Status
ORDER BY t.Name, st.Status;

-- 13.Find the count of ads for each user. Display the username, ads count and "yes" or "no" depending 
-- on whether the user belongs to the role "Administrator".
-- Sort the results by username. Display all users, including the users who have no ads. 
SELECT us.UserName, COUNT(a.Id) AS [AdsCount], (CASE WHEN admins.UserName IS NULL then 'no' else 'yes' end) AS [IsAdministrator]
	FROM AspNetUsers us
		LEFT JOIN Ads a
		ON us.Id = a.OwnerId 
        LEFT JOIN (SELECT  u.UserName FROM AspNetUsers u
			        JOIN AspNetUserRoles ur ON ur.UserId = u.Id
			        JOIN AspNetRoles r ON ur.RoleId = r.Id WHERE r.Name = 'Administrator') 
			       AS admins ON us.UserName = admins.UserName                          
GROUP BY us.UserName, admins.UserName
ORDER BY us.UserName;

-- 14.Find the count of ads for each town. Display the ads count and town name or "(no town)" for the ads without a town.
-- Display only the towns, which hold 2 or 3 ads. Sort the results by town name. 
SELECT COUNT(a.Id) AS [AdsCount],
	 (CASE WHEN t.Name IS NULL then '(no town)' else t.Name end) AS [Town]
	FROM Ads a 
	LEFT JOIN Towns t
	ON a.TownId = t.Id
	GROUP BY t.Id, t.Name
	HAVING COUNT(a.Id) IN (2,3)
ORDER BY t.Name;

-- 15.Consider the dates of the ads. Find among them all pairs of different dates, such that the second date is no later than 12 hours
-- after the first date. Sort the dates in increasing order by the first date, then by the second date.
SELECT A.date AS [FirstDate], B.Date AS [SecondDate]
	FROM Ads A JOIN Ads B
	ON A.Date < B.Date
	WHERE DATEDIFF(hour, A.Date, B.Date) < 12
ORDER BY A.Date, B.Date ASC;

-- 16.Ads by Country
-- 1.Create a table Countries(Id, Name). Use auto-increment for the primary key. Add a new column CountryId in the Towns 
--  table to link each town to some country (non-mandatory link). Create a foreign key between the Countries and Towns tables.
 CREATE TABLE Countries(
	Id int NOT NULL IDENTITY PRIMARY KEY,
	Name nvarchar(50) NOT NULL
)
GO

ALTER TABLE Towns ADD CountryId int
GO

ALTER TABLE Towns ADD CONSTRAINT FK_Towns_Countries
FOREIGN KEY(CountryId) REFERENCES Countries(Id)
GO

-- 2.Execute the following SQL script (it should pass without any errors):

INSERT INTO Countries(Name) VALUES ('Bulgaria'), ('Germany'), ('France')
UPDATE Towns SET CountryId = (SELECT Id FROM Countries WHERE Name='Bulgaria')
INSERT INTO Towns VALUES
('Munich', (SELECT Id FROM Countries WHERE Name='Germany')),
('Frankfurt', (SELECT Id FROM Countries WHERE Name='Germany')),
('Berlin', (SELECT Id FROM Countries WHERE Name='Germany')),
('Hamburg', (SELECT Id FROM Countries WHERE Name='Germany')),
('Paris', (SELECT Id FROM Countries WHERE Name='France')),
('Lyon', (SELECT Id FROM Countries WHERE Name='France')),
('Nantes', (SELECT Id FROM Countries WHERE Name='France'))

-- 3.Write and execute a SQL command that changes the town to "Paris" for all ads created at Friday
UPDATE Ads 
   SET TownId = (SELECT t.Id FROM Towns t WHERE t.Name = 'Paris')
   WHERE(DATENAME(dw, Date) = 'Friday')

-- 4.Write and execute a SQL command that changes the town to "Hamburg" for all ads created at Thursday.
UPDATE Ads 
   SET TownId = (SELECT t.Id FROM Towns t WHERE t.Name = 'Hamburg')
   WHERE (DATENAME(WEEKDAY, Date) = 'Thursday')

-- 5.Delete all ads created by user in role "Partner".
DELETE FROM Ads 
	 WHERE OwnerId IN (SELECT u.Id FROM AspNetUsers u
					    JOIN AspNetUserRoles ur ON ur.UserId = u.Id
					    JOIN AspNetRoles r ON ur.RoleId = r.Id 
						WHERE r.Name = 'Partner')

-- 6.Add a new add holding the following information: Title="Free Book", 
-- Text="Free C# Book", Date={current date and time}, Owner="nakov", Status="Waiting Approval".		         
 INSERT INTO Ads([Title], [Text], [Date], [OwnerId], [StatusId])
 VALUES('Free Book','Free C# Book', GETDATE(), '39b7333d-664b-428d-9e11-4cde699d5e5e', 2)

-- 7.Find the count of ads for each town. Display the ads count, the town name and the country name.
-- Include also the ads without a town and country. Sort the results by town, then by country.
SELECT t.Name AS [Town], c.Name AS [Country], COUNT(a.Id) AS [AdsCount]
	FROM  Ads a
	FULL OUTER JOIN  Towns t
	ON a.TownId = t.Id
	FULL OUTER JOIN Countries c
	ON t.CountryId = c.Id
GROUP BY t.Name, c.Name
ORDER BY t.Name, c.Name	

SELECT *
FROM Ads
WHERE TownId IS NULL

-- 17.Create a View and a Stored Function
-- 1.Create a view "AllAds" in the database that holds information about ads: id, title, author (username), date, 
-- town name, category name and status, sorted by id.
USE Ads
GO

IF (OBJECT_ID('AllAds') IS NOT NULL) DROP VIEW AllAds
GO

CREATE VIEW AllAds
 AS
 SELECT a.Id, a.Title, u.UserName AS [Author], a.Date, t.Name AS [Town], c.Name AS [Category], s.Status
	FROM Ads a 
		JOIN AspNetUsers u
		ON a.OwnerId = u.Id
		LEFT JOIN Towns t
		ON a.TownId = t.Id
		LEFT JOIN Categories c
		ON a.CategoryId = c.Id
		JOIN AdStatuses s
		ON a.StatusId = s.Id
GO

SELECT * FROM AllAds

-- 2.Using the view above, create a stored function "fn_ListUsersAds" that returns a table, holding all users
-- in descending order as first column, along with all dates of their ads (in ascending order) in format "yyyyMMdd",
-- separated by "; " as second column.
IF (object_id(N'fn_ListUsersAds') IS NOT NULL)
DROP FUNCTION fn_ListUsersAds
GO

CREATE FUNCTION fn_ListUsersAds()      -- func vrahsta table
		RETURNS @tbl_UsersAds TABLE(
			UserName NVARCHAR(MAX),
			AdDates NVARCHAR(MAX)  )
		AS
		BEGIN

			DECLARE UsersCursor CURSOR READ_ONLY FAST_FORWARD FOR    -- deklar na crusor koito e userite ot tabliza AspUsers
			SELECT 	UserName FROM AspNetUsers                        -- podredeni po DESC
			ORDER BY UserName DESC;

			OPEN UsersCursor;
			DECLARE @username NVARCHAR(MAX);                       -- krusora ot usari da hodi po vseki edin
			FETCH NEXT FROM UsersCursor INTO @username;            -- i go dava kato @username
			                                                     
				WHILE (@@FETCH_STATUS = 0)   -- dokato ima useri v krusora
					BEGIN
						DECLARE @ads NVARCHAR(MAX) = NULL;  -- promenliva za datata
						SELECT 	@ads = CASE                 -- s tozi select ia namirame 
										WHEN @ads IS NULL THEN CONVERT(NVARCHAR(MAX), Date, 112)
										ELSE @ads + '; ' + CONVERT(NVARCHAR(MAX), Date, 112)
										END
						FROM AllAds
						WHERE Author = @username  -- usera ot kursora
						ORDER BY Date;
				
						INSERT INTO @tbl_UsersAds VALUES (@username, @ads)  -- puhame v retarnatata tablicata 

						FETCH NEXT FROM UsersCursor INTO @username; -- mestime krusora
				   END;
			CLOSE UsersCursor;
			DEALLOCATE UsersCursor;
		RETURN;
		END
GO

SELECT 	* FROM fn_ListUsersAds();
