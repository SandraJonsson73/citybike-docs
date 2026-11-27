# Test, verifiering och certifiering

Det här repositoryt innehåller mitt arbete från kursen **Test, verifiering och certifiering**, som ingår i min utbildning till systemutvecklare .NET.

Under kursen arbetar jag med mjukvarukvalitet, testning och olika regelverk. I uppgifterna utgår jag från det fiktiva cykeluthyrningssystemet CityBike.

## Projektstruktur

### citybike-docs – Dokumentation

Här finns dokumentation från kursens tidigare moment.

Jag har bland annat arbetat med:

- Kvalitetsanalys utifrån ISO/IEC 25010.
- Testnivåer och teststrategier.
- GDPR och hantering av personuppgifter.
- CE-märkning och relevanta regelverk.
- Granskning av krav och dokumentation.

### citybike-code – Kod och tester

Här finns C#-koden och de automatiserade testerna.

Projektet innehåller tre klasser:

- **PriceCalculator** – beräknar kostnaden för en cykeltur.
- **AgeValidator** – kontrollerar om en person är myndig.
- **EmailValidator** – kontrollerar om en e-postadress har ett giltigt format enligt programmets regler.

Jag använder **xUnit** för att testa funktionerna och har bland annat arbetat med gränsvärdestestning, ekvivalensklasser och regressionstester.

Under arbetet har jag också upptäckt och rättat fel i koden med hjälp av tester.

## Testresultat

Projektet innehåller för närvarande **23 godkända tester**.

För att köra testerna från repositoryts huvudmapp:

```bash
dotnet test citybike-code/tests/CityBike.Tests
```

## Tekniker och verktyg

- C# och .NET 11
- xUnit
- Visual Studio Code
- Git och GitHub
- Markdown för dokumentation

## Syfte

Syftet med arbetet är att få en bättre förståelse för hur tester kan användas för att upptäcka fel och säkerställa att ett system fungerar som det ska.

Jag har också fått arbeta med hur kvalitet, säkerhet, dokumentation och regelverk påverkar utvecklingen av ett system.

Repositoryt uppdateras efter hand som jag arbetar vidare med kursen.
