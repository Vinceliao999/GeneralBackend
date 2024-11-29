# General

## Project setup
1. Add local md: Add a .Net framework project => add item => add SQL Server File => Move to .NetCore Project under App_Data

https://www.aspsnippets.com/Articles/Using-Stored-Procedure-in-Entity-Framework-Core-Database-First-Approach.aspx

## Add autenticateion policy
In program.cs
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Authenticated", policy =>
    {

    });
});

## Run SQL Server local db on Mac Parallel Desktop
Local db: 
https://kb.parallels.com/129699#section9
SQL Server Express:
https://github.com/jimm98y/MSSQLEXPRESS-M1-Install

## BackendAndAPI
To add a new table or sp and generate API or MVC
Double click .mdf to connect the local db
1. Add a new table or sp in the database
2. Right click enfp.config.json
3. Click EFCore Power Tools - Edit
4. Add the desired table or sp
5. Add scaffolded item
6. Choose MSSQLLocalDBContext 


