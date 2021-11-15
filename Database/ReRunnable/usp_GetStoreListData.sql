USE EmployeeSales
GO

/*
*	This Procedure is grabbing all the stores with their gross profit over the past year
*/
CREATE OR ALTER PROCEDURE usp_GetStoreListData 
AS
SET NOCOUNT ON
BEGIN

	DECLARE
	@date DATETIME = dateadd(year, -1, GETUTCDATE())

	SELECT 
		s.Id				'Id'
		,s.StoreName		'StoreName'
		,s.[State]			'State'
		,s.Street			'Street'
		,s.Zipcode			'ZipCode'
		,SUM(p.SalePrice)	'GrossYearlyProfit'
	FROM Store s
	INNER JOIN Employee e
		ON e.StoreId = s.Id
	INNER JOIN Purchase p
		ON p.EmployeeId = e.Id
	INNER JOIN Product prod
		ON prod.Id = p.ProductId
	WHERE p.CreatedAt >= @date
	GROUP BY 
		s.Id
		,s.StoreName
		,s.[State]
		,s.Street
		,s.Zipcode
	ORDER BY s.StoreName
END
GO