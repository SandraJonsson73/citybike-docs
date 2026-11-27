# Integrationstest: administratörsfunktionen kräver nyckel

## Syfte

Syftet med testet är att kontrollera att administratörens kundlista inte går att komma åt utan en API-nyckel. Testet ska visa att obehöriga användare nekas åtkomst.

## Förutsättningar

CityBike API startas i en testserver med hjälp av WebApplicationFactory. Testet använder ingen riktig databas och anropet skickas utan API-nyckel.

## Anrop

Ett GET-anrop skickas till /api/admin/customers utan att något X-Api-Key-huvud skickas med.

## Förväntat resultat

API:et ska returnera HTTP-statuskoden 401 Unauthorized eftersom ingen API-nyckel skickas med. Kundlistan ska inte lämnas ut.

## Hur det körs

Testet körs med kommandot `dotnet test citybike-code/tests/CityBike.Api.Tests` från repositoryts huvudmapp. När alla fem integrationstester fungerar ska resultatet visa fem godkända tester och inga misslyckade.
