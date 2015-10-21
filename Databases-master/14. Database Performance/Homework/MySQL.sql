DROP DATABASE IF EXISTS TestDatabase;

CREATE DATABASE TestDatabase;

USE TestDatabase;

DROP TABLE IF EXISTS TestTable;

CREATE TABLE TestTable(
	Id int NOT NULL AUTO_INCREMENT,
	PostOn datetime NOT NULL,
	LogText nvarchar(300),
	PRIMARY KEY (Id,PostOn)
    )
 PARTITION BY RANGE(YEAR(PostOn))(
	PARTITION partition1 VALUES LESS THAN (1990),
	PARTITION partition2 VALUES LESS THAN (2000),
    PARTITION partition3 VALUES LESS THAN (2010)
);


CREATE PROCEDURE prc_Fill()
DECLARE C INT;

WHILE C < 10000 DO
	INSERT INTO TestTable(PostOn, LogText)
	VALUES (FROM_UNIXTIME(RAND() * 12321321), CONCAT('Text ', Counter));
SET C = C + 1;
END WHILE;
END;

CALL prc_Fill();

SELECT COUNT(*) FROM TestTable PARTITION (partition1);
SELECT COUNT(*) FROM TestTable PARTITION (partition2);
SELECT COUNT(*) FROM TestTable PARTITION (partition3);

-- all partitions
SELECT * FROM TestTable  WHERE YEAR(PostOn) = 1995;

-- partition with 1995 year
SELECT * FROM TestTable PARTITION (partition2) WHERE YEAR(PostOn) = 1995;


 
