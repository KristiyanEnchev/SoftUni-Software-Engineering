--- Problem - 11

CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(18,4), @yearlyInterestRate FLOAT, @yaers INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	RETURN @sum * POWER((1 + @yearlyInterestRate),@yaers)
END


SELECT dbo.ufn_CalculateFutureValue (1000, 0.1, 5)