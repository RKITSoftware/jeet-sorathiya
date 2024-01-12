-- Count the number of employees in each department
SELECT department_id, COUNT(*) AS num_employees
FROM employees
GROUP BY department_id;

-- Calculate the total salary for each department
SELECT department_id, SUM(salary) AS total_salary
FROM employees
GROUP BY department_id;

-- Calculate the average salary for each department
SELECT department_id, AVG(salary) AS avg_salary
FROM employees
GROUP BY department_id;

-- Find the minimum salary in the company
SELECT MIN(salary) AS min_salary
FROM employees;

-- Find the maximum salary in the company
SELECT MAX(salary) AS max_salary
FROM employees;

-- Concatenate the names of employees in each department
SELECT department_id, GROUP_CONCAT(emp_name) AS employees_list
FROM employees
GROUP BY department_id;

-- Find departments with an average salary greater than 70000
SELECT department_id, AVG(salary) AS avg_salary
FROM employees
GROUP BY department_id
HAVING avg_salary > 70000;
