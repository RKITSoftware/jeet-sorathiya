-- CREATE TABLE EMPLOYEE
CREATE TABLE EMP02 (
    P02F01 INT PRIMARY KEY COMMENT "Employee ID",
    P02F02 VARCHAR(50) COMMENT "Employee Name",
    P02F03 INT COMMENT "DEPARTMENT ID"
);
-- CREATE TABLE DEPARTMENT
CREATE TABLE DEP01 (
    P01F01 INT PRIMARY KEY COMMENT "DEPARTMENT ID",
    P01F02 VARCHAR(50) COMMENT "DEPARTMENT Name"
);

-- INSERT INTO EMPLOYEE TABLE
INSERT INTO EMP02 VALUES (1, 'Jeet', 1);
INSERT INTO EMP02 VALUES (2, 'Elon Musk', 2);
INSERT INTO EMP02 VALUES (3, 'Mark Jugenburg', 1);

-- INSERT INTO DEPARTMENT TABLE
INSERT INTO DEP01 VALUES (1, 'HR');
INSERT INTO DEP01 VALUES (2, 'IT');

-- Subquery in SELECT Clause
SELECT P02F02, (SELECT P01F02 FROM DEP01 WHERE P01F01 = EMP02.P02F01) AS P01F02
FROM EMP02;
-- Subquery in FROM Clause:
SELECT derived_table.P02F02
FROM (SELECT P02F02 FROM EMP02 WHERE P02F01 = 1) AS derived_table;
-- Subquery in WHERE Clause:
SELECT P02F02
FROM EMP02
WHERE P02F01 = (SELECT P01F01 FROM DEP01 WHERE P01F02 = 'IT');
-- Subquery in IN Clause:
SELECT P02F02
FROM EMP02
WHERE P02F01 IN (SELECT P01F01 FROM DEP01 WHERE P01F02 = 'HR');
-- Subquery in EXISTS Clause:
SELECT P02F02
FROM EMP02 e
WHERE EXISTS (SELECT P01F01 FROM DEP01 d WHERE d.P01F01 = e.P02F01);
