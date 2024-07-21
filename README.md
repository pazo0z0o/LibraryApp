# Welcome to my Interview Project

Bellow I will list all the features, helpfull links, and installation steps for the project, along with the local running environment

****


**Table of Contents**

[TOCM]


------------

## **Features**

##### - Database with SQL Credentials login ( all permissions were created from scratch)
##### - MicroORM : Dapper calls with Stored Procedures
##### - Hybrid Development with RazorPages and Api Controllers
##### - Simple authentication with cookie, pagination, sorting with bootstrap extension
##### - Search function(with Jquery) and mocking with Bogus Library
##### - Mostly C# server-side with repository pattern


------------
## **Helpfull links gathered during the proccess of the development**

#####**ASP.NET**

[Tim Correy : Asp.NET core Web App](https://www.youtube.com/watch?v=s1bk-68aB1U "Tim Correy : Asp.NET core Web App")

##### **Authentication & Authorization**

[UdemyCourse on Authentication/Authorization](https://www.udemy.com/course/complete-guide-to-aspnet-core-identity/learn/lecture/39540042#overview "UdemyCourse on Authentication/Authorization")

And of course my own GitHub Repository.
##### **Bogus**

- [Bogus Library tutorial](https://www.youtube.com/watch?v=ONJUPMYBgKI "Bogus Library tutorial")
- [Bulk Insert with Dapper Plus](https://www.learndapper.com/bulk-operations/bulk-insert "Bulk Insert with Dapper Plus")

##### **Unit Testing**

- [Mock-Unit Test Lesson ](https://www.youtube.com/watch?v=HYrXogLj7vg "Mock-Unit Test Lesson ")
- [Mocking In Unit Tests](https://www.youtube.com/watch?v=DwbYxP-etMY "Mocking In Unit Tests")

##### **Pagination**

- [Pagination tutorial 1](https://www.youtube.com/watch?v=X8zRvXbirMU "Pagination tutorial 1")
- [Pagination tutorial 2](https://www.youtube.com/watch?v=fhomCI3bsIM "Pagination tutorial 2")
##### **Razor Pages**
- [Razor Pages basics](https://www.youtube.com/watch?v=68towqYcQlY&t=94s "Razor Pages basics")
- [Validation for password with RegEx](https://regexr.com/3bfsi "Validation for password with RegEx")
- [BootStrap documentation](https://getbootstrap.com/docs/4.0/components/ "BootStrap documentation")

------------


## ** Notes for the application**

-** #####**The Connection string is located and drawn from appsettings.json -- Change the port if on local development or set execution on http on port 5062 in launchsettings.json file**
- #####**The Credentials for the authentication are unsafely stored in the appsettings.json as well**
- #####** Database schema exported in file form ( path: LibraryApp\BookStore_db_schema.sql)**
- #####**If  the database isn't reached through the dapper calls--Change persmissions for the BookstoreAdmin user to db_datawriter, db_datareader**
- #####**Stored Procedures.cs contains the names of the stored procedures for "safety"**
- #####**Data Transfer Objects weren't used unfortunately**
- #####**Interface IBookRepo is Generic to promote multiple uses if applicable**
- #####**Sorting in tables is spotty, doesn't work as intented unfortunately**
- #####**Insomnia app to test API endpoints**

------------

**## API CALLS**

Use Insomnia or Postman to hit the Api Controller Endpoints if you prefer. Select the appropriate call first 

**- GET /books: Retrieve a list of all books : **
http://localhost:5062/api/book?pageNumber=1&pageSize=10  
*(used for pagination with query parameters)*

**- GET /books/:id: Retrieve details of a specific book by its ID:** http://localhost:5062/api/book/1

**- POST /books: Add a new book:  **
http://localhost:5062/api/book/

**- PUT /books/:id: Update an existing book by its ID: **
http://localhost:5062/api/book/1

**- DELETE /books/:id: Delete a book by its ID:** 
http://localhost:5062/api/book/1

------------


##**Setup Used **
- Windows 10
- Visual Studio 22, Community Edition
- .NET version 7
- ASP.NET core Web App project
- SSMS 18.02




