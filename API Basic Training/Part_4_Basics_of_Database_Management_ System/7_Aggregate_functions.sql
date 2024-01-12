-- Count the number of EMP02 in each department
SELECT P02F03, COUNT(*) AS num_EMP02
FROM EMP02
GROUP BY P02F03;

-- Calculate the total P02F04 for each department
SELECT P02F03, SUM(P02F04) AS total_P02F04
FROM EMP02
GROUP BY P02F03;

-- Calculate the average P02F04 for each department
SELECT P02F03, AVG(P02F04) AS avg_P02F04
FROM EMP02
GROUP BY P02F03;

-- Find the minimum P02F04 in the company
SELECT MIN(P02F04) AS min_P02F04
FROM EMP02;

-- Find the maximum P02F04 in the company
SELECT MAX(P02F04) AS max_P02F04
FROM EMP02;

-- Concatenate the names of EMP02 in each department
SELECT P02F03, GROUP_CONCAT(P02F02) AS EMP02_list
FROM EMP02
GROUP BY P02F03;

-- Find departments with an average P02F04 greater than 70000
SELECT P02F03, AVG(P02F04) AS avg_P02F04
FROM EMP02
GROUP BY P02F03
HAVING avg_P02F04 > 70000;
