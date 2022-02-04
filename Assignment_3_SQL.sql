USE Northwind
GO

--1. List all cities that have both Employees and Customers.

SELECT DISTINCT c.City
FROM Customers c
INTERSECT
SELECT DISTINCT e.City
FROM Employees e
GROUP BY City

--2. List all cities that have Customers but no Employee.
 --a. Use sub-query
SELECT DISTINCT c.City
FROM Customers c
WHERE c.City NOT IN(SELECT DISTINCT e.City FROM Employees e)

 --b. Do not use sub-query

SELECT DISTINCT c.City
FROM Customers c
EXCEPT
SELECT DISTINCT e.City
FROM Employees e
GROUP BY City

--3. List all products and their total order quantities throughout all orders.

SELECT p.ProductName, SUM(od.Quantity)
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON od.OrderID = o.OrderID
GROUP BY p.ProductName

--4. List all Customer Cities and total products ordered by that city.

SELECT c.City, SUM(od.Quantity)
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON od.OrderID = o.OrderID JOIN Customers c ON o.CustomerID = c.CustomerID
GROUP BY c.City


--5. List all Customer Cities that have at least two customers.
 --a. Use union

SELECT c.city
FROM Customers c
GROUP BY c.City
HAVING COUNT(c.city) >= 2
INTERSECT
SELECT DISTINCT b.City
FROM Customers b

 --b. Use sub-query and no union

SELECT dt.city
FROM
	(SELECT c.city FROM Customers c
	GROUP BY c.City
	HAVING COUNT(c.city) >= 2) dt

--6. List all Customer Cities that have ordered at least two different kinds of products.

SELECT dt.city
FROM (
	SELECT DISTINCT c.City AS city, p.ProductName AS pname
	FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON od.OrderID = o.OrderID JOIN Customers c ON o.CustomerID = c.CustomerID) dt
	GROUP BY city
	HAVING COUNT(dt.pname) >= 2


--7. List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.

SELECT DISTINCT c.ContactName
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.ShipCity != c.city

--8. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.

SELECT A.ProductID, B.TheAVG, A.City
FROM(
SELECT dt.productID, dt.city
FROM(
SELECT od.ProductID, c.city, RANK() OVER(PARTITION BY od.ProductID ORDER BY SUM(od.Quantity) DESC) RNK
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON od.OrderID = o.OrderID JOIN Customers c ON o.CustomerID = c.CustomerID
GROUP BY od.ProductID, c.City) dt 
WHERE dt.RNK = 1 AND dt.ProductID IN (SELECT TOP 5 p.ProductID
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON od.OrderID = o.OrderID JOIN Customers c ON o.CustomerID = c.CustomerID
GROUP BY p.ProductID
ORDER BY SUM(od.Quantity) DESC)) A JOIN
(
SELECT od.ProductID , ROUND(SUM(od.UnitPrice * od.Quantity * (1-od.Discount))/SUM(od.Quantity), 2) TheAVG
FROM [Order Details] od
WHERE od.ProductID IN (SELECT TOP 5 p.ProductID
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON od.OrderID = o.OrderID JOIN Customers c ON o.CustomerID = c.CustomerID
GROUP BY p.ProductID
ORDER BY SUM(od.Quantity) DESC)
GROUP BY od.ProductID) B ON A.ProductID = B.ProductID



--9. List all cities that have never ordered something but we have employees there.
 --a. Use sub-query

SELECT DISTINCT e.City
FROM Employees e
WHERE e.City NOT IN (
	SELECT DISTINCT c.City
	FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID)

 --b. Do not use sub-query

SELECT DISTINCT e.City
FROM Employees e
EXCEPT
SELECT DISTINCT c.City
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID

--10. List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)

SELECT dt.city 
FROM(
SELECT TOP 1 c.City, RANK() OVER(ORDER BY SUM(od.Quantity) DESC) RNK 
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.city
INTERSECT
SELECT TOP 1 c.City, RANK() OVER(ORDER BY COUNT(o.orderID) DESC) RNK
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.city) dt


--11. How do you remove the duplicates record of a table?

/**
The first way is using Group by to identify the duplicate row. We can use the Count function to check the ocurrence of a row.
Rank is also another way to check repeated rows in a table. The rows with the same rank can be easily identified as duplicates.
**/