# Task Management API

Simple REST API for task management built with **ASP.NET Core 9**, following **Clean Architecture** principles and SOLID design practices.

---

## Features

- Create a task
- List all tasks
- Filter tasks by status and due date
- Get task by id
- Update a task
- Delete a task
- Input validation with FluentValidation
- Global exception handling
- Swagger documentation
- Unit tests with xUnit

---

## Technologies

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core InMemory
- Swagger / OpenAPI
- FluentValidation
- Serilog
- xUnit
- Moq
- FluentAssertions

---

## Architecture

This project follows a **Clean Architecture** approach with clear separation of responsibilities:

```text
src/
 ├── TaskManagement.Api             -> Presentation layer (Controllers, Middleware)
 ├── TaskManagement.Application     -> Business rules, DTOs, Services, Validators
 ├── TaskManagement.Domain          -> Entities, Enums, Contracts
 └── TaskManagement.Infrastructure  -> Data access, EF Core, Repositories

tests/
 └── TaskManagement.Tests           -> Unit tests
```

### Layer responsibilities

- **API**: exposes REST endpoints and handles HTTP concerns
- **Application**: contains business logic and orchestrates use cases
- **Domain**: core business entities and rules
- **Infrastructure**: persistence and external implementations

---

## Design decisions

### Why Clean Architecture?
To keep the business logic isolated from infrastructure concerns, improving maintainability and testability.

### Why Repository Pattern?
To abstract persistence details and respect dependency inversion.

### Why FluentValidation?
To centralize request validation and keep controllers clean.

### Why InMemory database?
Required by the challenge and ideal for quick local execution without external dependencies.

---

## How to run

### Clone repository

```bash
git clone <repository-url>
cd TaskManagementApi
```

---

### Restore packages

```bash
dotnet restore
```

---

### Build solution

```bash
dotnet build
```

---

### Run API

```bash
cd src/TaskManagement.Api
dotnet run
```

API will be available at:

```text
http://localhost:5027
```

Swagger:

```text
http://localhost:5027/swagger
```

---

## Running tests

From solution root:

```bash
dotnet test
```

Expected:

```text
Passed! - Failed: 0
```

---

## Example request

POST `/api/tasks`

```json
{
  "title": "Study ASP.NET Core",
  "description": "Finish technical challenge",
  "dueDate": "2026-05-20",
  "status": "Pending"
}
```

---

## HTTP status codes

| Code | Meaning |
|------|---------|
| 200 | Success |
| 201 | Created |
| 204 | No Content |
| 400 | Validation error |
| 404 | Not found |
| 500 | Internal server error |

---

## Author

Marcelo Peres