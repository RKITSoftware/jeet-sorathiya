-- CREATE DATABASE 
-- CREATE DATABASE  train_management

-- CREATE TABLES FOR (trains ,passengers ,bookings)
CREATE TABLE TRA01(
	A01F01 INT PRIMARY KEY AUTO_INCREMENT COMMENT "train id ",
    A01F02 VARCHAR(50) COMMENT "train name",
    A01F03 VARCHAR(50) COMMENT "departure station",
    A01F04 VARCHAR(50) COMMENT "arrival station",
    A01F05 VARCHAR(50) COMMENT "departure time",
    A01F06 VARCHAR(50) COMMENT "arrival time"
)COMMENT "trains";

CREATE TABLE PSG01(
	G01F01 INT PRIMARY KEY AUTO_INCREMENT COMMENT "passenger id",
    G01F02 VARCHAR(50) COMMENT "passenger name",
    G01F03 INT COMMENT "AGE"
)COMMENT "passengers";

CREATE TABLE BOK01 (
    K01F01 INT PRIMARY KEY AUTO_INCREMENT COMMENT "booking id",
    K01F02 INT COMMENT "train id",
    K01F03 INT COMMENT "passenger id",
    K01F04 DATE COMMENT "booking date",
    FOREIGN KEY (K01F02) REFERENCES TRA01(A01F01),
    FOREIGN KEY (K01F03) REFERENCES PSG01(G01F01)
)COMMENT "bookings";

-- Index: Creating an index on departure_time for faster retrieval
CREATE INDEX idx_departure_time 
ON TRA01(A01F05);

-- Inserting data
INSERT INTO TRA01 (A01F02, A01F03, A01F04, A01F05, A01F06)
VALUES
    ('Express 101', 'Rajkot', 'Morbi', '09:00:00', '12:00:00'),
    ('Local 202', 'Morbi', 'Rajkot', '11:30:00', '14:30:00'),
    ('Superfast 303', 'Rajkot', 'Jamnagr', '14:45:00', '18:30:00');

INSERT INTO PSG01 (G01F02, G01F03) VALUES
    ('Jeet', 21),
    ('Tony Stark', 35),
    ('Captain America',100),
    ('Spider Man', 22);

INSERT INTO BOK01 (K01F02, K01F03, K01F04) VALUES
    (1, 1, '2024-01-15'),
    (2, 2, '2024-01-16'),
    (3, 3, '2024-01-17');
    
-- SELECT TRAIN DATA ORDER BY DEPARTURE_TIME
SELECT
	A01F02 AS "TRAIN_NAME", 
    A01F03 "DEPARTURE_STATION", 
    A01F04 "ARRIVAL_STATION", 
    A01F05 "DEPARTURE_TIME", 
    A01F06 "ARRIVAL_TIME"
FROM TRA01
ORDER BY A01F05 ;

-- Limit: Limiting the number of rows returned
SELECT 
	G01F02 AS "NAME", 
    G01F03 "AGE" 
FROM PSG01
WHERE G01F03 > 18
LIMIT 2;

-- Aggregate functions: Calculating average departure time
SELECT 
	AVG(TIME_TO_SEC(A01F05)) AS avg_departure_time_sec 
FROM TRA01;
--
 SELECT
    TRA01.A01F02 AS "TRAIN-NAME",
    COUNT(BOK01.K01F01) AS "BOOKING-COUNT"
FROM
    BOK01
LEFT  JOIN
    TRA01 ON BOK01.K01F02 = TRA01.A01F01
LEFT  JOIN
    PSG01 ON BOK01.K01F03 = PSG01.G01F01;   

-- Sub-Queries: Using a subquery to find trains with departure times above average
SELECT 
	A01F02 AS "TRAIN_NAME", 
    A01F05 "DEPARTURE_TIME"
FROM TRA01
WHERE TIME_TO_SEC(A01F05) > (SELECT AVG(TIME_TO_SEC(A01F05)) FROM TRA01);

-- View: Creating a view
CREATE VIEW delayed_trains_view AS
SELECT 
	A01F02, 
    A01F03, 
    A01F04
