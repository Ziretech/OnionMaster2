# OnionMaster

## Spelvärld

Spelvärlden består av Objekt som har egenskaper. (Komponent-baserad struktur)

Approachen är att spara aktivt och passivt content i samma struktur (spelvärlden). Den innehåller dels det aktiva innehållet som visas och beräknas för stunden, och det passiva innehållet som är banor, inaktiva fienden, utlagda föremål, levlar etc.

## Kontroll

Spelarkaraktären läggs in som ett Objekt i spelvärlden, men har också en speciell koppling för att kunna kontrolleras av spelaren (dumt att söka igenom hela spelvärlden efter spelarkaraktären).

## Kontroll och animationer

När spelaren styr karaktären så är rörelserna animerade. När spelaren släpper tangenten så stannar karaktären (och animationen återställs, med riktningen bibehållen).

Animationer behöver hålla reda på tiden. Genom att jämföra tidpunkten då animationen startade med tidpunkten när den visas så avgör man vilken bild i animationen som ska visas.

En bild består av en enda bild medan en animation består av flera bilder. Visningstiden för varje bild är konstant (och behöver bara sättas en gång för hela animationen).
FlyttaSpelarobjekt uppdaterar status för visning och väljer vilken animation eller bild som ska visas.

Ska spelarobjektet bestå av hela animationssystemet, och där någonting väljer vilken animation som ska visas? Eftersom grafiken ska definieras i spelet så verkar det rimligt.

Hur ska de då definieras? 

Ska man ha en lista med bilder. Sedan en lista med animationer som pekar ut sekvenser med dessa bilder. Sedan ett värde för vilken animation som körs för studen (och när den startade.)
Alternativ: Ska man ha en lista med bilder och sedan attribut för varje animation, så att de har namn? Det pekas då ut med en sträng som motsvarar det attributet (eller snarare en kod som logiken kan mappa till ett attribut).
Kort sagt: Hur ska man referera saker?
 - Saker som ligger i en statisk lista kan refereras genom att man använder index.
 - Saker som inte ligger i en statisk lista kan refereras genom att man använder ett id.

För bilder är det förmodligen lättast att referera dem med index, så att man inte behöver ge dem namn.
För objekt är det förmodligen lättast att referera dem med id, eftersom listan inte är statisk.

Hur ska man göra med animationer?
 1. Lägga dem i en lista som betraktas som statisk (vilken den förmodligen är, vad skulle påverka animationerna?)
 2. Ge dem ID:n för att underlätta det faktum att animationer skulle kunna vara någonting som ligger utanför objektet. (Men då behöver också bilder ligga utanför objektet?)
 3. Istället för en lista så har man ett objekt med attribut för varje sorts animation. Finns inte animationen så lämnar man attributet som null.

Använder man IDn så behöver man söka igenom listan för att hitta rätt animation. Det är inte aktuellt att skapa ett bild- och animationsregister utanför just nu.

Om det finns väldigt många olika attribut som inte används så behöver man lagra en massa null-värden. Karaktären kommer förmodligen att ha väldigt många fler animationer, och fienden kan tänkas ha väldigt många olika typer av animationer.
Det snyggaste borde vara att använda ID:n för att särskilja dem från en lista med animationer som finns på objektet.
Varje animation har en lista med bildrutor, där varje bildruta anger bilden, visningstid och relativ positionering.
Sedan har objektet en aktivAnimation som anger vilken animation som visas och när den startades.

Strålande idé: räkna ut animationen och läs den automatiskt från formationen i texturen. Alltså att man vet att mönstret alltid är från vänster till höger, då behöver animationen bara känna till första bilden (resten har samma storlek och ligger direkt till höger).
Man behöver bara veta hur många och vilket visningsintervall den har.

Ok, ett problem. Det kommer inte att vara helt ovanligt att animationerna har olika storlek (och därför också olika relativ positionering). Det innebär att det inte går att räkna ut positionen...