USE EmployeeSales;
GO

IF OBJECT_ID('dbo.Purchase') IS NULL
BEGIN
	CREATE TABLE Purchase (
		Id				BIGINT IDENTITY(1,1)	NOT NULL
		,EmployeeId		INT						NOT NULL
		,ProductId		INT						NOT NULL
		,CreatedAt		DATETIME2				NOT NULL
		,CommissionId	INT						NOT NULL
		,SalePrice		DECIMAL(10,2)			NOT NULL
		,CommissionMade	DECIMAL(10,2)			NOT NULL
		,CONSTRAINT PK_Purchase PRIMARY KEY (Id)
		,CONSTRAINT FK_Purchase_Employee
			FOREIGN KEY (EmployeeId)
			REFERENCES Employee (Id)
		,CONSTRAINT FK_Purchase_Product
			FOREIGN KEY (ProductId)
			REFERENCES Product (Id)
		,CONSTRAINT FK_Purchase_Commission
			FOREIGN KEY (CommissionId)
			REFERENCES Commission (Id)
	);

	-- Creating Indexes
	CREATE INDEX IX_Purchase_EmployeeId
	ON dbo.Purchase (EmployeeId)
END
GO