# Setting up the database
This folder contains all the data to create and fill the database. There are 3 folders:

1. **Tables**
This contains the scripts to create the database and the follwing tables. They are named with a prefix of their run order starting with the DB creation.
Some of static data tables will be populated with data with these scripts as well

2. **ReRunnable**
These are all the script that can be rerun for updates. This includes StoredProcedures, Functions, and Views. The prefix naming convention for each is as follows:
	- Stored Procedures = `usp_{ProcedureName}`
	- Views = `vw_{ViewName}`
	- Function = `ufn_{FunctionName}`

3. **Data**
Here are all the scripts to populate the table with data. They are named with the prefix of their run order.


**NOTE*** Each folder also contains a _{folderName}_RunAll.sql script that is a condenced version of all the scripts. The order these folders should be fun in is:
	1) Tables
	2) ReRunnables
	3) Data
The Data needs to be run after the ReRunables because some of the data creation relies on some ReRunnable scripts