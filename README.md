# StudyFlowApi

## Purpose

StudyFlow API is the backend REST API developed for the StudyFlow Android application.

The API was created using ASP.NET Core and C# and provides a communication layer between the Android application and the online PostgreSQL database.

The purpose of the API is to receive requests from the StudyFlow Android application, process the requests and perform database operations.

## Architecture

The backend architecture is:

Android Application
↓
HTTPS / JSON
↓
ASP.NET Core REST API
↓
Entity Framework Core
↓
PostgreSQL
↓
Supabase

The API is hosted online using Render and connects to the PostgreSQL database hosted through Supabase.

## Technologies Used

- C#
- ASP.NET Core
- .NET 8
- Entity Framework Core 8
- Npgsql
- PostgreSQL
- Supabase
- Docker
- Render
- GitHub

## REST API Endpoints

### Test Endpoint

`GET /api/Test`

Used to confirm that the API is running.

### Health Endpoint

`GET /api/Test/health`

Used to confirm that the API service is responding.

### Module Endpoints

`GET /api/Modules`

Returns the modules stored in the database.

`GET /api/Modules/{id}`

Returns a specific module using its ID.

`POST /api/Modules`

Creates a new module.

Example request:

```json
{
  "name": "Software Development",
  "code": "SDEV301",
  "lecturer": "John Smith",
  "colour": "Blue"
}
