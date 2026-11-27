# Testnivåkarta CityBike

## T1

Nivå: enhet
Motivering: Testet kontrollerar att PriceCalculator beräknar rätt pris utan att använda databas eller andra systemdelar.

## T2

Nivå: enhet
Motivering: Testet kontrollerar att PriceCalculator följer regeln om maxpriset på 250 kr utan att använda andra systemdelar.

## T3

Nivå: integration
Motivering: Testet kontrollerar att API:et och SQL Server-databasen fungerar tillsammans genom att en ny resa sparas i tabellen Trips.

## T4

Nivå: enhet
Motivering: Testet kontrollerar att BookingService anropar upplåsningsklienten exakt en gång. Eftersom en testdubbel används testas tjänsten isolerat.

## T5

Nivå: system
Motivering: Testet kontrollerar hela upplåsningsflödet där kundappen, API:et och en simulerad styrenhet samarbetar.

## T6

Nivå: acceptans
Motivering: Tre riktiga kunder testar att registrera sig, boka och avsluta en resa utan hjälp, och projektledaren avgör om resultatet är godkänt.

## T7

Nivå: integration
Motivering: Testet kontrollerar att repositoryt kan spara och hämta GPS-positioner från en riktig SQL Server-databas.

## T8

Nivå: system
Motivering: Testet kontrollerar systemets svarstider vid 500 samtidiga användare i en driftlik testmiljö.

## T9

Nivå: enhet
Motivering: Testet kontrollerar att metoden AgeValidator.IsAdult hanterar åldersgränsen på 18 år korrekt utan att använda andra systemdelar.

## T10

Nivå: acceptans
Motivering: Ekonomiansvarig kontrollerar att kvittot följer prisreglerna P1 till P3 och avgör om resultatet är godkänt.

## T11

Nivå: integration
Motivering: Testet kontrollerar att API:et nekar åtkomst för användare som inte är inloggade genom att använda en riktig HTTP-stack i testservern.

## T12

Nivå: system
Motivering: Testet kontrollerar att hela resflödet fungerar, från registrering och bokning till återlämning och betalning, där flera systemdelar samarbetar.

## T13

Nivå: enhet
Motivering: Testet kontrollerar att metoden EmailValidator.IsValid avvisar en ogiltig e-postadress utan att använda andra systemdelar.

## T14

Nivå: acceptans
Motivering: Kundtjänsten testar tolv användarfall i adminpanelen och godkänner resultatet genom att skriva under ett protokoll.

## T15

Nivå: integration
Motivering: Testet kontrollerar att StationService och databasen fungerar tillsammans och returnerar rätt antal lediga cyklar.

## T16

Nivå: system
Motivering: Testet kontrollerar att firmwareuppdateringen fungerar på 20 styrenheter och att alla fortfarande kan låsa upp och rapportera position efter uppdateringen.

## Sammanställning

Enhet: 5 st = T1, T2, T4, T9, T13
Integration: 4 st = T3, T7, T11, T15
System: 4 st = T5, T8, T12, T16
Acceptans: 3 st = T6, T10, T14

Fördelningen liknar testpyramiden eftersom vi har flest enhetstester och färre tester på de högre nivåerna, men skillnaden mellan nivåerna är ganska liten.

## Eget testfall

Krav: Om batteritemperaturen överstiger 60 °C ska laddningen avbrytas inom 2 sekunder och ett larm skickas till teknikerna inom 5 sekunder.
Givet: En cykel är ansluten till laddning och batteritemperaturen är 40 °C.
När: Batteritemperaturen simuleras till 65 °C.
Då: Laddningen ska avbrytas inom 2 sekunder och ett larm skickas till teknikerna inom 5 sekunder.
Nivå: integration
Testtyp: Icke-funktionellt, svartlådetest.

## Kontrollfrågor

### Fråga 1

  En resa på 61 sekunder debiteras 12,50 kr i stället för 15 kr. På vilken nivå hittar du felet billigast, och vilket testfall (T-nummer) ligger närmast att fånga det?

svar: Felet hittas billigast med ett enhetstest eftersom det handlar om prisberäkningen. T1 ligger närmast eftersom det testar PriceCalculator. Ett nytt test med 61 sekunder skulle kontrollera att tiden avrundas uppåt till två minuter och att priset blir 15 kr.

### Fråga 2

  Vilket av testfallen T1 till T16 var svårast att placera, och mellan vilka två nivåer tvekade du?

svar: T10 var svårast att placera eftersom jag först tänkte att det var ett systemtest. Jag tvekade mellan systemtest och acceptanstest, men kom fram till att det är ett acceptanstest eftersom ekonomiansvarig granskar och godkänner kvittot.
