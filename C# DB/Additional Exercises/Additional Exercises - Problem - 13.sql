--- Problem - 13

CREATE TABLE [Monasteries](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR (50),
	[CountryCode] CHAR(2) NOT NULL FOREIGN KEY REFERENCES [Countries]([CountryCode])
);

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

ALTER TABLE [Countries]
	ADD IsDeleted BIT NOT NULL DEFAULT 0;

ALTER TABLE [Countries]
DROP COLUMN IsDeleted

UPDATE [Countries]
SET [IsDeleted] = 1
WHERE [CountryCode] IN (
	SELECT c.[CountryCode]
	FROM [Countries] AS c
	JOIN [CountriesRivers] AS cr
	ON c.[CountryCode] = cr.[CountryCode]
	JOIN [Rivers] AS r
	ON cr.[RiverId] = r.[Id]
	GROUP BY c.[CountryCode]
	HAVING COUNT(r.[Id]) > 3
)

SELECT m.[Name] AS [Monastery],
c.[CountryName] AS [Country]
FROM [Countries] AS c
JOIN [Monasteries] AS m
ON m.[CountryCode] = c.[CountryCode]
WHERE [IsDeleted] = 0
ORDER BY m.[Name]