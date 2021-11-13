USE master
GO

IF DB_ID('EmployeeSales') IS NULL
BEGIN
	CREATE DATABASE EmployeeSales;
END
GO

USE EmployeeSales;
GO

IF OBJECT_ID('dbo.EmploymentStatus') IS NULL
BEGIN
	CREATE TABLE EmploymentStatus (
		Id				TINYINT		NOT NULL
		,StatusName		VARCHAR(10)	NOT NULL
		,CONSTRAINT PK_EmploymentStatus 
			PRIMARY KEY (Id)
	);

	-- Since this is a static data table data will be added now
	INSERT INTO EmploymentStatus 
	VALUES (1, 'Active')
			,(2, 'Inactive')
END
GO

IF OBJECT_ID('dbo.Store') IS NULL
BEGIN
	CREATE TABLE Store (
		Id				INT IDENTITY(1,1)	NOT NULL
		,StoreName		VARCHAR(500)		NOT NULL
		,Street			NVARCHAR(500)		NOT NULL
		,[State]		VARCHAR(100)		NOT NULL
		,Zipcode		VARCHAR(20)			NOT NULL
		,CONSTRAINT PK_Store 
			PRIMARY KEY (Id)
	);
END
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

IF OBJECT_ID('dbo.Commission') IS NULL
BEGIN
	CREATE TABLE Commission (
		Id					INT					NOT NULL
		,[Percent]			DECIMAL(2,2)		NOT NULL	-- Precent commission the employee will make
		,ProfitEligibility	DECIMAL(2,2)		NOT NULL	-- Precent profit from wholesale they need to reach to get this commission level
		,CONSTRAINT PK_Commission
			PRIMARY KEY (Id)
	);

	-- Since this is a static data table data will be added now
	INSERT INTO Commission (Id, [Percent], ProfitEligibility)
	VALUES              -- *NOTE comission % is taken from total customer cost not wholesale
		(1, .00, .00)	-- 00% comission >=  0% profit
		,(2, .01, .02)	-- 01% comission >=  2% profit
		,(3, .05, .1)	-- 05% comission >= 10% profit
		,(4, .12, .2)	-- 12% comission >= 20% profit
		,(5, .28, .5)   -- 28% comission >= 50% profit
		,(6, .40, .80)	-- 40% comission >= 80% profit

END
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