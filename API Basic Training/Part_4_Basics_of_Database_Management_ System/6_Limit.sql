-- Update P02F04 for the first 3 EMP02
UPDATE EMP02
SET P02F04 = P02F04 * 1.1
LIMIT 3;

-- Delete the first 2 EMP02
DELETE FROM EMP02
LIMIT 2;

-- Retrieve EMP02 with the highest P02F04 using a subquery
SELECT * FROM EMP02
WHERE P02F04 = (SELECT MAX(P02F04) FROM EMP02)
LIMIT 1;