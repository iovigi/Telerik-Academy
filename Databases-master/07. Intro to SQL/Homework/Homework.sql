/*
1.What is SQL? What is DML? What is DDL? Recite the most important SQL commands.
-Structured Query Language
-Data manipulation language
-Data defenition Language
-SQL commands:
--DDL
---CREATE TABLE
---DROP TABLE
---TRUNCATE TABLE
--DML
---INSERT
---DELETE WHERE
---SELECT WHERE
---JOIN
---UPDATE

2.What is Transact-SQL (T-SQL)?
Transact-SQL is central to using SQL Server. All applications that communicate with an instance of SQL Server do so by sending Transact-SQL statements to the server, regardless of the user interface of the application.

The following is a list of the kinds of applications that can generate Transact-SQL:

    General office productivity applications.

    Applications that use a graphical user interface (GUI) to let users select the tables and columns from which they want to see data.

    Applications that use general language sentences to determine what data a user wants to see.

    Line of business applications that store their data in SQL Server databases. These applications can include both applications written by vendors and applications written in-house.

    Transact-SQL scripts that are run by using utilities such as sqlcmd.

    Applications created by using development systems such as Microsoft Visual C++, Microsoft Visual Basic, or Microsoft Visual J++ that use database APIs such as ADO, OLE DB, and ODBC.

    Web pages that extract data from SQL Server databases.

    Distributed database systems from which data from SQL Server is replicated to various databases, or distributed queries are executed.

    Data warehouses in which data is extracted from online transaction processing (OLTP) systems and summarized for decision-support analysis.
*/

USE [TelerikAcademy];

/* 
4.Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
*/

SELECT *
FROM [dbo].[Departments];

/* 
5.Write a SQL query to find all department names.
*/

SELECT Name
FROM [dbo].[Departments];

/* 
6.Write a SQL query to find the salary of each employee.
*/

SELECT Salary
FROM [dbo].[Employees];

/* 
7.Write a SQL to find the full name of each employee.
*/

SELECT FirstName + ' ' + LastName
FROM [dbo].[Employees];

/* 
8.Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".
*/

SELECT FirstName + '.' + LastName + '@telerik.com'
FROM [dbo].[Employees];

/* 
9.Write a SQL query to find all different employee salaries.
*/

SELECT DISTINCT Salary
FROM [dbo].[Employees];

/* 
10.Write a SQL query to find all information about the employees whose job title is “Sales Representative“
*/

SELECT *
FROM [dbo].[Employees]
WHERE JobTitle = 'Sales Representative';

/* 
11.Write a SQL query to find the names of all employees whose first name starts with "SA".
*/

SELECT FirstName + ' ' + LastName
FROM [dbo].[Employees]
WHERE FirstName LIKE 'SA%';

/* 
12.Write a SQL query to find the names of all employees whose last name contains "ei".
*/

SELECT FirstName + ' ' + LastName
FROM [dbo].[Employees]
WHERE LastName LIKE '%ei%';

/* 
13.Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
*/

SELECT Salary
FROM [dbo].[Employees]
WHERE Salary BETWEEN 20000 AND 30000;

/*
14.Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
*/

SELECT FirstName + ' ' + LastName
FROM [dbo].[Employees]
WHERE Salary IN (25000, 14000, 12500, 23600);

/*
15.Write a SQL query to find all employees that do not have manager.
*/

SELECT *
FROM [dbo].[Employees]
WHERE ManagerID IS NULL;

/*
16.Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
*/

SELECT *
FROM [dbo].[Employees]
WHERE Salary > 50000
ORDER BY Salary DESC;

/*
17.Write a SQL query to find the top 5 best paid employees.
*/

SELECT TOP 5 *
FROM [dbo].[Employees]
ORDER BY Salary DESC;

/*
18.Write a SQL query to find all employees along with their address. Use inner join with ON clause.
*/

SELECT *
FROM [dbo].[Employees] employee
INNER JOIN [dbo].[Addresses] address
ON employee.AddressID = address.AddressID;

/*
19.Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
*/

SELECT *
FROM [dbo].[Employees] employee, [dbo].[Addresses] address
WHERE employee.AddressID = address.AddressID;

/*
20.Write a SQL query to find all employees along with their manager.
*/

SELECT employee.FirstName + ' ' + employee.LastName + " is managed by "+ manager.FirstName + ' ' + manager.LastName
FROM [dbo].[Employees] employee
LEFT OUTER JOIN [dbo].[Employees] manager
ON employee.ManagerID = manager.EmployeeID;

/*
21.Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.
*/

SELECT employee.FirstName + ' ' + employee.LastName, address.AddressText, manager.FirstName + ' ' + manager.LastName
FROM [dbo].[Employees] employee 
JOIN [dbo].[Employees] manager 
ON employee.ManagerID = manager.EmployeeID
JOIN [dbo].[Addresses] address
ON employee.AddressID = address.AddressID;

/*
22.Write a SQL query to find all departments and all town names as a single list. Use UNION.
*/

SELECT Name
FROM [dbo].[Departments]
UNION
SELECT Name
FROM [dbo].[Towns];

/*
23.Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.
*/

SELECT employee.FirstName + ' ' + employee.LastName + ' is managed by ' + manager.FirstName + ' ' + manager.LastName
FROM [dbo].[Employees] employee 
RIGHT OUTER JOIN [dbo].[Employees] manager
ON employee.ManagerID = manager.EmployeeID;

SELECT employee.FirstName + ' ' + employee.LastName + ' is managed by ' + manager.FirstName + ' ' + manager.LastName
FROM [dbo].[Employees] employee 
LEFT OUTER JOIN [dbo].[Employees] manager
ON employee.ManagerID = manager.EmployeeID;

/*
24.Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
*/

SELECT employee.FirstName + ' ' + employee.LastName, employee.HireDate, department.Name
FROM [dbo].[Employees] employee
JOIN [dbo].[Departments] department
ON employee.DepartmentID = department.DepartmentID
WHERE (department.Name = 'Sales' OR department.Name = 'Finance') AND
(employee.HireDate BETWEEN '1995-01-01 00:00:00' AND '2005-01-01 00:00:00');




















