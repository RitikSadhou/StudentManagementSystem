# Student Management System

## Overview

This project is developed using **ASP.NET Core 8 Web API**. It provides basic Student Management functionality with JWT Authentication, SQL Server, and a layered architecture.

## Features

* Student CRUD Operations

  * Get All Students
  * Get Student By Id
  * Add Student
  * Update Student
  * Delete Student
* JWT Authentication

  * User Registration
  * User Login
* Secure APIs using JWT
* Global Exception Handling Middleware
* Serilog Logging
* Swagger API Documentation
* SQL Server Database

## Technologies Used

* ASP.NET Core 8 Web API
* C#
* Entity Framework Core
* SQL Server
* JWT Authentication
* Serilog
* Swagger

## Project Structure

```text
StudentManagementSystem
│
├── Controllers
├── Services
├── Repository
├── Models
├── DTOs
├── Data
├── Middleware
├── Helpers
├── Logs
├── Program.cs
└── appsettings.json
```

## Database

The project uses SQL Server with the following tables:

* Students
* Users

## API Endpoints

### Authentication

| Method | Endpoint             |
| ------ | -------------------- |
| POST   | `/api/Auth/register` |
| POST   | `/api/Auth/login`    |

### Students

| Method | Endpoint            |
| ------ | ------------------- |
| GET    | `/api/Student`      |
| GET    | `/api/Student/{id}` |
| POST   | `/api/Student`      |
| PUT    | `/api/Student/{id}` |
| DELETE | `/api/Student/{id}` |

> **Note:** Student APIs are secured using JWT Authentication.

## How to Run

1. Clone the repository.
2. Open the project in Visual Studio.
3. Update the SQL Server connection string in `appsettings.json`.
4. Run the following command to create/update the database:

```bash
dotnet ef database update
```

5. Run the project:

```bash
dotnet run
```

6. Open Swagger:

```text
https://localhost:<port>/swagger
```

7. Register a user, log in, copy the JWT token, click **Authorize** in Swagger, and test the secured Student APIs.


