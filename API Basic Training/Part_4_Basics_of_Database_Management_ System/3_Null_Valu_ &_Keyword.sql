-- Inserting Null
INSERT INTO EMP01
(
	P01F02,
    P01F03,
    P01F04
)
VALUE
(
	"Hulk",
    NULL,
    1
);

-- Checking for Null
SELECT P01F02 FROM EMP01
WHERE P01F03 IS NULL;
