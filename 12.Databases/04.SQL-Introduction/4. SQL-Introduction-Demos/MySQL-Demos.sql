USE world;

SELECT * FROM city LIMIT 100, 10;

---------------------------------------------------------------------

SHOW DATABASES;

---------------------------------------------------------------------

USE world;

---------------------------------------------------------------------

SHOW TABLES;

---------------------------------------------------------------------

CHECK TABLE city;

REPAIR TABLE city;

OPTIMIZE TABLE city;

---------------------------------------------------------------------

DESCRIBE city;

---------------------------------------------------------------------

REPLACE INTO city(ID, Name, CountryCode, District, Population)
VALUES(10000, 'Kaspichan', 'BGR', 'Shoumen', 3300);

SELECT * FROM city WHERE CountryCode = 'BGR';

REPLACE INTO city(ID, Name, CountryCode, District, Population)
VALUES(10000, 'Kaspichan City', 'BGR', 'Shoumen', 3300);

SELECT * FROM city WHERE CountryCode = 'BGR';

---------------------------------------------------------------------

