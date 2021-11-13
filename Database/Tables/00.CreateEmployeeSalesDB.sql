USE master
GO

IF DB_ID('EmployeeSales') IS NULL
BEGIN
	CREATE DATABASE EmployeeSales;
END
GO
