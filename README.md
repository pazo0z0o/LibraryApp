# Welcome to my Interview Project

Below I list all features, helpful links, and installation steps for the project, along with the local running environment.

## Table of Contents

- [Features](#features)
- [Helpful Links](#helpful-links)
- [API Calls](#api-calls)
- [Setup Used](#setup-used)

## Features

- Database with SQL Credentials login (all permissions were created from scratch)
- MicroORM: Dapper calls with Stored Procedures
- Hybrid Development with RazorPages and API Controllers
- Simple authentication with cookie, pagination, sorting with bootstrap extension
- Search function (with jQuery) and mocking with Bogus Library
- Mostly C# server-side with repository pattern

## Helpful Links

- [Tim Correy: ASP.NET Core Web App](https://www.youtube.com/watch?v=s1bk-68aB1U)
- [Authentication & Authorization Udemy Course](https://www.udemy.com/course/complete-guide-to-aspnet-core-identity/learn/lecture/39540042#overview)
- [Bogus Library Tutorial](https://www.youtube.com/watch?v=ONJUPMYBgKI)
- [Bulk Insert with Dapper Plus](https://www.learndapper.com/bulk-operations/bulk-insert)
- [Pagination Tutorial](https://www.youtube.com/watch?v=X8zRvXbirMU)

## API Calls

Use Insomnia or Postman to hit the API Controller Endpoints. Select the appropriate call first:

- GET /books: Retrieve a list of all books : (http://localhost:5062/api/book?pageNumber=1&pageSize=10)
- GET /books/:id: Retrieve details of a specific book by its ID : (http://localhost:5062/api/book/1)
- POST /books: Add a new book : (http://localhost:5062/api/book/)
- PUT /books/:id: Update an existing book by its ID : (http://localhost:5062/api/book/1)
- DELETE /books/:id: Delete a book by its ID : (http://localhost:5062/api/book/1)

## Setup Used

- Windows 10
- Visual Studio 2022, Community Edition
- .NET version 7
- ASP.NET core Web App project
- SSMS 18.02
