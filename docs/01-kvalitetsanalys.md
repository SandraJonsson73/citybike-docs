# Kvalitetsanalys CityBike

## 1. Observationer och egenskaper

### K1

Egenskap: Performance efficiency  
Delegenskap: Time behaviour  
Motivering: Kartan är för långsam under belastning (9 sekunder för 300 användare).

### K2

Egenskap: Reliability
Delegenskap: Fault tolerance
Motivering: Systemet hanterar inte upprepade betalningsbegäranden korrekt vid dålig uppkoppling, vilket gör att kunden debiteras två gånger för samma resa.

### K3

Egenskap: Reliability
Delegenskap: Fault tolerance
Motivering: Systemet ska fortsätta fungera trots störningar i mobiltäckningen och kunna skicka positionerna när uppkopplingen återkommer.

### K4

Egenskap: Interaction capability
Delegenskap: Learnability
Motivering: Nya användare har svårt att hitta funktionen för att avsluta resan, vilket leder till att många behöver kontakta kundtjänst.

### K5

Egenskap: Security
Delegenskap: Confidentiality
Motivering: Systemet skyddar inte kundernas reseinformation eftersom en inloggad användare kan se andra kunders resor genom att ändra ID i webbadressen.

### K6

Egenskap: Maintainability
Delegenskap: Modularity
Motivering: Prisberäkningen och bokningsflödet ligger i samma klass, vilket gör det svårt att ändra en funktion utan att riskera att påverka den andra.

### K7

Egenskap: Interaction capability
Delegenskap: Operability
Motivering: Adminpanelen är inte anpassad för surfplattor, vilket gör det svårt för teknikerna att använda funktionerna när de arbetar ute i fält.

### K8

Egenskap: Safety
Delegenskap: Hazard warning
Motivering: Om batteriet överstiger 60 grader måste laddningen stoppas och teknikerna varnas för att förhindra överhettning och eventuella skador.

### K9

Egenskap: Compatibility
Delegenskap: Interoperability
Motivering: API:et måste kunna ta emot och hantera positionsdata från både gamla och nya styrenheter trots att de använder olika dataformat.

### K10

Egenskap: Flexibility
Delegenskap: Adaptability
Motivering: Systemet är svårt att anpassa till nya städer eftersom namn, priser och zoner är hårdkodade och kräver ändringar på flera ställen.

## 2. De fyra viktigaste egenskaperna för CityBike

1. Security - Säkerhet: Det är viktigt att skydda kundernas personuppgifter så att obehöriga inte får tillgång till dem. I R4 delar kundtjänsten ett konto och har tillgång till alla kunduppgifter.
2. Reliability – Tillförlitlighet: Systemet måste fungera korrekt även om det uppstår störningar. Om betalningsbegäran skickas flera gånger kan kunden bli debiterad dubbelt, vilket kan minska förtroendet för CityBike (K2, avsnitt 4).
3. Performance efficiency – Prestanda: Systemet behöver fungera snabbt även när många använder det samtidigt. Om kartan tar för lång tid att ladda kan kunderna få svårt att hitta och boka cyklar (K1, avsnitt 3, S1)
4. Safety - Säkerhet mot skador: Det är viktigt att cyklarna är säkra att använda. Om batteriet blir för varmt måste laddningen stoppas för att förhindra brand och andra skador (K8, avsnitt 7).

## 3. Mätbara krav

### Krav 1: Security

Krav: Vid 100 testförsök där en inloggad kund begär åtkomst till en annan kunds resa ska 0 försök ge åtkomst till reseinformationen.
Mått: Antal obehöriga åtkomster vid 100 testförsök.
Gränsvärde: 0 obehöriga åtkomster.
Mätmetod: Automatiserade API-tester där en inloggad användare försöker hämta andra användares resor genom att ändra resans ID.
Hänvisning: K5, avsnitt 4 och 5.

### Krav 2: Reliability

Krav: Vid 100 testade resor där samma betalningsbegäran skickas två gånger ska varje resa debiteras exakt en gång.
Mått: Antal debiteringar per resa.
Gränsvärde: 1 debitering per resa.
Mätmetod: Automatiserade integrationstester där samma betalningsbegäran skickas två gånger och antalet genomförda debiteringar kontrolleras.
Hänvisning: K2, avsnitt 4.

### Krav 3: Performance efficiency

Krav: Kartan ska laddas inom 3 sekunder för minst 95 % av visningarna vid 300 samtidiga användare.
Mått: Tiden från att kartan öppnas tills lediga cyklar visas.
Gränsvärde: Högst 3 sekunder för minst 95 % av visningarna vid 300 samtidiga användare.
Mätmetod: Genomföra ett lasttest med 300 samtidiga användare och mäta hur lång tid det tar för kartan att laddas.
Hänvisning: K1, avsnitt 3 (S1) och 4.

### Krav 4: Safety

Krav: Om batteritemperaturen överstiger 60 °C ska laddningen avbrytas inom 2 sekunder och ett larm skickas till teknikerna inom 5 sekunder.
Mått: Tiden från att temperaturen överstiger 60 °C tills laddningen bryts och larmet skickas.
Gränsvärde: Högst 2 sekunder för att avbryta laddningen och högst 5 sekunder för att skicka larmet.
Mätmetod: Simulera en batteritemperatur över 60 °C i en testrigg och mäta hur lång tid det tar innan laddningen bryts och larmet skickas.
Hänvisning: K8, avsnitt 7.

### Beräkning av tillåten nedtid

CityBikes API ska ha 99,7 % tillgänglighet under 30 dagar.
30 dagar = 43 200 minuter.
Tillåten nedtid: 100 % - 99,7 % = 0,3 %
0,3 / 100 = 0,003
43 200 × 0,003 = 129,6 minuter.
Svar: API:et får vara otillgängligt i högst 129,6 minuter under 30 dagar.

## 4. Skillnad mot ett annat par
