-- Create database
 CREATE DATABASE rkit;

-- Create Table
CREATE TABLE EMP01(
	P01F01 int NOT NULL AUTO_INCREMENT COMMENT "Employee ID",
    P01F02 varchar(40) NOT NULL COMMENT "Employee Name",
    P01F03 varchar(20) COMMENT "Employee JobTitle",
    P01F04 bool DEFAULT TRUE COMMENT "Employee isActive",
    CONSTRAINT PK_EMP01 PRIMARY KEY(P01F01)
);

-- Insert Into Table
INSERT INTO EMP01(
    P01F02,
    P01F03,
    P01F04
)
VALUES
	("Jeet", "Developer",TRUE),
    ("Prince", "Developer",FALSE);

-- Select Data
SELECT P01F01, P01F02, P01F03, P01F04
FROM EMP01
WHERE P01F04 = TRUE;

-- Update Data
UPDATE EMP01
SET P01F04 = 1
WHERE P01F01 = 2;

-- Delete Data
DELETE FROM EMP01
WHERE P01F01 = 2;

    