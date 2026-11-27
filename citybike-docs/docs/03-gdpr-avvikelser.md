# GDPR-avvikelser i CityBike

## Personuppgiftsinventering

- Users: Id, Name, Personnummer, Email, Phone, PasswordHash, Status och CreatedAt. Alla kolumner kan kopplas till en identifierbar kund. Namn, personnummer, e-post och telefonnummer är direkt identifierande, medan övriga uppgifter är kopplade till kundens konto.

- PaymentMethods: Id, UserId, ProviderToken, CardLast4, ExpiryMonth och ExpiryYear. Alla uppgifter är kopplade till kundens betalningsmetod och kan indirekt kopplas till en identifierbar person via UserId.

- Bikes: Id, StationId, FirmwareVersion, BatteryPercent, Status och LastSeenAt är främst tekniska uppgifter. BikeId kan kopplas till en kund via tabellen Trips, vilket gör att exempelvis cykelns ID och tidsuppgifter kan bli indirekta personuppgifter.

- Stations: Inga personuppgifter. Tabellen innehåller information om fasta cykelstationer, men stationernas positioner kan kopplas till en kunds resor genom tabellen Trips.

- Trips: Id, UserId, BikeId, StartStationId, EndStationId, StartedAt, EndedAt och PriceSek. Alla uppgifter kan kopplas till en identifierbar kund via UserId och visar bland annat när och var kunden har rest samt vad resan kostade.

- GpsPoints: Id, TripId, Latitude, Longitude och RecordedAt. Alla uppgifter kan kopplas till en identifierbar kund via TripId och UserId och visar var och när kunden har befunnit sig under en resa.

## A1

Rutin: R1
Vad: Personnummer krävs vid registrering trots att syftet kan nås på annat sätt.
Artikel: Art. 5.1 c, dataskyddslagen 3 kap. 10 §
Risk: Hög
Åtgärd: Ta bort kravet. Kontrollera ålder på annat sätt eller ta bara emot födelsedatum.
Testfall: Registrering utan personnummer ska fungera (systemtest).

## A2

Rutin: R2
Vad: GPS-positioner och reshistorik sparas utan någon bestämd lagringstid, vilket innebär att personuppgifter kan lagras längre än nödvändigt.
Artikel: Art. 5.1 e – Lagringsminimering
Risk: Hög
Åtgärd: Bestäm hur länge uppgifterna behöver sparas och inför automatisk gallring när lagringstiden har gått ut.
Testfall: Skapa testdata med resor och GPS-positioner som passerat den bestämda lagringstiden och kontrollera att de gallras automatiskt (integrationstest).

## A3

Rutin: R3
Vad: När en kund avslutar sitt konto ändras bara statusen till Inactive och personuppgifterna finns kvar i databasen.
Artikel: Art. 17 – Rätten till radering
Risk: Medel
Åtgärd: Inför en funktion som raderar eller anonymiserar personuppgifter som inte längre behöver sparas, men behåller uppgifter som måste lagras enligt lag.
Testfall: Avsluta ett testkonto och kontrollera att personuppgifter som saknar fortsatt laglig grund raderas eller anonymiseras (integrationstest).

## A4

Rutin: R4
Vad: Kundtjänsten använder ett gemensamt konto och delar lösenord i en chatt. Alla har dessutom tillgång till fler personuppgifter än de behöver, vilket ökar risken för obehörig åtkomst.
Artikel: Art. 5.1 f och Art. 32
Risk: Hög
Åtgärd: Inför personliga användarkonton och rollbaserade behörigheter så att personalen bara kan se de uppgifter de behöver.
Testfall: Logga in med ett kundtjänstkonto och kontrollera att användaren inte kan se personnummer utan särskild behörighet (integrationstest).

## A5

Rutin: R5
Vad: API:et loggar hela innehållet i varje anrop, vilket kan innebära att personnummer, lösenord och andra personuppgifter sparas i loggarna under 12 månader.
Artikel: Art. 5.1 c, Art. 5.1 e och Art. 32
Risk: Hög
Åtgärd: Begränsa loggningen till nödvändig information, maskera personuppgifter och lösenord samt inför en motiverad lagringstid med automatisk gallring.
Testfall: Skicka ett API-anrop med testuppgifter och kontrollera att personnummer och lösenord inte förekommer i loggfilen (integrationstest).

## A6

