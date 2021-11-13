USE EmployeeSales;
GO

IF OBJECT_ID('dbo.Employee') IS NULL
BEGIN
	CREATE TABLE Employee (
		Id					INT IDENTITY(1,1)	NOT NULL
		,FirstName			NVARCHAR(300)		NOT NULL
		,LastName			NVARCHAR(300)		NOT NULL
		,HireDate			DATETIME2			NOT NULL
		,StoreId			INT					NOT NULL
		,EmploymentStatusId	TINYINT				NOT NULL
		,CONSTRAINT PK_Employee 
			PRIMARY KEY (Id)
		,CONSTRAINT FK_Employee_Store 
			FOREIGN KEY (StoreId)
			REFERENCES dbo.Store (Id)
		,CONSTRAINT FK_Employee_EmploymentStatus
			FOREIGN KEY (EmploymentStatusId)
			REFERENCES dbo.EmploymentStatus (Id)
	);

	-- Creating Indexes
	CREATE INDEX IX_Employee_StoreId_EmploymentStatusId
	ON dbo.Employee (StoreId, EmploymentStatusId)
END
GO