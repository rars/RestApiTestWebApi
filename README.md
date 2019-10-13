# RestApiTestWebApi

## About

This is a proof of concept for using F# to create a WebApi using AspNetCore and Entity Framework Core.

The project is based on the idea of having a WebApi for testing other RestApis. E.g. it allows keeping track of a list of
RestApi locations and then user specified tests against those locations where each test captures:

- Requests defined as a request path and body
- Expected responses are recorded as status code and JSON schema

A front end may then be created that uses this API for quickly adding regression tests using this framework and updating their expected responses as they change.

## Running

From the solution directory:

```
dotnet build .
cp testing-framework.db RestApiTestWebApi\bin\Debug\netcoreapp3.0\testing-framework.db
cd RestApiTestWebApi\bin\Debug\netcoreapp3.0\
dotnet RestApiTestWebApi.dll
```

Then go to https://localhost:5001/swagger/ to interact with the API.

Generating migration scripts:

```
# Only install the tool if you don't have it already
dotnet tool install --global dotnet-ef

# Generate new migration scripts as follows:
cd RestApiTestWebApi
dotnet ef migrations add MigrationName --project ..\DatabaseMigrations\DatabaseMigrations.csproj --context RestApiTestRepositories.DatabaseContexts.RestApiTestDataContext
# This will update the testing-framework.db in this folder only - if you need to update a different file then adjust accordingly
dotnet ef database update
```
