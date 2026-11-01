# OSDU
.NET 10 backend, SQL Server database OSDU, EF Core code-first.

Architecture: OSDU.Api (HTTP controllers and composition root) -> OSDU.Business (services and validated input) -> OSDU.Data (entities, repositories, DbContext and migrations).
These are three logical layers deployed as one backend application.

## Run
From this directory:
    dotnet tool restore
    dotnet ef database update --project OSDU.Data --startup-project OSDU.Api
    dotnet run --project OSDU.Api --urls http://localhost:5080

The development connection targets localhost\SQL25 using Windows authentication.
Override ConnectionStrings__OSDU for another server. Use a trusted certificate in production.
Endpoints: GET/POST /api/assets; GET/PUT/DELETE /api/assets/{id}.
POST/PUT JSON: {"name":"Example asset","description":"Sample"}
GET lists the first 100 assets. OpenAPI: /openapi/v1.json in Development.

## Add a model/table
1. Add a C# entity in OSDU.Data and a DbSet plus configuration in OsduDbContext.
2. Generate a migration:
    dotnet ef migrations add AddYourModel --project OSDU.Data --startup-project OSDU.Api
3. Review the migration, then apply:
    dotnet ef database update --project OSDU.Data --startup-project OSDU.Api
Changing a C# model alone does not update SQL Server.

## Deployment
    dotnet publish OSDU.Api -c Release -o publish
    dotnet ef migrations script --idempotent --project OSDU.Data --startup-project OSDU.Api -o deploy.sql
Apply the reviewed SQL script to the target database, set ConnectionStrings__OSDU, then host the publish directory with .NET 10 on IIS or Kestrel behind HTTPS.
This starter has no authentication; add authentication and authorization before exposing write endpoints publicly.
