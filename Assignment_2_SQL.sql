USE AdventureWorks2019
GO

--1. How many products can you find in the Production.Product table?
--ANS: 504

SELECT COUNT(*)
FROM Production.Product p

--2. Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.

SELECT COUNT(*)
FROM Production.Product p JOIN Production.ProductSubcategory s ON p.ProductSubcategoryID = s.ProductSubcategoryID

--3. How many Products reside in each SubCategory? Write a query to display the results with the following titles.

SELECT p.ProductSubcategoryID, COUNT(*) CountedProducts
FROM Production.Product p JOIN Production.ProductSubcategory s ON p.ProductSubcategoryID = s.ProductSubcategoryID
GROUP BY p.ProductSubcategoryID

--4. How many products that do not have a product subcategory.

SELECT COUNT(*)
FROM Production.Product p
WHERE p.ProductSubcategoryID IS NULL

--5. Write a query to list the sum of products quantity in the Production.ProductInventory table.

SELECT SUM(i.Quantity)
FROM Production.ProductInventory i

--6.  Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
	--**/This one is a little bit vague, especially "the sum of products". One productID will only Have one locationid = 40. So the quantity will be one number. Not sure where should I use sum.
SELECT i.ProductID, i.Quantity AS TheSum
FROM Production.ProductInventory i
WHERE i.LocationID = 40 AND i.Quantity < 100

--7. Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100
	--**/Same Problem here with question 6.

SELECT i.Shelf, i.ProductID, i.Quantity AS TheSum
FROM Production.ProductInventory i
WHERE i.LocationID = 40 AND i.Quantity < 100

--8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.

SELECT AVG(i.Quantity) TheAvg
FROM Production.ProductInventory i
WHERE i.LocationID = 10

--9. Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory

SELECT i.ProductID, i.Shelf, AVG(i.Quantity) TheAvg
FROM Production.ProductInventory i
GROUP BY i.ProductID, i.Shelf

--10. Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory

SELECT i.ProductID, i.shelf, AVG(i.Quantity) TheAvg
FROM Production.ProductInventory i
WHERE i.shelf != 'N/A'
GROUP BY i.ProductID, i.shelf

--11. List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.

SELECT p.Color, p.Class, COUNT(*) TheCount, AVG(p.ListPrice) AvgPrice
FROM Production.Product p
WHERE p.Color IS NOT NULL AND p.class IS NOT NULL
GROUP BY p.Color, p.Class


--JOIN
--12. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following.

SELECT c.Name AS Country, s.Name AS Province
FROM Person.CountryRegion c JOIN Person.StateProvince s ON c.CountryRegionCode = s.CountryRegionCode

--13. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.

SELECT c.Name AS Country, s.Name AS Province
FROM Person.CountryRegion c JOIN Person.StateProvince s ON c.CountryRegionCode = s.CountryRegionCode
WHERE c.Name IN ('Germany', 'Canada')

USE Northwind
GO

--14. List all Products that has been sold at least once in last 25 years.

SELECT p.ProductName
FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID JOIN Products p on od.ProductID = p.ProductID
WHERE o.OrderDate > DATEADD(year, -25, '2022/2/2')

--15. List top 5 locations (Zip Code) where the products sold most.

SELECT TOP 5 o.ShipPostalCode
FROM Orders	o JOIN [Order Details] od ON o.OrderID = od.OrderID
WHERE o.ShipPostalCode IS NOT NULL
GROUP BY o.ShipPostalCode
ORDER BY SUM(od.Quantity) DESC

--16. List top 5 locations (Zip Code) where the products sold most in last 25 years.

SELECT TOP 5 o.ShipPostalCode
FROM Orders	o JOIN [Order Details] od ON o.OrderID = od.OrderID
WHERE o.ShipPostalCode IS NOT NULL AND o.OrderDate > DATEADD(year, -25, '2022/2/2')
GROUP BY o.ShipPostalCode
ORDER BY SUM(od.Quantity) DESC

--17. List all city names and number of customers in that city.

SELECT c.City, COUNT(c.CustomerID)
FROM Customers c
GROUP BY c.City

--18. List city names which have more than 2 customers, and number of customers in that city

SELECT c.City, COUNT(c.CustomerID) Total
FROM Customers c
GROUP BY c.City
HAVING COUNT(c.CustomerID) >= 2

--19. List the names of customers who placed orders after 1/1/98 with order date.

SELECT DISTINCT c.ContactName
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998/1/1'

--20. List the names of all customers with most recent order dates

SELECT c.ContactName, MAX(o.OrderDate) [Most recent date]
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName

--21.  Display the names of all customers  along with the  count of products they bought

SELECT c.CustomerID, COUNT(od.ProductID) [Count of product]
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.CustomerID

--22. Display the customer ids who bought more than 100 Products with count of products.

SELECT c.CustomerID, COUNT(od.ProductID) [Count of product]
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.CustomerID
HAVING COUNT(od.ProductID) > 100

--23. List all of the possible ways that suppliers can ship their products. Display the results as below

SELECT DISTINCT s.CompanyName, sh.CompanyName
FROM Shippers sh JOIN Orders o ON sh.ShipperID = o.ShipVia JOIN [Order Details] od ON o.OrderID = od.OrderID JOIN Products p ON od.ProductID = p.ProductID JOIN Suppliers s ON p.SupplierID = s.SupplierID
ORDER BY s.CompanyName

--24. Display the products order each day. Show Order date and Product Name.

SELECT o.OrderDate, p.ProductName
FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID JOIN Products p ON od.ProductID = p.ProductID

--25. Displays pairs of employees who have the same job title.

SELECT DISTINCT a.FirstName + ' ' + a.LastName AS [employee 1], b.FirstName + ' ' + b.LastName AS [employee 2]
FROM Employees a, Employees b WHERE a.Title = b.Title
AND a.EmployeeID != b.EmployeeID


SELECT a.FirstName + ' ' + a.LastName AS [employee 1], b.FirstName + ' ' + b.LastName AS [employee 2]
FROM Employees a, Employees b WHERE a.Title = b.Title
AND a.EmployeeID != b.EmployeeID
group by CONCAT(LEAST(a.FirstName + ' ' + a.LastName, b.FirstName + ' ' + b.LastName), GREATEST(a.FirstName + ' ' + a.LastName, b.FirstName + ' ' + b.LastName))


--26. Display all the Managers who have more than 2 employees reporting to them

SELECT b.FirstName + ' ' + b.LastName AS [Name]
FROM Employees a JOIN Employees b ON a.ReportsTo = b.EmployeeID
GROUP BY b.FirstName, b.LastName
HAVING COUNT(a.EmployeeID) > 2

--27. Display the customers and suppliers by city. The results should have the following columns:
	--**Not sure about the difference between name and contactname, so I only choose one.

SELECT c.City, c.ContactName, 'Customers' AS [Type]
FROM Customers c
UNION
SELECT s.city, s.ContactName, 'Suppliers' AS [Type]
FROM Suppliers s
ORDER BY c.city
