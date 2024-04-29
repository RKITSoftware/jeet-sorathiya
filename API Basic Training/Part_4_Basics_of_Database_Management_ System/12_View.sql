-- View
CREATE VIEW vws_employee_view  AS 
SELECT P02F01,P02F02
FROM emp02
WHERE 	P02F03 = 2;

-- SELECT From View
SELECT P02F02 FROM vws_employee_view ;

-- Drop View
DROP VIEW vws_employee_view ;
-- vws_emp01

