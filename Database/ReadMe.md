# Setting up the database
This folder contains all the data to create and fill the database. There are 3 folders:

######Tables######
This contains the scripts to create the database and the follwing tables. They are named with a prefix of their run order starting with the DB creation.
Some of static data tables will be populated with data with these scripts as well

######Stored Procedures######
These are all the Stored Procedures for the application. These scripts are not required to be run in any certain order

######Data######
Here are all the scripts to populate the table with data. They are named with the prefix of their run order.


**NOTE*** Each folder also contains a {folderName}_RunAll.sql script that is a condenced version of all the scripts. This is for ease of creating.