--Use Northwind database. All questions are based on assumptions described by the Database Diagram sent to you yesterday. When inserting, make up info if necessary. Write query for each step. Do not use IDE. BE CAREFUL WHEN DELETING DATA OR DROPPING TABLE.

USE Northwind
Go

--1. Create a view named “view_product_order_[your_last_name]”, list all products and total ordered quantity for that product.

CREATE VIEW view_product_order_Shih AS
SELECT od.ProductID, SUM(od.Quantity) TotalQty
FROM [Order Details] od
GROUP BY od.ProductID

--2. Create a stored procedure “sp_product_order_quantity_[your_last_name]” that accept product id as an input and total quantities of order as output parameter.

CREATE PROC sp_product_order_quantity_Shih
@pid int,
@totalqty int out 
AS
BEGIN
SELECT @totalqty = p.TotalQty  FROM view_product_order_Shih p WHERE p.ProductID = @pid
END

--3. Create a stored procedure “sp_product_order_city_[your_last_name]” that accept product name as an input and top 5 cities that ordered most that product combined with the total quantity of that product ordered from that city as output.

CREATE PROC sp_product_order_city_Shih
@pname varchar(30),
@city varchar(30) out,
@total int out
AS
BEGIN
SELECT TOP 5 @city = c.City, @total = SUM(od.Quantity)
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON od.OrderID = o.OrderID JOIN Customers c ON c.CustomerID = o.CustomerID
WHERE p.ProductName = @pname
GROUP BY p.ProductName, c.City
END

--BEGIN
--DECLARE @Ccity varchar(20)
--DECLARE @num int
--EXEC sp_product_order_city_Shih 'Chai', @Ccity, @num output
--PRINT @Ccity + ' ' + @num
--END

--SELECT TOP 5 c.City, SUM(od.Quantity) TheSum
--FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON od.OrderID = o.OrderID JOIN Customers c ON c.CustomerID = o.CustomerID
--WHERE p.ProductID = 1
--GROUP BY p.ProductName, c.City
--ORDER BY SUM(od.Quantity) DESC



--4. Create 2 new tables “people_your_last_name” “city_your_last_name”. 
--City table has two records: {Id:1, City: Seattle}, {Id:2, City: Green Bay}. 
--People has three records: {id:1, Name: Aaron Rodgers, City: 2}, {id:2, Name: Russell Wilson, City:1}, {Id: 3, Name: Jody Nelson, City:2}. 
--Remove city of Seattle. If there was anyone from Seattle, put them into a new city “Madison”.
--Create a view “Packers_your_name” lists all people from Green Bay. 
--If any error occurred, no changes should be made to DB. (after test) Drop both tables and view.

CREATE TABLE city_Shih(
Id int primary key,
City varchar(20) NOT NULL
)

INSERT INTO city_Shih VALUES(1, 'Seattle')
INSERT INTO city_Shih VALUES(2, 'Green Bay')

CREATE TABLE people_Shih(
Id int primary key,
pName varchar(20) NOT NULL,
City int foreign key references city_Shih(Id) on delete set null
)

INSERT INTO people_Shih VALUES(1, 'Aaron Rodgers', 2)
INSERT INTO people_Shih VALUES(2, 'Russell Wilson', 1)
INSERT INTO people_Shih VALUES(3, 'Jody Nelson', 2)

DELETE FROM city_Shih
WHERE City = 'Seattle'

INSERT INTO city_Shih VALUES(3, 'Madison')

UPDATE people_Shih
SET City = 3
WHERE City IS NULL

CREATE VIEW Packers_hshih AS
SELECT p.pName
FROM city_Shih c JOIN people_Shih p ON c.Id = p.City
WHERE c.City = 'Green Bay'

SELECT *
FROM Packers_hshih

DROP TABLE people_Shih
DROP TABLE city_Shih
DROP VIEW Packers_hshih




--5. Create a stored procedure “sp_birthday_employees_[you_last_name]” that creates a new table “birthday_employees_your_last_name” and fill it with all employees that have a birthday on Feb. (Make a screen shot) drop the table. Employee table should not be affected.



--6. How do you make sure two tables have the same data?