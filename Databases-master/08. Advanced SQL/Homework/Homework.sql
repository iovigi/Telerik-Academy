/*
1: Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. 
-Use a nested SELECT statement.
*/

SELECT FirstName, LastName, Salary
	FROM Employees
	WHERE Salary = 
	(SELECT MIN(Salary) FROM Employees);
            
/*
2: Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
*/


SELECT FirstName, LastName, Salary
	FROM Employees
	WHERE Salary BETWEEN @MinSalary AND 
	1.1 *  (SELECT MIN(Salary) FROM Employees)
	ORDER BY Salary;

/*
3: Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
-Use a nested SELECT statement.
*/

SELECT CONCAT(employee.FirstName, ' ', employee.LastName), employee.Salary, department.Name
	FROM Employees employee
	JOIN Departments department
		ON employee.DepartmentID = department.DepartmentID
    WHERE Salary =
        (SELECT MIN(Salary) FROM Employees emp
        WHERE emp.DepartmentID = department.DepartmentID)
    ORDER BY Salary;
    
/*
4: Write a SQL query to find the average salary in the department #1.
*/

SELECT AVG(Salary)
	FROM Employees
	WHERE DepartmentID = 1;
    
/*
5: Write a SQL query to find the average salary in the "Sales" department.
*/

SELECT AVG(Salary)
	FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales';
    
/*
6: Write a SQL query to find the number of employees in the "Sales" department.
*/

SELECT COUNT(*)
	FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
    
/*
7: Write a SQL query to find the number of all employees that have manager.
*/

SELECT COUNT(*)
	FROM Employees
	WHERE ManagerID IS NOT NULL
    
/*
-TASK 08: Write a SQL query to find the number of all employees that have no manager.
*/

SELECT COUNT(*) 
	FROM Employees
	WHERE ManagerID IS NULL

/*
9: Write a SQL query to find all departments and the average salary for each of them.
*/

SELECT AVG(Salary), d.Name
	FROM Employees employee
	JOIN Departments department
		ON employee.DepartmentID = department.DepartmentID
	GROUP BY department.Name
    
/*
10: Write a SQL query to find the count of all employees in each department and for each town.
*/

SELECT COUNT(employee.EmployeeID), town.Name, department.Name
	FROM Employees employee
	JOIN Departments department
		ON employee.DepartmentID = department.DepartmentID
	JOIN Addresses address
		ON employee.AddressID = address.AddressID
	JOIN Towns town
		ON address.TownID = town.TownID
	GROUP BY department.Name, town.Name
    
/*
11: Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
*/

SELECT manager.EmployeeID,
	   manager.FirstName + ' ' + manager.LastName,
	   COUNT(manager.EmployeeID)
	FROM Employees employee
	JOIN Employees manager
		ON employee.ManagerID = manager.EmployeeID
	GROUP BY manager.EmployeeID, manager.FirstName, manager.LastName
	HAVING COUNT(manager.EmployeeID) = 5;
    
/*
12: Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
*/

SELECT employee.FirstName + ' ' + employee.LastName, COALESCE(manager.FirstName + ' '+ manager.LastName, 'no manager')
	FROM Employees employee
	LEFT JOIN Employees manager
		ON manager.ManagerID = employee.EmployeeID;
        
/*
13: Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
*/

SELECT LastName
	FROM Employees
	WHERE LEN(LastName) = 5;
    
/*
14: Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
-Search in Google to find how to format dates in SQL Server.
*/

SELECT FORMAT(GETDATE(), 'dd.MM.yyyy HH:mm:ss:fff');

/*
15: Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
-Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
-Define the primary key column as identity to facilitate inserting records.
-Define unique constraint to avoid repeating usernames.
-Define a check constraint to ensure the password is at least 5 characters long.
*/

CREATE TABLE Users (
    ID int IDENTITY PRIMARY KEY,
    Username nvarchar(50) NOT NULL UNIQUE,
    Password nvarchar(256) NOT NULL CHECK (LEN(Pass) > 5),
    FullName nvarchar(50) NOT NULL CHECK (LEN(FullName) > 5),
    LastLoginTime DATETIME NOT NULL,
);

/*
16: Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
--Test if the view works correctly.
*/

CREATE VIEW UsersToday AS 
	SELECT Username FROM Users
	WHERE DATEDIFF(DAY, LastLoginTime, GETDATE()) = 0;
    
/*
17: Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
--Define primary key and identity column.
*/

CREATE TABLE Groups(ID int IDENTITY PRIMARY KEY, Name nvarchar(50) NOT NULL UNIQUE);

