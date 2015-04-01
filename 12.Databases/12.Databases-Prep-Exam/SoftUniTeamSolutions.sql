SELECT
	Title
FROM Ads
ORDER BY Title

---------------------------------------------------------
--2
SELECT
	Title,
	[Date]
FROM Ads
WHERE [Date] >= '26-Dec-2014'
AND [Date] < '2-Jan-2015'
ORDER BY [Date]

---------------------------------------------------------
--3
SELECT
	Title,
	[Date],
	CASE
		WHEN ImageDataUrl IS NOT NULL THEN 'no'
		WHEN ImageDataUrl IS NULL THEN 'yes'
	END
	AS [Has Image]
FROM Ads
ORDER BY Id

---------------------------------------------------------
--4
SELECT
	*
FROM Ads
WHERE TownId IS NULL
OR CategoryId IS NULL
OR ImageDataURL IS NULL
ORDER BY Id

---------------------------------------------------------
--5
SELECT
	a.Title,
	t.Name AS Town
FROM Ads a
LEFT JOIN Towns t
	ON a.TownId = t.Id
ORDER BY a.Id

---------------------------------------------------------
--6
SELECT
	a.Title,
	c.Name AS CategoryName,
	t.Name AS TownName,
	s.Status
FROM Ads a
LEFT JOIN Towns t
	ON a.TownId = t.Id
LEFT JOIN Categories c
	ON a.CategoryId = c.Id
LEFT JOIN AdStatuses s
	ON a.StatusId = s.Id
ORDER BY a.Id

---------------------------------------------------------
--7
SELECT
	a.Title,
	c.Name AS CategoryName,
	t.Name AS TownName,
	s.Status
FROM Ads a
JOIN Towns t
	ON a.TownId = t.Id
JOIN Categories c
	ON a.CategoryId = c.Id
JOIN AdStatuses s
	ON a.StatusId = s.Id
WHERE t.Name IN ('Sofia', 'Blagoevgrad', 'Stara Zagora')
AND s.Status = 'Published'
ORDER BY a.Title

---------------------------------------------------------
--8
SELECT
	MIN(Date) AS MinDate,
	MAX(Date) AS MaxDate
FROM Ads

---------------------------------------------------------
--9
SELECT TOP 10
	Title,
	Date,
	Status
FROM Ads a
JOIN AdStatuses s
	ON a.StatusId = s.Id
ORDER BY Date DESC

---------------------------------------------------------
--10
SELECT
	a.Id,
	Title,
	Date,
	Status
FROM Ads a
JOIN AdStatuses s
	ON a.StatusId = s.Id
WHERE MONTH(Date) = (SELECT
	MONTH(MIN(Date))
FROM Ads)
AND YEAR(Date) = (SELECT
	YEAR(MIN(Date))
FROM Ads)
AND Status <> 'Published'
ORDER BY a.Id

---------------------------------------------------------
--11
SELECT
	Status,
	COUNT(*) Count
FROM Ads a
JOIN AdStatuses s
	ON a.StatusId = s.Id
GROUP BY Status
ORDER BY Status

---------------------------------------------------------
--12
SELECT
	t.Name AS [Town Name],
	Status,
	COUNT(*) Count
FROM Ads a
JOIN AdStatuses s
	ON a.StatusId = s.Id
JOIN Towns t
	ON a.TownId = t.Id
GROUP BY	t.Name,
			Status
ORDER BY t.Name, Status

---------------------------------------------------------
--13
SELECT
	MIN(u.UserName) AS UserName,
	COUNT(a.Id) AS AdsCount,
	(CASE
		WHEN admins.UserName IS NULL THEN 'no'
		ELSE 'yes'
	END) AS IsAdministrator
FROM AspNetUsers u
LEFT JOIN Ads a
	ON u.Id = a.OwnerId
LEFT JOIN (SELECT DISTINCT
	u.UserName
FROM AspNetUsers u
LEFT JOIN AspNetUserRoles ur
	ON ur.UserId = u.Id
LEFT JOIN AspNetRoles r
	ON ur.RoleId = r.Id
WHERE r.Name = 'Administrator') AS admins
	ON u.UserName = admins.UserName
