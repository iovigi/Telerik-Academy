/*
1.Create a table in SQL Server with 10 000 000 log entries (date + text).
---Search in the table by date range. Check the speed (without caching).
*/

GO
CREATE DATABASE TestDatabase

GO
USE TestDatabase;

DROP TABLE TestTable

CREATE TABLE TestTable(
	Id int NOT NULL IDENTITY,
	PostOn datetime,
	TextData nvarchar(30),
	PRIMARY KEY (Id)
)

DECLARE @Count int = 1000000
WHILE (@Count > 0)
BEGIN
	DECLARE @LogText nvarchar(100) = 'Test' + CONVERT(varchar,@Count);
	DECLARE @LogDate datetime = DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate());
	INSERT INTO TestTable(PostOn, TextData)
	VALUES (@LogDate, @LogText)
SET @Count = @Count - 1
END

SELECT * FROM TestTable
WHERE PostOn > '31-Dec-1900' and PostOn < '2-July-2015'

/*
2.Add an index to speed-up the search by date.
---Test the search speed (after cleaning the cache).
*/

CREATE INDEX IDX_PostOn
ON TestTable(PostOn)

CHECKPOINT; DBCC DROPCLEANBUFFERS;

SELECT * FROM TestTable
WHERE PostOn > '31-Dec-1900' and PostOn < '2-July-2015'

DROP INDEX IDX_PostOn ON TestTable

/*
3.Add a full text index for the text column.
---Try to search with and without the full-text index and compare the speed.
*/

CREATE FULLTEXT CATALOG LogsFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

SELECT * FROM TestTable
WHERE TextData LIKE '%Text%';

CREATE FULLTEXT INDEX ON Logs(LogText)
KEY INDEX PK_Logs_LogId
ON LogsFullTextCatalog
WITH CHANGE_TRACKING AUTO

SELECT * FROM TestTable
WHERE TextData LIKE '%Text%';

DROP FULLTEXT INDEX ON Logs
DROP FULLTEXT CATALOG LogsFullTextCatalog