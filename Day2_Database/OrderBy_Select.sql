--Select all Albums in DESC order of Realease Date
SELECT
	*
FROM 
	Album
ORDER BY 
	ReleaseDate DESC;
	--LIMIT 1; instead of TOP 1 for basic SQL

--Select 1 Album Title in DESC order of Realease Date
SELECT
	TOP 1 Title
FROM 
	Album
ORDER BY 
	ReleaseDate DESC;
	--LIMIT 1; instead of TOP 1 for basic SQL