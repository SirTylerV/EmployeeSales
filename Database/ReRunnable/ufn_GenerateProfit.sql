USE EmployeeSales
GO

/*
*	This Function is to take a wholesale price and then calculate a random % increase between 0 and 100
*	@id: This is not used but needed. This value needs to be unique for each row or the function value will reuse the same result for all common inputs
*	@wholesale: The base value to apply the random percent profit for the saleprice
*/
CREATE OR ALTER FUNCTION dbo.ufn_GenerateProfit(
	@id				BIGINT
	,@wholesale		DECIMAL(8,2)
)
RETURNS @generateRandomProfit TABLE (
	IncreasePercent		DECIMAL(3,2)	NOT NULL
	,SalePrice			DECIMAL(10,2)	NOT NULL
)
AS
BEGIN
	-- Needed to add the RAND() to a view because passing it in will not generate random values correctly
	-- and RAND() is not allowed to be used in functions. This is a way around that.
	DECLARE 
		@randomValue DECIMAL (3,2) = (SELECT TOP(1) * FROM vw_GetRandSalePercentProfit);

	INSERT INTO @generateRandomProfit (IncreasePercent, SalePrice)
	VALUES (
		@randomValue
		,(@wholesale + (@wholesale * @randomValue))
	);
	RETURN;
END;
GO