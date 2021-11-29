--- Problem - 11

CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
DECLARE @count INT = (
SELECT COUNT(c.Id)
FROM [Cigars] AS c
JOIN [ClientsCigars] AS cc
ON c.[Id] = cc.[CigarId]
JOIN [Clients] AS cl
ON cc.[ClientId] = cl.[Id]
WHERE cl.[FirstName] = @name)
RETURN @count
END

SELECT dbo.udf_ClientWithCigars('Betty')

SELECT COUNT(c.Id)
FROM [Cigars] AS c
JOIN [ClientsCigars] AS cc
ON c.[Id] = cc.[CigarId]
JOIN [Clients] AS cl
ON cc.[ClientId] = cl.[Id]
WHERE cl.[FirstName] = 'Betty'