FROM TRA01
WHERE A01F03 > '18:00:00';

SELECT 
	A01F02 AS "TRAIN_NAME", 
    A01F03 AS "DEPARTURE_STATION", 
    A01F04 AS "ARRIVAL_STATION"
FROM delayed_trains_view;

-- INNER JOIN
SELECT
    TRA01.A01F02 AS "TRAIN-NAME",
    TRA01.A01F03 AS "DEPARTURE-STATION",
    TRA01.A01F04 AS "ARRIVAL-STATION",
    TRA01.A01F05 AS "DEPARTURE-TIME",
    TRA01.A01F06 AS "ARRIVAL-TIME",
    PSG01.G01F02 AS "PASSENGER-NAME",
    PSG01.G01F03 AS "AGE",
    BOK01.K01F04 AS "BOOKING-DATE"
FROM
    BOK01
INNER JOIN
    TRA01 ON BOK01.K01F02 = TRA01.A01F01
INNER JOIN
    PSG01 ON BOK01.K01F03 = PSG01.G01F01;
    
-- LEFT JOIN 
SELECT
    TRA01.A01F02 AS "TRAIN-NAME",
    PSG01.G01F02 AS "PASSENGER-NAME",
    BOK01.K01F04 AS "BOOKING-DATE"
FROM
    BOK01
LEFT  JOIN
    TRA01 ON BOK01.K01F02 = TRA01.A01F01
LEFT  JOIN
    PSG01 ON BOK01.K01F03 = PSG01.G01F01;   
    
  -- Find passengers who have booked a train
SELECT
    PSG01.G01F01,
    PSG01.G01F02,
    'Booked' AS status
FROM
    BOK01
JOIN
    PSG01 ON BOK01.K01F03 = PSG01.G01F01

UNION

-- Find passengers who are waiting for a train
SELECT
    PSG01.G01F01,
    PSG01.G01F02,
    'Waiting' AS status
FROM
    PSG01
WHERE
    PSG01.G01F01 NOT IN (SELECT K01F03 FROM BOK01);
    
 -- Start a transaction
START TRANSACTION;

-- Update data (for example, changing the train name)
UPDATE TRA01
SET A01F02 = 'New Express 101'
WHERE A01F01 = 1;

-- Select data n (before committing)
SELECT 
	A01F02 AS "TRAIN_NAME", 
    A01F03 "DEPARTURE_STATION", 
    A01F04 "ARRIVAL_STATION", 
    A01F05 "DEPARTURE_TIME", 
    A01F06 "ARRIVAL_TIME"
FROM TRA01 WHERE A01F01 = 1;

-- Commit the transaction to make changes permanent
COMMIT;

-- Select data after committing
SELECT 
	A01F02 AS "TRAIN_NAME", 
    A01F03 "DEPARTURE_STATION", 
    A01F04 "ARRIVAL_STATION", 
    A01F05 "DEPARTURE_TIME", 
    A01F06 "ARRIVAL_TIME"
FROM TRA01 
WHERE A01F01 = 1;

-- Start a transaction
START TRANSACTION;

-- Update data
UPDATE TRA01
SET A01F02 = 'New Express 101'
WHERE A01F01 = 2;

-- Select data (before rolling back)
SELECT 
	A01F02 AS "TRAIN_NAME", 
    A01F03 "DEPARTURE_STATION", 
    A01F04 "ARRIVAL_STATION", 
    A01F05 "DEPARTURE_TIME", 
    A01F06 "ARRIVAL_TIME"
FROM TRA01 WHERE A01F01 = 2;

-- Rollback the transaction to undo the changes
ROLLBACK;

-- Select data after rolling back
SELECT 
	A01F02 AS "TRAIN_NAME", 
	A01F03 "DEPARTURE_STATION", 
    A01F04 "ARRIVAL_STATION", 
    A01F05 "DEPARTURE_TIME", 
    A01F06 "ARRIVAL_TIME"
FROM TRA01 WHERE A01F01 = 2;

   
  