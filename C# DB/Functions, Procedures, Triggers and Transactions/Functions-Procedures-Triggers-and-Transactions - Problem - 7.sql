--- Problem - 7

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(20), @word NVARCHAR(20))
RETURNS BIT
AS
BEGIN
		SET @setOfLetters = LOWER(@setOfLetters)
		SET @word = LOWER(@word)
		DECLARE @CurrentIndex INT
		SET @CurrentIndex = 1
		WHILE (@CurrentIndex <= LEN(@word))
			BEGIN
					DECLARE @CurrentChar CHAR
					SET @CurrentChar = SUBSTRING(@word,@CurrentIndex,1 )
					IF (CHARINDEX(@CurrentChar,@setOfLetters) = 0)
					BEGIN
						RETURN 0
					END
					SET @CurrentIndex += 1
			END
   RETURN 1
END