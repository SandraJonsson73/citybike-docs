# Regelverkschecklista för CityBike

## GDPR

### G1 Radering av kundens uppgifter

Gäller: Ja
Skäl: Art. 17, kunden har rätt att få uppgifterna raderade.
Ansvarig: Backend-utvecklare
Verifieras med: Nivå integration, testtyp funktionell
Bevis: Testrapport som visar att personuppgifter som ska raderas har tagits bort från databasen och att testet är godkänt.

### G2 Personliga konton och begränsade behörigheter

Gäller: Ja
Skäl: Art. 5.1 f och Art. 32. Kundtjänsten delar konto och har tillgång till fler personuppgifter än de behöver (R4).
Ansvarig: Backend-utvecklare
Verifieras med: Nivå integration, testtyp funktionell
Bevis: Testrapport som visar att varje användare har ett eget konto och att kundtjänstrollen inte kan hämta personnummer via API:et.

### G3 Lagring och gallring av GPS-positioner

Gäller: Ja
Skäl: Art. 5.1 e. CityBike sparar GPS-positioner och reshistorik utan någon bestämd lagringstid (R2).
Ansvarig: Backend-utvecklare
Verifieras med: Nivå integration, testtyp funktionell
Bevis: Testrapport och databaslogg som visar att GPS-positioner och reshistorik raderas eller anonymiseras när den fastställda lagringstiden har passerat.

### G4 Säker lösenordshantering

Gäller: Ja
Skäl: Art. 32. CityBike använder SHA-256 utan salt för att lagra lösenord, vilket innebär en säkerhetsrisk (R11).
Ansvarig: Backend-utvecklare
Verifieras med: Nivå integration, testtyp funktionell
Bevis: Testrapport som visar att två konton med samma lösenord får olika lösenordshashar och att båda kontona kan logga in.

### G5 Information om personuppgifter

Gäller: Ja
Skäl: Art. 13. CityBike informerar inte kunderna om hur deras personuppgifter behandlas (R8).
Ansvarig: Dataskyddsansvarig och frontend-utvecklare
Verifieras med: Nivå acceptans, testtyp funktionell
Bevis: Testrapport som visar att kunderna får tydlig information om personuppgiftsbehandlingen vid registrering och kan läsa informationen innan de skapar ett konto.

## CE och produktkrav

### C1 Maskindirektivet och maskinförordningen

Gäller: Ja
Skäl: CityBikes elcyklar har en motor på högst 250 W och motorstöd upp till 25 km/h. Maskindirektivet 2006/42/EG gäller för cykeln och ersätts av maskinförordningen (EU) 2023/1230 från den 20 januari 2027.
Ansvarig: Produktansvarig
Verifieras med: Nivå system, testtyp icke-funktionell
Bevis: Riskbedömning, säkerhetsrapport och dokumenterade tester av cykelns säkerhetsfunktioner.

### C2 Standarden EN 15194

Gäller: Ja
Skäl: CityBikes elcyklar har en motor på högst 250 W och motorstöd som upphör vid 25 km/h. EN 15194 är därför en relevant säkerhetsstandard för cyklarna.
Ansvarig: Produktansvarig
Verifieras med: Nivå system, testtyp icke-funktionell
Bevis: Testrapport som visar att elcyklarna har kontrollerats mot relevanta säkerhetskrav i EN 15194.

### C3 Radioutrustningsdirektivet (RED)

Gäller: Ja
Skäl: Styrenheten innehåller ett LTE-M-modem som kommunicerar via mobilnätet. Därför omfattas styrenheten av radioutrustningsdirektivet 2014/53/EU.
Ansvarig: Produktansvarig och elektronikingenjör
Verifieras med: Nivå system, testtyp icke-funktionell
Bevis: Testrapporter från radioprovning och EMC-tester samt dokumentation som visar att tillämpliga RED-krav uppfylls.

### C4 Batterisäkerhet och batteriförordningen

Gäller: Osäkert
Skäl: Batteriförordningen (EU) 2023/1542 är relevant för cykelns batteri, men vi behöver mer information om batteriet för att avgöra om EN 50604-1 är tillämplig och vilka specifika krav som gäller.
Ansvarig: Produktansvarig och batterispecialist
Verifieras med: Nivå system, testtyp icke-funktionell
Bevis: Batteriets tekniska specifikationer, riskbedömning och testrapporter som visar att tillämpliga säkerhetskrav är uppfyllda.

### C5 Elektromagnetisk kompatibilitet (EMC)

Gäller: Ja
Skäl: CityBikes styrenhet innehåller elektronik och radioutrustning som måste uppfylla relevanta EMC-krav. För radioutrustningen ingår EMC-kraven i RED 2014/53/EU.
Ansvarig: Elektronikingenjör och produktansvarig
Verifieras med: Nivå system, testtyp icke-funktionell
Bevis: Testrapporter från EMC-provning som visar att styrenheten inte orsakar oacceptabla störningar och fungerar korrekt vid relevanta störningar.

## Cyber Resilience Act

### CRA1 Förteckning över programvarukomponenter (SBOM)

Gäller: Ja
Skäl: CityBikes styrenhet innehåller firmware med programvarukomponenter som behöver dokumenteras för att kunna identifiera och hantera sårbarheter.
Ansvarig: Firmwareutvecklare
Verifieras med: Nivå integration, testtyp icke-funktionell
Bevis: Versionshanterad SBOM med komponentnamn och versioner samt en rapport som visar att komponenterna kontrollerats mot kända sårbarheter.

### CRA2 Säkerhetsuppdateringar av firmware

