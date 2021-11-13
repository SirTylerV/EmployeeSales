USE EmployeeSales
GO

/*
*	This View is to get around the inability to use ther RAND() inside of a fucntion
*   This view will return a a number between 0 and 1 inclusive because of the rounding
*/
CREATE OR ALTER VIEW vw_GetRandSalePercentProfit
AS
SELECT ROUND(RAND(), 2) AS PercentProfit