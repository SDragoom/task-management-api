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

## SOLID Principles Applied

This project was designed following SOLID principles:

- **Single Responsibility Principle (SRP):** each class has a single responsibility (controllers handle HTTP, services handle business logic, repositories handle data access).
- **Open/Closed Principle (OCP):** the architecture allows extending functionality (e.g., changing persistence provider) without modifying business logic.
- **Liskov Substitution Principle (LSP):** abstractions such as `ITaskRepository` can be replaced by different implementations or mocks without affecting consumers.
- **Interface Segregation Principle (ISP):** small and focused interfaces (`ITaskService`, `ITaskRepository`) avoid unnecessary dependencies.
- **Dependency Inversion Principle (DIP):** higher-level modules depend on abstractions, enabled through dependency injection.

## RESTful API Design

This API follows RESTful principles:

- Resource-based endpoints (`/api/tasks`)
- Proper HTTP verbs (`GET`, `POST`, `PUT`, `DELETE`)
- Stateless requests
- Standard HTTP status codes
- JSON request/response format
- Consistent URI naming conventions


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

API will be available using the URLs configured in `launchSettings.json`, typically:

```text
http://localhost:xxxx
https://localhost:xxxx
```

Swagger:

```text
http://localhost:xxxx/swagger
https://localhost:xxxx/swagger
```

---

## Running tests

From solution root:

```bash
dotnet test
Expected result: all tests should pass successfully.
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