Gäller: Ja
Skäl: CityBikes styrenheter kan uppdateras trådlöst och behöver kunna få säkerhetsuppdateringar när sårbarheter upptäcks.
Ansvarig: Firmwareutvecklare
Verifieras med: Nivå system, testtyp icke-funktionell
Bevis: Testrapport med firmwareversion, resultat från säkerhetskontroller och dokumentation som visar att uppdateringen installerats korrekt och att lås, GPS och batteriövervakning fungerar efteråt.

### CRA3 Hantering av sårbarhetsrapporter

Gäller: Ja
Skäl: CityBikes styrenhet innehåller firmware och företaget behöver rutiner för att ta emot, bedöma och åtgärda säkerhetssårbarheter. R11 visar även en säkerhetsbrist i backend-systemets lösenordshantering som behöver åtgärdas enligt GDPR artikel 32.
Ansvarig: Säkerhetsansvarig och firmwareutvecklare
Verifieras med: Nivå integration, testtyp funktionell
Bevis: Dokumenterad sårbarhetsrapport med riskbedömning, vidtagna åtgärder och testresultat som visar att sårbarheten är åtgärdad.

## Spårbarhet

### K1 Batteriet får inte överstiga 60 °C vid laddning

Källa: C4 – Batterisäkerhet och batteriförordningen. Även K8 i kvalitetsanalysen.
Testfall: Anslut en styrenhet till en testrigg och starta laddningen. Simulera att batteritemperaturen stiger till 65 °C. Kontrollera att laddningen avbryts inom 2 sekunder och att larmet skickas inom 5 sekunder.
Nivå och testtyp: Systemtest, icke-funktionellt.
Resultat som ska sparas: Testdatum, firmwareversion, uppmätt tid tills laddningen avbryts, uppmätt tid tills larmet skickas samt om testet är godkänt eller underkänt.
Teknisk dokumentation: Versionshanterad testrapport i PDF-format och tillhörande mätloggar sparas i företagets dokumentationssystem, kopplade till den testade firmwareversionen.

### K2 Kundtjänst ska inte kunna läsa personnummer

Källa: G2 – Personliga konton och begränsade behörigheter.
Testfall: Skapa ett testkonto med rollen CustomerSupport och en testkund med personnummer. Logga in med kundtjänstkontot och begär kunduppgifter via API:et. Kontrollera att personnumret inte finns med i svaret.
Nivå och testtyp: Integrationstest, funktionellt.
Resultat som ska sparas: Testdatum, API-version, användarroll, HTTP-statuskod, avidentifierat API-svar samt om testet blev godkänt eller underkänt.
Teknisk dokumentation: Versionshanterad testrapport och avidentifierade API-loggar sparas i företagets dokumentationssystem, kopplade till den testade API-versionen.

## Kontrollfrågor

  1. Varför är CityBike tillverkare av styrenheten, trots att en underleverantör har byggt den?
  Svar: CityBike räknas som tillverkare eftersom styrenheten släpps ut på marknaden under företagets eget varumärke. Därför ansvarar CityBike för att produkten uppfyller tillämpliga EU-krav, även om den har tillverkats av en underleverantör.

  2. Vad händer med behovet av testning när CityBike släpper en ny firmwareversion?
  Svar: När CityBike släpper en ny firmwareversion behöver systemet testas igen. Regressionstester används för att kontrollera att uppdateringen inte har påverkat befintliga funktioner eller säkerheten negativt.

  3. Vilket fält i spårbarhetskedjan gör att en inspektör kan lita på ett gammalt testresultat flera år senare?
  Svar: Fältet Resultat som ska sparas är viktigt eftersom det visar när testet genomfördes, vilken programversion som testades och vilka resultat som uppmättes. Tillsammans med den tekniska dokumentationen gör det att testresultatet kan kontrolleras i efterhand.

/////////////////////////////////////////////////////

## Tillverkaransvar

CityBike räknas som tillverkare eftersom styrenheten släpps ut på marknaden under företagets eget varumärke. Företaget ansvarar därför för att produkten uppfyller tillämpliga säkerhetskrav och EU-regler.

## CE-märkning

CE-märkning innebär att tillverkaren intygar att produkten uppfyller tillämpliga EU-krav. Det är inte en garanti för att produkten aldrig går sönder och innebär inte automatiskt att en myndighet har godkänt den.

## Radioutrustningsdirektivet (RED)

CityBikes styrenhet innehåller ett LTE-M-modem som kommunicerar via mobilnätet. Därför är radioutrustningsdirektivet RED (2014/53/EU) relevant. Direktivet innehåller krav på bland annat säkerhet, elektromagnetisk kompatibilitet och radiospektrum.

## Säkerhet vid firmwareuppdateringar

CityBike behöver säkerställa att firmwareuppdateringar kommer från en betrodd källa och inte har manipulerats. Uppdateringarna ska testas så att elektroniska lås, batteriövervakning och GPS-rapportering fortfarande fungerar korrekt.

## Dokumentation för CE-märkning

CityBike behöver ta fram teknisk dokumentation, riskbedömningar och relevanta testresultat som visar att styrenheten uppfyller tillämpliga EU-krav. Företaget ska även upprätta en EU-försäkran om överensstämmelse.

## ISO 25010 och CE-märkning

ISO 25010 hjälper CityBike att bedöma kvaliteten på mjukvaran, exempelvis säkerhet och tillförlitlighet. Standarden ersätter däremot inte de EU-krav som gäller för styrenheten och ger inte automatiskt rätt att CE-märka produkten.
