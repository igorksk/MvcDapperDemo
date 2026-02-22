# MvcDapperDemo

Small ASP.NET Core MVC sample demonstrating basic Dapper usage with SQLite and a simple CRUD UI using Razor views.

## What it contains
- Simple `Person` model with validation attributes
- `PersonRepository` demonstrating Dapper queries (GetAll, GetById, Create, Update, Delete)
- `PeopleController` and Razor views for list/create/edit/delete
- SQLite database file `people.db` (created automatically on startup)

## Prerequisites
- .NET 8 SDK: https://dotnet.microsoft.com/download

## Run locally
1. Restore and run:
   ```bash
   dotnet restore
   dotnet run
   ```
2. Open a browser to `https://localhost:5001` (or the URL shown in the console).
3. Use the `People` link in the navigation to view and manage people.

## Configuration
- Connection string: by default the app uses `Data Source=people.db`. To change it, add a connection string named `ConnectionStrings:Default` in `appsettings.json`.

## Notes
- The project uses Dapper for lightweight data access and `Microsoft.Data.Sqlite` for the database.
- Model validation is implemented using data annotations; client-side validation uses the existing validation partial.

## License
This repository does not include a license file. Add one if you plan to publish with an open-source license.
