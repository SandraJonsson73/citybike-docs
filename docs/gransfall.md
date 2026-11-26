# Gränsfall i PriceCalculator

## Värden jag testar

- 0 sekunder: 10 kr. ingen minut är påbörjad.
- 59 sekunder: 12,50 kr. Fortfarande inom första minuten.
- 60 sekunder: 12,50 kr. Exakt en minut har gått.
- 61 sekunder: 15 kr. Den andra minuten har påbörjats.
- 120 sekunder: 15 kr. Exakt två minuter har gått.
- 121 sekunder: 17,50 kr. Den tredje minuten har påbörjats.
- 5760 sekunder: 250 kr. Här når priset maxgränsen.
- 5761 sekunder: 250 kr. Maxpriset gäller även när resan fortsätter.
- -1 sekund: ArgumentOutOfRangeException. Negativ tid är inte tillåten.
- 1 sekund: 12,50 kr. Den första minuten har påbörjats.

## Varför de är intressanta

- 0 sekunder kontrollerar att upplåsningsavgiften tas ut även om resan inte påbörjas.
- 59 sekunder kontrollerar att en påbörjad minut räknas som en hel minut.
- 60 sekunder kontrollerar att priset inte höjs förrän nästa minut påbörjas.
- 61 sekunder kontrollerar att priset höjs direkt när en ny minut påbörjas.
- 120 sekunder kontrollerar att priset inte höjs innan den tredje minuten påbörjas.
- 121 sekunder: 17,50 kr. Den tredje minuten har påbörjats.
- 5760 sekunder kontrollerar att priset blir exakt 250 kr när maxgränsen nås.
- 5761 sekunder kontrollerar att priset inte överstiger 250 kr.
- -1 sekund kontrollerar att programmet säger ifrån vid ogiltig tid.
- 1 sekund kontrollerar att priset höjs direkt när resan påbörjas.
