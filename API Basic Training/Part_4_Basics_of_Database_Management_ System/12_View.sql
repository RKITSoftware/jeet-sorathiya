-- View
CREATE VIEW employee_view  AS 
SELECT P02F01,P02F02
FROM emp02
WHERE 	P02F03 = 2;

-- SELECT From View
SELECT P02F02 FROM employee_view ;

-- Drop View
DROP VIEW employee_view ;

