# Enterprise Member & Event Management Portal

Portfolio-ready **ASP.NET Core / C# / Azure SQL** n-tier application.

## Features
- ASP.NET Core Web API
- member profiles, engagement history, events and registrations
- service/repository separation
- EF Core + SQL Server/Azure SQL
- parameterized stored-procedure example and reporting view
- validation and error handling
- Application Insights telemetry integration
- health endpoint
- Docker + GitHub Actions
- xUnit tests

## Run
```bash
dotnet restore
dotnet test
dotnet run --project src/EnterprisePortal.Api
```

Configure:
```bash
ConnectionStrings__Default="Server=...;Database=...;"
APPLICATIONINSIGHTS_CONNECTION_STRING="..."
```

## Azure SQL
`database/schema.sql` contains the relational schema, a reporting view, indexes, and a parameterized stored procedure.

## Accuracy boundary
Application Insights instrumentation is wired into the application. Actual Azure alert rules and production telemetry require deployment to your Azure subscription; this repository does not claim historical production alerts or performance numbers.
