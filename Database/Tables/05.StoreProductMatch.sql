USE EmployeeSales;
GO

IF OBJECT_ID('dbo.StoreProductMatch') IS NULL
BEGIN
	CREATE TABLE StoreProductMatch (
		StoreId				INT		NOT NULL
		,ProductId			INT		NOT NULL
		,IsActive			BIT		NOT NULL
		,CONSTRAINT PK_StoreProductMatch
			PRIMARY KEY (StoreId, ProductId)
		,CONSTRAINT FK_StoreProductMatch_Store
			FOREIGN KEY (StoreId)
			REFERENCES Store (Id)
		,CONSTRAINT FK_StoreProductMatch_Product
			FOREIGN KEY (ProductId)
			REFERENCES Product (Id)		
	);

	-- Creating Indexes
	CREATE INDEX IX_StoreProductMatch_IsActive
	ON dbo.StoreProductMatch (IsActive)
END
GO