USE EmployeeSales;
GO

IF OBJECT_ID('dbo.EmploymentStatus') IS NULL
BEGIN
	CREATE TABLE EmploymentStatus (
		Id				INT			NOT NULL
		,StatusName		VARCHAR(10)	NOT NULL
		,CONSTRAINT PK_EmploymentStatus PRIMARY KEY (Id)
	);

	-- Since this is a static data table data will be added now
	INSERT INTO EmploymentStatus 
	VALUES (1, 'Active')
			,(2, 'Inactive')
END
GO