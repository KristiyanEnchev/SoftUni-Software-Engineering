
--- Problem - 23

USE Hotel

UPDATE [Payments]
	SET [TaxRate] -= [TaxRate] * 0.03

SELECT [TaxRate] FROM [Payments]


--- Problem - 24

SELECT * FROM [Occupancies]

TRUNCATE TABLE [Occupancies]