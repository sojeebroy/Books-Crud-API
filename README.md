# BooksCRUDAPI

Lightweight ASP.NET Core Web API for basic CRUD operations on books using Entity Framework Core (code-first).

- Framework: .NET 8
- C# language version: 12.0
- EF Core: 8.x (Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.SqlServer)
- Pattern: Repository + Service + Controller
- Swagger/OpenAPI included

## Quick overview

This project exposes a single resource `Book` with endpoints to Create, Read, Update and Delete. Data is stored in SQL Server via EF Core Code-First migrations.

Entity (columns derived from the migration):
- Id (int, PK, identity)
- Title (nvarchar(150), required)
- Author (nvarchar(20), required)
- PublishedDate (date, required)

## Prerequisites

- .NET 8 SDK installed
- SQL Server instance (LocalDB, SQL Server Express, etc.)
- Visual Studio 2022 (recommended) or any editor + dotnet CLI
- (Optional) dotnet-ef for CLI migrations

## Configuration

Set your connection string in `appsettings.json`:

"ConnectionStrings": { "DefaultConnection": "Server=YOUR_SERVER;Database=BooksCRUD;Trusted_Connection=True;TrustServerCertificate=True;" }

Replace `YOUR_SERVER` (for example `localhost\\SQLEXPRESS` or `(localdb)\\MSSQLLocalDB` as appropriate).

## Project structure (important files)

- Program.cs — app startup, DI and DbContext registration
- appsettings.json — configuration and connection string
- Controllers/BookController.cs — API endpoints
- DataAccess/
  - AppDbContext.cs
  - BookConfiguration.cs (entity mapping)
- Entity/Book.cs — EF entity
- Models/BookViewModel.cs — DTO used in controllers/services
- Repository/GenericRepository.cs — generic CRUD implementation
- Repository/BookRepository.cs — repository for Book
- Services/BookService.cs — mapping + business logic
- Migrations/ — EF Core migrations (code-first)

## API Endpoints

Base route: `/api/Book`

- GET `/api/Book/GetAll` — list all books
- GET `/api/Book/GetById/{id}` — get book by id
- POST `/api/Book/Create` — create book (JSON body)
- PUT `/api/Book/Update/{id}` — update book with id (JSON body)
- DELETE `/api/Book/Delete/{id}` — delete book by id

Sample JSON body for Create / Update:
{ "id": 0, "title": "Example Title", "author": "Author Name", "publishedDate": "2024-01-01" }


## Migrations and database

Two recommended ways to create/apply migrations:

1) Using Visual Studio __Package Manager Console__ (recommended when working in VS)
- Open __Tools > NuGet Package Manager > __Package Manager Console__
- Ensure __Default Project__ is `BooksCRUDAPI` and startup project is set correctly
- Run:Add-Migration initialMigration Update-Database


2) Using dotnet CLI (requires dotnet-ef tool)
- Install tool (match EF Core version):dotnet tool install --global dotnet-ef --version 8.0.22


Notes:
- The project already references `Microsoft.EntityFrameworkCore.Tools` in the csproj.
- If you receive errors running `dotnet ef` in Visual Studio __Package Manager Console__, use the PMC commands __Add-Migration__ and __Update-Database__ instead of the dotnet-prefixed CLI.

## Examples

Create a book (curl): url "https://localhost:5001/api/Book/GetAll"


## Troubleshooting

- "dotnet : Could not execute..." in Package Manager Console:
  - Use the PMC commands __Add-Migration__ / __Update-Database__ inside the __Package Manager Console__ OR install `dotnet-ef` globally / locally and run from a terminal.
- Migration errors:
  - Verify `DefaultConnection` is valid and SQL Server is reachable.
  - Ensure the startup project and target project are set correctly when running CLI commands.
- Null reference / mapping issues:
  - The service maps between Book and BookViewModel. Validate JSON body contains required fields.

## Tests
No unit tests included in this repository.

## License
MIT — feel free to reuse and adapt.

## Maintainer
Project scaffold created for demonstration purposes.