GROUP BY	OwnerId,
			u.UserName,
			admins.UserName
ORDER BY u.UserName

---------------------------------------------------------
-- 14
SELECT
	COUNT(a.Id) AS AdsCount,
	ISNULL(t.Name, '(no town)') AS Town
FROM Ads a
LEFT JOIN Towns t
	ON a.TownId = t.Id
GROUP BY t.Name
HAVING COUNT(a.Id) BETWEEN 2 AND 3
ORDER BY t.Name

---------------------------------------------------------
--15
SELECT
	a1.Date AS FirstDate,
	a2.Date AS SecondDate
FROM	Ads a1,
		Ads a2
WHERE a2.Date > a1.Date
AND DATEDIFF(SECOND, a1.Date, a2.Date) < 12 * 60 * 60
ORDER BY a1.Date, a2.Date

---------------------------------------------------------
--16
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

INSERT INTO Countries (Name)
	VALUES ('Bulgaria'), ('Germany'), ('France')

UPDATE Towns
SET CountryId = (SELECT
	Id
FROM Countries
WHERE Name = 'Bulgaria')

INSERT INTO Towns
	VALUES ('Munich', (SELECT
		Id
	FROM Countries
	WHERE Name = 'Germany')),
	('Frankfurt', (SELECT
		Id
	FROM Countries
	WHERE Name = 'Germany')),
	('Berlin', (SELECT
		Id
	FROM Countries
	WHERE Name = 'Germany')),
	('Hamburg', (SELECT
		Id
	FROM Countries
	WHERE Name = 'Germany')),
	('Paris', (SELECT
		Id
	FROM Countries
	WHERE Name = 'France')),
	('Lyon', (SELECT
		Id
	FROM Countries
	WHERE Name = 'France')),
	('Nantes', (SELECT
		Id
	FROM Countries
	WHERE Name = 'France'))

UPDATE Ads
SET TownId = (SELECT
	Id
FROM Towns
WHERE Name = 'Paris')
WHERE DATENAME(WEEKDAY, Date) = 'Friday'

UPDATE Ads
SET TownId = (SELECT
	Id
FROM Towns
WHERE Name = 'Hamburg')
WHERE DATENAME(WEEKDAY, Date) = 'Thursday'

DELETE FROM Ads
	FROM Ads a
	JOIN AspNetUsers u
		ON a.OwnerId = u.Id
	JOIN AspNetUserRoles ur
		ON u.Id = ur.UserId
	JOIN AspNetRoles r
		ON r.Id = ur.RoleId
WHERE r.Name = 'Partner'

INSERT INTO Ads (Title, Text, Date, OwnerId, StatusId)
	VALUES ('Free Book', 'Free C# Book', GETDATE(), (SELECT
		Id
	FROM AspNetUsers
	WHERE UserName = 'nakov')
	, (SELECT
		Id
	FROM AdStatuses
	WHERE Status = 'Waiting Approval'))

SELECT
	t.Name AS Town,
	c.Name AS Country,
	COUNT(a.Id) AS AdsCount
FROM Ads a
FULL OUTER JOIN Towns t
	ON a.TownId = t.Id
FULL OUTER JOIN Countries c
	ON t.CountryId = c.Id
GROUP BY	t.Name,
			c.Name
ORDER BY t.Name, c.Name

---------------------------------------------------------
--17
ALTER VIEW AllAds
AS
SELECT
	a.Id,
	a.Title,
	u.UserName AS Author,
	a.Date,
	t.Name AS Town,
	c.Name AS Category,
	s.Status AS Status
FROM Ads a
LEFT JOIN Towns t
	ON a.TownId = t.Id
LEFT JOIN Categories c
	ON a.CategoryId = c.Id
LEFT JOIN AdStatuses s
	ON a.StatusId = s.Id
LEFT JOIN AspNetUsers u
	ON u.Id = a.OwnerId

