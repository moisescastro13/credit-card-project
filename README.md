# CREDIT CARD APP


# Create Database

	- Run docker compose 
	docker-compose up -d
	path: CreditCardApi/CreditCardApi.Infrastructure/db
	- Create Database
	run first statement in sql file
	path: CreditCardApi/CreditCardApi.Infrastructure/db/script.sql

## Create tables

	- Run the command update-database
	Update-Database -Project CreditCardApi.Infrastructure

## Create Stored Procedures

	- Create Type
	run the second statement in sql file to create a table type
	path: CreditCardApi/CreditCardApi.Infrastructure/db/script.sql
	- Create Type
	run the both statement that contains create procedure
	path: CreditCardApi/CreditCardApi.Infrastructure/db/script.sql
