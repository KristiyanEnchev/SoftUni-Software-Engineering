--- Problem - 14

UPDATE [Countries]
SET [CountryName] = 'Burma'
WHERE [CountryName] = 'Myanmar'

INSERT INTO [Monasteries]([Name], [CountryCode]) VALUES
('Hanga Abbey', (SELECT [CountryCode] FROM [Countries] WHERE [CountryName] = 'Tanzania'))
INSERT INTO [Monasteries]([Name], [CountryCode]) VALUES
('Myin-Tin-Daik', (SELECT [CountryCode] FROM [Countries] WHERE [CountryName] = 'Maynmar'))

SELECT ct.ContinentName, c.CountryName, COUNT(m.Id) AS MonasteriesCount
FROM Continents ct
  LEFT JOIN Countries c ON ct.ContinentCode = c.ContinentCode
  LEFT JOIN Monasteries m ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
GROUP BY ct.ContinentName, c.CountryName
ORDER BY MonasteriesCount DESC, c.CountryName