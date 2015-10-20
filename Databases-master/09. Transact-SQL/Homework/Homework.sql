/*
1.Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance). 
---Insert few records for testing.
---Write a stored procedure that selects the full names of all persons.
*/

CREATE DATABASE Bank;

USE Bank;

CREATE TABLE Persons(
Id int NOT NULL IDENTITY, 
FirstName varchar(50), 
LastName varchar(50), 
SSN varchar(50),
PRIMARY KEY (Id)
);

CREATE TABLE  Accounts(
Id int NOT NULL IDENTITY, 
PersonId int FOREIGN KEY REFERENCES Persons(Id),
Balance money,
PRIMARY KEY (Id)
);

DECLARE @Count int = 1;

WHILE @Count < 10
BEGIN
INSERT INTO Persons(FirstName, LastName, SSN)
Values('Kiro' + CAST(@Count AS varchar(50)), 'Kiro', 'KiroSSN');
SET @Count += 1;
END

WHILE @Count < 10
BEGIN
INSERT INTO Accounts(PersonId, Balance)
VALUES(@Count, CAST(2.5 AS money));
SET @Count += 1;
END

GO
CREATE PROC ShowFullName
AS
BEGIN
SELECT FirstName + ' ' + LastName
FROM Persons
END;

EXEC ShowFullName


--2.Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.

GO
CREATE PROC FindPersonWithMoreMoney @money MONEY = 0
AS
SELECT p.FirstName,p.LastName,a.Balance FROM Persons p
JOIN Accounts a ON p.Id=a.PersonId
WHERE a.Balance>@money
GO


EXEC FindPersonWithMoreMoney @money = 1

/*
3.Create a function that accepts as parameters – sum, yearly interest rate and number of months.

---It should calculate and return the new sum.
---Write a SELECT to test whether the function works as expected.

*/

GO
CREATE FUNCTION CalculateInterest(@sum money, @yearInterest money, @months int) RETURNS money
BEGIN
RETURN (@sum + @sum*(@yearInterest/100)*@months/12)
END
GO


DECLARE @sum MONEY = (SELECT SUM(Balance) FROM Accounts WHERE PersonId = 5)
SELECT @sum;
SELECT  dbo.CalculateInterest(@sum,5,5)


/*
4.Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month. 
---It should take the AccountId and the interest rate as parameters.
*/

GO
CREATE PROC AddInterest (@id int,@interest money)
AS
BEGIN
DECLARE @sum money = (SELECT Balance FROM Accounts WHERE Id = @id)
PRINT @id;
UPDATE Accounts
SET Balance = @sum+@sum*(@interest/100)/12
WHERE Id = @id
END
GO
EXEC AddInterest @id=3, @interest =2

/*
5.Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money) that operate in transactions.
*/

GO
CREATE PROC withdrawMoney (@id INT,@money MONEY)
AS
DECLARE @currentBalanace MONEY = (SELECT Balance FROM Accounts WHERE Id = @id)
IF(@money<=@currentBalanace)
BEGIN
UPDATE Accounts
SET Balance = Balance-@money
WHERE Id = @id
END
GO

GO
CREATE PROC depositMoney (@id int,@money money)
AS
UPDATE Accounts
SET Balance = Balance + @money
WHERE Id = @id
GO

EXEC withdrawMoney 1, 20
EXEC depositMoney 2,5

/*
6.Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
---Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
*/

CREATE TABLE Logs (
    Id int IDENTITY PRIMARY KEY,
    AccountId int NOT NULL FOREIGN KEY REFERENCES Accounts(Id),
    OldBalance money NOT NULL,
    NewBalance money NOT NULL
)

GO

CREATE TRIGGER updateAccountBalance ON Accounts FOR UPDATE
AS
    DECLARE @oldSum money;
    SELECT @oldSum = Balance FROM deleted;

    INSERT INTO Logs(AccountId, OldBalance, NewBalance)
        SELECT Id, @oldSum, Balance
        FROM inserted
GO

EXEC depositMoney 2, 100

EXEC withdrawMoney 2, 500

/*
7.Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) and all town's names that are comprised of given set of letters. 
---Example: 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
*/

USE TelerikAcademy
GO

CREATE FUNCTION searchForWordsInGivenPattern(@pattern nvarchar(255))
	RETURNS @name TABLE (Name varchar(50))
AS
BEGIN
	INSERT @name
	SELECT * 
	FROM
		(SELECT employees.FirstName FROM Employees employees
        UNION
        SELECT employees.LastName FROM Employees employees
        UNION 
        SELECT town.Name FROM Towns town) as temp(name)
    WHERE PATINDEX('%[' + @pattern + ']', Name) > 0
	RETURN
END
GO

/*
8.Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.
*/
DECLARE employeeTownCursor CURSOR READ_ONLY FOR
SELECT 'Live in same town ' + em1.FirstName + ' and ' + em2.FirstName
FROM Employees em1
JOIN Addresses address 
ON em1.AddressID = address.AddressID
JOIN Towns town
ON address.TownID = town.TownID, 
Employees em2
JOIN Addresses address2
ON em2.AddressID = address2.AddressID
JOIN Towns town2
ON address2.TownID = town2.TownID
WHERE em1.AddressID != em2.AddressID

/*
9.*Write a T-SQL script that shows for each town a list of all employees that live in it.
---Sample output:
----
Sofia -> Martin Kulov, George Denchev
Ottawa -> Jose Saraiva
…
----
*/

DECLARE employeeTownCursor CURSOR READ_ONLY FOR
SELECT town2.Name + 'Live in same town ' + em1.FirstName + ' and ' + em2.FirstName
FROM Employees em1
JOIN Addresses address 
ON em1.AddressID = address.AddressID
JOIN Towns town
ON address.TownID = town.TownID, 
Employees em2
JOIN Addresses address2
ON em2.AddressID = address2.AddressID
JOIN Towns town2
ON address2.TownID = town2.TownID
WHERE em1.AddressID != em2.AddressID
GROUP BY town2.Name, em1.FirstName, em2.FirstName

/*
10.Define a .NET aggregate function StrConcat that takes as input a sequence of strings and return a single string that consists of the input strings separated by ','. 
---For example the following SQL statement should return a single string:
----
SELECT StrConcat(FirstName + ' ' + LastName)
FROM Employees
----
*/

sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO

CREATE Assembly concat_assembly 
   AUTHORIZATION dbo 
   FROM 'D:\SqlStrConcat.dll'
   WITH PERMISSION_SET = SAFE; 
GO 
CREATE AGGREGATE dbo.concat ( 
    @Value NVARCHAR(MAX),
    @Delimiter NVARCHAR(4000) 
) 
    RETURNS NVARCHAR(MAX) 
    EXTERNAL Name concat_assembly.concat; 
GO 
SELECT dbo.concat(FirstName + ' ' + LastName, ', ')
FROM Employees
GO