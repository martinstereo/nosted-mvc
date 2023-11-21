# Nøsted & - programmeringsprosjekt

### Gjennomgang av prosjektet:
*Youtube video lenke*

## Hvordan bruke applikasjonen

### Start Applikasjonen
#### Gå inn i applikasjonsmappen
`cd nosted-mvc.MVC`
#### Bygg og start Docker Container med webappplikasjon:
1. `docker image build -t webapp .`
2. `docker container run --rm -it -d --name webapp --publish 80:80 webapp`


### Opprett Databasen
#### 1. Start a mariadb container using the localdirectory "database" to store the data:
|Bash (Mac and Linux)|CMD (Windows)|
|--------------------|--------------------|
|`docker run --rm --name mariadb -p 3308:3306/tcp -v "$(pwd)/database":/var/lib/mysql -e MYSQL_ROOT_PASSWORD=12345 -d mariadb:10.5.11`|`docker run --rm --name mariadb -p 3308:3306/tcp -v "%cd%\database":/var/lib/mysql -e MYSQL_ROOT_PASSWORD=12345 -d mariadb:10.5.11`|

#### 2. Enter the database and create the database and table for this skeleton:
`docker exec -it mariadb mysql -p`
When prompted enter the password (`12345`)



## Hvordan navigere applikasjonen
### - Log Inn
Skriv inn innlogging informasjonen, tilgitt fra Administrator.

### Home
Dette er en oversikt over hovedapplikasjonene ved programmet.
Ordre, Sjekkliste, Serviceskjema, Brukere, Rapport, Utstyrbehandling & Reservedeler.

### Ordre
Her har vi en oversikt over alle ordre og den sine tilsvarende sjekkliste og service skjema.
#### 1. Lag ny Ordre: (Administrator) Her kan det raskt opprettes en ny ordre. Fyll inn alle felt om Kunden, Produkt og Service Dato. Ved fullførelse vil den nye ordren bli lagt til i oversikten. Hver ordre vil ha kommende funksjoner.
#### 2. Sjekkliste: Trykk på denne knappen på den bestemte Ordren. Da kan legge til og lagre informasjon underveis, mens vinsjen igjennom avdelingene. Hver "Ok" knap for hver avdeling autofiller alle sjekkene for OK i avdelingen 
#### 3. Service Skjema: Her avtales det hva som burde repareres ut ifra sjekklisten, og diverse deler og arbeids krav blir ført inn.
#### 4. Detaljer: Gir en simple oversikt over hva som er lagret i den bestemte ordren.
#### 5. Rediger: Gjør det mulig å endre informasjonen til bestemte ordre (sjekkliste og service skjema kan også redigeres ved å åpne den ønskede og lagre endringene slik som i steg 2. & 3.)
#### 6. Slett: (Administrator) Det er bare bestemte roller som har muligheten til å utføre denne handlingen. Det er fordi at selv om det er en sikkehetssjekk på at handlingen faktisk ønskes gjennomført, blir mye data slettet.
           (Hele Ordren og avhengihetene dens vil gå tapt.)

#### Sjekkliste & Service Skjema
Her er en oversikt over alle som er opprettet. Det kan lastes ned PDF-Dokument av ønsket Id nummer.

#### Brukeradminstrasjon (Adminstrator)
Dette er en oversikt over alle brukere og gir en mulighet til å lage ny bruker til ansatte eller slette brukere som ikke lenger er i bruk.

#### Rapport Utstyrbehandling & Reservedeler
Disse sidene er fåreløpig ikke i bruk og har ingen hensikt. Dem eksisterer hvis det ønskes å implementere disse nettsidene i fremtiden.
Nettsidene displayer hvordan det kunne ha vært.


### Systemarkitektur

