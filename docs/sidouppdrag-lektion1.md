# AI som granskare (sidouppdrag)

## Modell A

Namn och version: Claude Code och Sonney 5.5 High

### A1

Påstående: Gemensamt adminkonto med fullständig åtkomst (R4). Lösenordet delas i chatten, alla i kundtjänst ser alla kolumner inklusive Personnummer, och inga handlingar går att spåra till en person.
Egenskap enligt AI:n: Security, Accountability och Confidentiality
Testnivå enligt AI:n: System
Bedömning:
Skäl:

### A2

Påstående: Lösenord lagras med SHA-256 utan salt (R11). Två kunder med samma lösenord får samma hash, och hashen går snabbt att knäcka med rainbow tables.
Egenskap enligt AI:n: Security, Confidentiality och Resistance
Testnivå enligt AI:n: Enhet
Bedömning:
Skäl:

### A3

Påstående: API:et loggar hela innehållet i varje anrop och sparar loggarna i 12 månader (R5). Loggarna kan innehålla lösenord, personnummer, e-post och positioner.
Egenskap enligt AI:n: Security, Confidentiality
Testnivå enligt AI:n: Integration
Bedömning:
Skäl:

### A4

Påstående: Produktanalysverktyget i USA får e-post, Id och alla resor utan avtal (R7). Det saknas personuppgiftsbiträdesavtal och laglig grund för tredjelandsöverföring.
Egenskap enligt AI:n: Security, Confidentiality
Testnivå enligt AI:n: Integration
Bedömning:
Skäl:

### A5

Påstående: Personnummer samlas in för ålderskontroll och påminnelsefakturor (R1). Det bryter mot dataminimering, eftersom åldern kan styrkas på ett mindre ingripande sätt, och personnumret lagras dessutom i klartext.
Egenskap enligt AI:n: Security, Confidentiality (även Functional appropriateness)
Testnivå enligt AI:n: System
Bedömning:
Skäl:

### A6

Påstående: Ingen gallring, och kontoavslut gör bara kunden Inactive (R2, R3, R9). GpsPoints och Trips sparas för alltid, inga rader raderas, backuper ligger kvar i 90 dagar och det finns ingen funktion för radering eller dataportabilitet.
Egenskap enligt AI:n: Functional suitability, Functional completeness
Testnivå enligt AI:n: Integration
Bedömning:
Skäl:

### A7

Påstående: Nyhetsbrev skickas till alla kunder utan samtycke eller möjlighet att avregistrera sig (R6).
Egenskap enligt AI:n: Functional suitability, Functional appropriateness (alternativt Interaction capability, User error protection)
Testnivå enligt AI:n: Acceptans
Bedömning:
Skäl:

### A8

Påstående: Ingen integritetsinformation i appen, ingen konsekvensbedömning och ingen förteckning över behandlingar (R8). Användaren får ingen information om hur personuppgifter behandlas.
Egenskap enligt AI:n: Interaction capability, Self-descriptiveness och User assistance
Testnivå enligt AI:n: Acceptans
Bedömning:
Skäl:

### A9

Påstående: Bristande incidenthantering vid dataläckan (R10). En tekniker skickade uppgifter om 2 100 kunder till fel mottagare via manuell CSV-export. Det finns ingen rutin för anmälan till IMY inom 72 timmar (fristen gick ut den 6 mars 2026 kl. 14:20) och inget skydd mot manuell export av persondata.
Egenskap enligt AI:n: Security, Accountability och Confidentiality
Testnivå enligt AI:n: Acceptans
Bedömning:
Skäl:

## Modell B

Namn och version: Codex och GPT-6.2 Sol Medium

### B1

Påstående: Lösenord lagras med osaltad SHA-256 (R11). Identiska lösenord får samma hashvärde, vilket underlättar lösenordsgissning vid en dataläcka.
Egenskap enligt AI:n: Informationssäkerhet (Security)
Testnivå enligt AI:n: Enhet
Bedömning:
Skäl:

### B2

Påstående: Kundtjänsten använder ett gemensamt konto (R4). En åtgärd i adminpanelen kan därför inte knytas till en enskild medarbetare.
Egenskap enligt AI:n: Informationssäkerhet (Security)
Testnivå enligt AI:n: System
Bedömning:
Skäl:

### B3

Påstående: Alla i kundtjänsten kan läsa samtliga tabeller och fält (R4), även personnummer och GPS-historik som inte behövs i exempelvis ett kvittoärende.
Egenskap enligt AI:n: Informationssäkerhet (Security)
Testnivå enligt AI:n: System
Bedömning:
Skäl:

### B4

Påstående: API:et loggar hela innehållet i varje anrop och sparar loggarna i tolv månader (R5). Det innebär en risk för att lösenord och personnummer från registreringen hamnar i loggarna.
Egenskap enligt AI:n: Informationssäkerhet (Security)
Testnivå enligt AI:n: Integration
Bedömning:
Skäl:

### B5

Påstående: Resor och GPS-positioner sparas på obestämd tid utan automatisk gallring (R2). Äldre rörelsemönster kan därför ligga kvar och vara åtkomliga.
Egenskap enligt AI:n: Informationssäkerhet (Security)
Testnivå enligt AI:n: System
Bedömning:
Skäl:

### B6

Påstående: När en kund stänger sitt konto ändrar systemet bara kontots status till Inactive (R3). Kunduppgifterna ligger kvar även när kontot inte längre används.
Egenskap enligt AI:n: Funktionell lämplighet (Functional suitability)
Testnivå enligt AI:n: System
Bedömning:
Skäl:

### B7

Påstående: Alla kunder får nyhetsbrevet och registreringen innehåller inget separat val för det (R6). En kund kan därför få reklam utan att ha valt det vid registreringen.
Egenskap enligt AI:n: Funktionell lämplighet (Functional suitability)
Testnivå enligt AI:n: Acceptans
Bedömning:
Skäl:

### B8

Påstående: Analysverktyget får kundens e-postadress, kund-ID och samtliga resor (R7). Mottagaren kan därför koppla resehistoriken till en enskild kund.
Egenskap enligt AI:n: Informationssäkerhet (Security)
Testnivå enligt AI:n: Integration
Bedömning:
Skäl:

### B9

Påstående: Appen saknar information om hur personuppgifter behandlas (R8). Kunden får exempelvis ingen förklaring i appen till hur personnummer och GPS-positioner används.
Egenskap enligt AI:n: Interaktionsförmåga (Interaction capability)
Testnivå enligt AI:n: Acceptans
Bedömning:
Skäl:

## Jämförelse och reflektion
