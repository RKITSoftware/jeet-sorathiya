-- DDL (Data Definition Language)
-- Create a New Table
CREATE TABLE PRJ01 (
    J01F01 INT PRIMARY KEY COMMENT "PROJECT ID",
    J01F02 VARCHAR(50) COMMENT "PROJECT Name",
    J01F03 DATE COMMENT "Start Date",
    J01F04 DATE COMMENT "End Date"
) COMMENT "PROJECT";

-- VAlter Table
-- Add a new column to the 'EMP02' table
ALTER TABLE EMP02
ADD COLUMN P02F04 DECIMAL(10, 2);

-- DML (Data Manipulation Language)
-- Insert Data
-- Insert new data into the 'EMP02' table
INSERT INTO EMP02 VALUES (4, 'Hokai', 2, 75000.00);

-- Update Data
-- Update the P02F04 for an employee
UPDATE EMP02
SET P02F04 = 80000.00
WHERE P02F01 = 1;

-- Delete Data
-- Delete an employee from the 'EMP02' table
DELETE FROM EMP02
WHERE P02F01 = 3;

-- DCL (Data Control Language)
-- Grant Permissions
-- Grant SELECT permission on the 'EMP02' table to a user
GRANT SELECT ON EMP02 TO 'username'@'localhost';

-- Revoke Permissions
-- Revoke INSERT permission on the 'PRJ01' table from a user
REVOKE INSERT ON PRJ01 FROM 'username'@'localhost';

-- TCL (Transaction Control Language)
-- Commit a transaction
COMMIT;
-- Rollback a transaction
ROLLBACK;

-- DQL (Data Query Language):
-- Select Data
-- Retrieve data from the 'EMP02' table
SELECT P02F02, P02F04
FROM EMP02
WHERE P02F03 = 2;

