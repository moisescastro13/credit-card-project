# CREDIT CARD APP


# Create Database

- **Run docker compose**
	docker-compose up -d
	path: CreditCardApi/CreditCardApi.Infrastructure/db
- **Create Database**
	run first statement in sql file
	path: CreditCardApi/CreditCardApi.Infrastructure/db/script.sql
	
## Restore dependencies

- Run **donet restore** in all projects.

## Create tables

- **Run the command update-database**
	Update-Database -Project CreditCardApi.Infrastructure
	run this command in the NuGet console.
	
## Create Stored Procedures

- **Create Type**
	run the second statement in sql file to create a table type
	path: CreditCardApi/CreditCardApi.Infrastructure/db/script.sql
- **Create Type**
	run both statements that contains create procedure.
	path: CreditCardApi/CreditCardApi.Infrastructure/db/script.sql
