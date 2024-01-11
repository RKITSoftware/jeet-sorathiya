-- Create database
CREATE DATABASE rkit;

-- Create Table
CREATE TABLE employee(
    employeeID int NOT NULL AUTO_INCREMENT,
    employeeName varchar(40) NOT NULL,
    employeeJobTitle varchar(20),
    isActive bool DEFAULT TRUE,
    CONSTRAINT PK_employee PRIMARY KEY(employeeID)
);

-- Insert Into Table
INSERT INTO employee(
    employeeName,
    employeeJobTitle,
    isActive
)
VALUES
	("Jeet", "Developer"),
	("Prince", "Developer",FALSE);

-- Select Data
SELECT employeeID, employeeName, employeeJobTitle, isActive
FROM employee
WHERE isActive = TRUE;

-- Update Data
UPDATE employee
SET isActive = 1
WHERE employeeID = 2;

-- Delete Data
DELETE FROM employee
WHERE employeeID = 2;
    
