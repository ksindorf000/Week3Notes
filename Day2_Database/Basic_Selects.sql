--Find all entries in Band table
SELECT
	*
FROM 
	Band;

--Find all album titles of genre 'Punk'
SELECT 
	Title
FROM
	Album
WHERE
	Genre = 'Punk';

--Find Titles & Release with word 'Up'
SELECT
	Title, ReleaseDate
FROM
	Album
WHERE
	Title LIKE '%Up%' --% is called 'wild card' 

--Join Tables 
SELECT
	b.Name, a.Title
FROM 
	Band b
INNER JOIN
	Album a ON a.Band = b.Id
WHERE
	b.Name = 'NOFX';