/*
18: Write a SQL statement to add a column GroupID to the table Users.
--Fill some data in this new column and as well in the `Groups` table.
--Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
*/

ALTER TABLE Users
	ADD GroupID int NOT NULL;

ALTER TABLE Users
	ADD CONSTRAINT FK_Users_Groups
	FOREIGN KEY (GroupId)
	REFERENCES Groups(ID);

/*
19: Write SQL statements to insert several records in the Users and Groups tables.
*/

INSERT INTO Groups VALUES
    ('Telerik'),
    ('Progress');

INSERT INTO Users VALUES
    ('Kiro2', '123', 'Kiro Kiro', '2015-10-1 00:00:00', 1),
    ('Kiro3', '123', 'Kiro Kiro', '2015-10-1 00:00:00', 2),
    ('Kiro', '123', 'Kiro Kiro', '2015-10-1 00:00:00', 2);

/*
20: Write SQL statements to update some of the records in the Users and Groups tables.
*/

UPDATE Users
	SET Username = "Ivan"
	WHERE ID = 1;
	
UPDATE Groups
	SET Name = "Microsoft"
	WHERE ID = 1;
    
/*
21: Write SQL statements to delete some of the records from the  Users and Groups tables.
*/

DELETE FROM Users WHERE ID = 1;

DELETE FROM Groups WHERE ID = 1;
    
/*
22: Write SQL statements to insert in the Users table the names of all employees from the Employees table.
-- Combine the first and last names as a full name.
-- For username use the first letter of the first name + the last name (in lowercase).
-- Use the same for the password, and NULL for last login time.
*/

INSERT INTO Users (Username, FullName, Password)
        VALUES(SELECT LOWER(CONCAT(LEFT(FirstName, 1), '.', LastName)),
                CONCAT(FirstName, ' ', LastName),
                "123")
        FROM Employees);

/*
-- TASK 23: Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
*/

UPDATE Users SET Password = NULL WHERE DATEDIFF(day, LastLoginTime, '2010-3-10 00:00:00') > 0;
    
/*
24: Write a SQL statement that deletes all users without passwords (NULL password).
*/

DELETE FROM Users WHERE Password IS NULL;
    
/*
25: Write a SQL query to display the average employee salary by department and job title.
*/

SELECT AVG(employee.Salary), department.Name, employee.JobTitle
    FROM Employees employee 
    JOIN Departments department ON employee.DepartmentID = department.DepartmentID
    GROUP BY department.Name, employee.JobTitle;
    
/*
26: Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
*/

SELECT MIN(employee.Salary), department.Name, employee.JobTitle, Max(employee.FirstName)
    FROM Employees employee 
    JOIN Departments department
        ON employee.DepartmentID = department.DepartmentID
    GROUP BY department.Name, eemployee.JobTitle;
    
/*
27: Write a SQL query to display the town where maximal number of employees work.
*/

SELECT TOP 1 town.Name,
	COUNT(employee.EmployeeID) as EmployeesCount
    FROM Employees employee
    JOIN Addresses address ON employee.AddressID = address.AddressID
    JOIN Towns town ON town.TownID = address.TownID
    GROUP BY town.Name
    ORDER BY EmployeesCount DESC;
    
/*
28: Write a SQL query to display the number of managers from  each town.
*/

SELECT town.Name, COUNT(employee.EmployeeID)
    FROM Employees employee 
    JOIN Addresses address
        ON employee.AddressID = address.AddressID
    JOIN Towns town
        ON town.TownID = address.TownID
    GROUP BY town.Name;
       
/*
30: Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables.
--At the end rollback the transaction.
*/

BEGIN DeleteAllSales
    DELETE FROM Employees employee JOIN Departments department ON employee.DepartmentID = department.DepartmentID WHERE department.Name = 'Sales'
ROLLBACK DeleteAllSales;

/*
31: Start a database transaction and drop the table EmployeesProjects.
--Now how you could restore back the lost table data?
*/

BEGIN DeleteTable
    DROP TABLE EmployeesProjects
ROLLBACK DeleteTable;

/*
32: Find how to use temporary tables in SQL Server.
--Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.
*/
SELECT * 
    INTO #TempEmployeesProjects  --- Create new table
    FROM EmployeesProjects
DROP TABLE EmployeesProjects
SELECT * 
    INTO EmployeesProjects --- Create new table
    FROM #TempEmployeesProjects
DROP TABLE #TempEmployeesProjects