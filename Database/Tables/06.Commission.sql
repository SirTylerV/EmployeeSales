USE EmployeeSales;
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