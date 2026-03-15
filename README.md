# GameTournamentAPI

Ett ASP.NET Web API för att hantera turneringar.  
API:t använder Entity Framework Core och SQL Server för att lagra data.

## Funktioner

API:t stödjer CRUD-operationer för turneringar:

- Skapa en turnering
- Hämta alla turneringar
- Hämta en turnering via ID
- Uppdatera en turnering
- Ta bort en turnering
- Söka turneringar via titel

## Teknologier

Projektet använder:

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger (för att testa API:t)
- Dependency Injection
- DTOs
- Data validation (DataAnnotations)

## Datamodell

### Tournament

| Property | Type |
|--------|--------|
| Id | int |
| Title | string |
| Description | string |
| MaxPlayers | int |
| Date | DateTime |

## Endpoints

| Method | Endpoint | Beskrivning |
|------|------|------|
| GET | /api/tournaments | Hämta alla turneringar |
| GET | /api/tournaments/{id} | Hämta turnering via id |
| GET | /api/tournaments?search=term | Sök turneringar via titel |
| POST | /api/tournaments | Skapa ny turnering |
| PUT | /api/tournaments/{id} | Uppdatera turnering |
| DELETE | /api/tournaments/{id} | Ta bort turnering |