--- Problem - 3


CREATE PROCEDURE usp_GetTownsStartingWith (@InputStr VARCHAR(MAX))
AS
BEGIN
	SELECT [Name] 
	FROM [Towns]
	WHERE [Name] LIKE (@InputStr + '%')
END 
 
EXECUTE usp_GetTownsStartingWith 'b'