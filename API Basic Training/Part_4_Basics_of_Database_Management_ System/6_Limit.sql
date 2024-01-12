-- Update salary for the first 3 employees
UPDATE employees
SET salary = salary * 1.1
LIMIT 3;

-- Delete the first 2 employees
DELETE FROM employees
LIMIT 2;

-- Retrieve employees with the highest salary using a subquery
SELECT * FROM employees
WHERE salary = (SELECT MAX(salary) FROM employees)
LIMIT 1;