Rutin: R6
Vad: Alla kunder får automatiskt nyhetsbrev med erbjudanden utan att CityBike har säkerställt en giltig rättslig grund eller att reglerna för e-postmarknadsföring följs.
Artikel: Art. 6.1 och Art. 21.2–3, samt 19 § marknadsföringslagen
Risk: Medel
Åtgärd: Inför ett frivilligt val för nyhetsbrev vid registrering, dokumentera samtycken och gör det enkelt att avsluta prenumerationen.
Testfall: Registrera en testkund som inte väljer nyhetsbrev och kontrollera att kunden inte får reklamutskick (integrationstest).

## A7

Rutin: R7
Vad: CityBike delar kundernas e-postadresser, ID och reshistorik med en leverantör i USA utan avtal och utan att säkerställa att överföringen uppfyller GDPR.
Artikel: Art. 5.1 c, Art. 28 och Art. 44–46
Risk: Hög
Åtgärd: Teckna personuppgiftsbiträdesavtal, begränsa vilka uppgifter som delas och kontrollera att överföringen till USA har rättsligt stöd.
Testfall: Kontrollera att analysverktyget endast får anonymiserad statistik utan kundernas e-postadresser eller identifierbara resuppgifter (integrationstest).

## A8

Rutin: R8
Vad: CityBike informerar inte kunderna om hur deras personuppgifter behandlas och saknar både behandlingsförteckning och bedömning av behovet av en konsekvensbedömning.
Artikel: Art. 13, Art. 30 och Art. 35
Risk: Hög
Åtgärd: Skapa en integritetspolicy, dokumentera personuppgiftsbehandlingarna och genomför en bedömning av om en konsekvensbedömning krävs.
Testfall: Kontrollera att kunden kan läsa information om personuppgiftsbehandlingen vid registreringen och att dokumentationen finns och är godkänd (acceptanstest).

Rutin: R9
Bedömning: I ordning, under förutsättning att lagringstiden på 90 dagar är motiverad och att säkerhetskopiorna skyddas och gallras enligt fastställda rutiner.

## A9

Rutin: R11
Vad: Kundernas lösenord lagras med SHA-256 utan salt, vilket gör det lättare för angripare att knäcka lösenorden vid en dataläcka.
Artikel: Art. 32
Risk: Hög
Åtgärd: Byt till en säker lösenordshashningsmetod med unikt salt för varje lösenord, exempelvis Argon2id eller PBKDF2.
Testfall: Skapa två testkonton med samma lösenord och kontrollera att de lagrade lösenordshasharna är olika samt att båda användarna kan logga in (integrationstest).

## Incident R10

Tidpunkt för kännedom: Tisdag 3 mars 2026 kl. 14:20
Frist för anmälan: Fredag 6 mars 2026 kl. 14:20
Anmäla till IMY: Ja
Informera berörda kunder: Nej
Motivering: Personuppgifter om 2 100 kunder har skickats till en obehörig mottagare. Därför bör incidenten anmälas till IMY eftersom det finns en risk att uppgifterna sprids eller missbrukas. Filen innehåller namn, e-postadresser och telefonnummer, men inga personnummer eller lösenord. Utifrån den information som finns bedömer jag inte att det är visat att risken är så hög att kunderna måste informeras. Om utredningen visar en hög risk ska kunderna informeras.
Åtgärder för att förhindra upprepning:
  -Införa en kontroll av mottagarens e-postadress innan filer med personuppgifter skickas externt.
  -Begränsa behörigheten så att endast behörig personal kan exportera kunduppgifter.

## Kontrollfrågor

### Fråga 1

  Nämn ett giltigt skäl för att använda personnummer enligt dataskyddslagen, och förklara om det skälet gäller CityBikes registrering.
Svar: Personnummer får användas när det finns ett tydligt behov av säker identifiering. För CityBike är det inte självklart att hela personnumret behövs eftersom åldern kan kontrolleras på andra sätt. Företaget bör därför undvika att samla in fler personuppgifter än nödvändigt.

### Fråga 2

  Varför räcker det inte att ändra Users.Status till Inactive när en kund vill avsluta sitt konto?
Svar: Det räcker inte att ändra status till Inactive eftersom kundens personuppgifter fortfarande finns kvar i databasen. Enligt GDPR artikel 17 har kunden under vissa förutsättningar rätt att få sina uppgifter raderade. CityBike måste därför kunna ta bort uppgifter som inte längre behöver sparas, men får behålla sådant som måste lagras enligt lag.

### Fråga 3

  Vilken testnivå har ett test som kontrollerar att en kundtjänstroll inte kan se kolumnen Personnummer? Motivera.
Svar: Testet är ett integrationstest eftersom det kontrollerar att API:et, autentiseringen och behörighetskontrollen fungerar tillsammans. En användare med kundtjänstrollen ska inte kunna få tillgång till kundernas personnummer.
