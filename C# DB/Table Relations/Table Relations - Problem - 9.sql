--- Problem - 9

USE [Geography]

SELECT *
FROM [Mountains] AS m, [Peaks] AS p
WHERE m.Id = p.MountainId AND m.MountainRange = 'Rila'

SELECT *
FROM [Peaks] AS p


--- The End Solving

SELECT m.MountainRange, p.PeakName, p.Elevation  FROM [Mountains] AS m
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC