USE EmployeeSales;
GO

IF OBJECT_ID('dbo.Product') IS NULL
BEGIN
	CREATE TABLE Product (
		Id					INT IDENTITY(1,1)	NOT NULL
		,[Name]				NVARCHAR(500)		NOT NULL
		,[Description]		NVARCHAR(MAX)		NULL
		,Wholesale			DECIMAL(8,2)		NOT NULL
		,CONSTRAINT PK_Product
			PRIMARY KEY (Id)
	);
END
GO