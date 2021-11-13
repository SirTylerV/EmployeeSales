USE EmployeeSales
GO

/*
*	This Procedure is to finish the random generating of the Purchases table and is NOT used in the application.
*	There are 3 main things this procedure will do is:
*	1) First the SalePrice of every row to be between 0% and 100% more than the Products sale price to indicate the sale
*		* To do this, the procedure will leverage the function "ufn_GenerateProfit" to calcualte the total SalePrice and percent over wholesale
*	2) Once the SalePrice is calculated, the commission percentage can be determined and the CommissionId can be set
*   3) Now that the ComissionId is set, the ComissionMade can be calculated and updated.
*/
CREATE OR ALTER PROCEDURE usp_GeneratingPurchaseData 
AS
SET NOCOUNT ON
BEGIN

	-- We can do step 1 & 2 using the function ufn_GenerateProfit
	UPDATE p
	SET 
		p.SalePrice = gp.SalePrice
		,p.CommissionId = (
			SELECT TOP (1) c.Id
			FROM Commission c
			WHERE gp.IncreasePercent >= c.ProfitEligibility
			ORDER BY c.[Percent] DESC
		)
	FROM Purchase p
	INNER JOIN Product prod
		ON p.ProductId = prod.Id
	CROSS APPLY dbo.ufn_GenerateProfit(p.Id, prod.Wholesale) gp

	-- Finally we just need to update the Commission made on the total sale
	UPDATE p
	SET 
		p.CommissionMade = (p.SalePrice * c.[Percent])
	FROM Purchase p
	INNER JOIN Commission c
		ON p.CommissionId = c.Id

END
GO