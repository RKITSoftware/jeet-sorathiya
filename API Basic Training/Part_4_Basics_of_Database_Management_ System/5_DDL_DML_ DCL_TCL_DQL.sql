-- DDL (Data Definition Language)
-- Create a New Table
CREATE TABLE projects (
    project_id INT PRIMARY KEY,
    project_name VARCHAR(50),
    start_date DATE,
    end_date DATE
);

-- VAlter Table
-- Add a new column to the 'employees' table
ALTER TABLE employees
ADD COLUMN salary DECIMAL(10, 2);

-- DML (Data Manipulation Language)
-- Insert Data
-- Insert new data into the 'employees' table
INSERT INTO employees VALUES (4, 'Alice Johnson', 2, 75000.00);

-- Update Data
-- Update the salary for an employee
UPDATE employees
SET salary = 80000.00
WHERE emp_id = 1;

-- Delete Data
-- Delete an employee from the 'employees' table
DELETE FROM employees
WHERE emp_id = 3;

-- DCL (Data Control Language)
-- Grant Permissions
-- Grant SELECT permission on the 'employees' table to a user
GRANT SELECT ON employees TO 'username'@'localhost';

-- Revoke Permissions
-- Revoke INSERT permission on the 'projects' table from a user
REVOKE INSERT ON projects FROM 'username'@'localhost';

-- TCL (Transaction Control Language)
-- Commit a transaction
COMMIT;
-- Rollback a transaction
ROLLBACK;

-- DQL (Data Query Language):
-- Select Data
-- Retrieve data from the 'employees' table
SELECT emp_name, salary
FROM employees
WHERE department_id = 2;