---------------------------------------------------------
--17.2
IF (object_id(N'fn_ListUsersAds') IS NOT NULL)
DROP FUNCTION fn_ListUsersAds
GO

CREATE FUNCTION fn_ListUsersAds()
	RETURNS @tbl_UsersAds TABLE(
		UserName NVARCHAR(MAX),
		AdDates NVARCHAR(MAX)
	)
AS
BEGIN
	DECLARE UsersCursor CURSOR FOR SELECT
	UserName
FROM AspNetUsers
ORDER BY UserName DESC;
OPEN UsersCursor;
DECLARE @username NVARCHAR(MAX);
FETCH NEXT FROM UsersCursor INTO @username;
WHILE @@FETCH_STATUS = 0 BEGIN
DECLARE @ads NVARCHAR(MAX) = NULL;
SELECT
	@ads =
			CASE
				WHEN @ads IS NULL THEN CONVERT(NVARCHAR(MAX), Date, 112)
				ELSE @ads + '; ' + CONVERT(NVARCHAR(MAX), Date, 112)
			END
FROM AllAds
WHERE Author = @username
ORDER BY Date;

INSERT INTO @tbl_UsersAds
	VALUES (@username, @ads)

FETCH NEXT FROM UsersCursor INTO @username;
END;
CLOSE UsersCursor;
DEALLOCATE UsersCursor;
RETURN;
END
GO

SELECT
	*
FROM fn_ListUsersAds()

---------------------------------------------------------
--18
DROP DATABASE IF EXISTS `orders`;
CREATE DATABASE `orders` CHARACTER SET utf8 COLLATE utf8_unicode_ci;

USE ` orders`;

DROP TABLE IF EXISTS `products`;CREATE TABLE `products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`)
);

DROP TABLE IF EXISTS `customers`;CREATE TABLE `customers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
);

DROP TABLE IF EXISTS `orders`;CREATE TABLE `orders` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date` datetime NOT NULL,
  PRIMARY KEY (`id`)
);

DROP TABLE IF EXISTS `order_items`;CREATE TABLE `order_items` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `order_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `quantity` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_order_items_orders_idx` (`order_id`),
  KEY `fk_order_items_products_idx` (`product_id`),
  CONSTRAINT `fk_order_items_orders` FOREIGN KEY (`order_id`) REFERENCES `orders` (`id`) ON DELETE NO ACTION ON
UPDATE NO ACTION,
  CONSTRAINT `fk_order_items_products` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`) ON
DELETE NO ACTION ON
UPDATE NO ACTION
);

INSERT INTO `products` VALUES (1,'beer',1.20), (2,'cheese',9.50), (3,'rakiya',12.40), (4,'salami',6.33), (5,'tomatos',2.50), (6,'cucumbers',1.35), (7,'water',0.85), (8,'apples',0.75); INSERT INTO `customers` VALUES (1,'Peter'), (2,'Maria'), (3,'Nakov'), (4,'Vlado'); INSERT INTO `orders` VALUES (1,'2015-02-13 13:47:04'), (2,'2015-02-14 22:03:44'), (3,'2015-02-18 09:22:01'), (4,'2015-02-11 20:17:18'); INSERT INTO `order_items` VALUES (12,4,6,2.00), (13,3,2,4.00), (14,3,5,1.50), (15,2,1,6.00), (16,2,3,1.20), (17,1,2,1.00), (18,1,3,1.00), (19,1,4,2.00), (20,1,5,1.00), (21,3,1,4.00), (22,1,1,3.00); SELECT
	p.name AS product_name,
	COUNT(oi.product_id) AS num_orders,
	IFNULL(SUM(oi.quantity), 0) AS quantity,
	p.price,
	IFNULL(SUM(oi.quantity) * p.price, 0) AS total_price
FROM products p
LEFT JOIN order_items oi
	ON p.id = oi.product_id
LEFT JOIN orders o
	ON oi.order_id = o.id
GROUP BY	p.id,
			p.name,
			p.price
ORDER BY p.name

---------------------------------------------------------