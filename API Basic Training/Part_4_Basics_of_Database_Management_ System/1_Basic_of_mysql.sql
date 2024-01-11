-- Create database
-CREATE DATABASE rkit;

-- Create Table
CREATE TABLE EMP01(
	EMP01ID int NOT NULL AUTO_INCREMENT,
    	EMP01Name varchar(40) NOT NULL,
    	EMP01JobTitle varchar(20),
    	isActive bool DEFAULT TRUE,
    	CONSTRAINT PK_EMP01 PRIMARY KEY(EMP01ID)
);

-- Insert Into Table
INSERT INTO EMP01(
    EMP01Name,
    EMP01JobTitle,
    isActive
)
VALUES
	("Jeet", "Developer",TRUE),
    	("Prince", "Developer",FALSE);

-- Select Data
SELECT EMP01ID, EMP01Name, EMP01JobTitle, isActive
FROM EMP01
WHERE isActive = TRUE;

-- Update Data
UPDATE EMP01
SET isActive = 1
WHERE EMP01ID = 2;

-- Delete Data
DELETE FROM EMP01
WHERE EMP01ID = 2;
    
