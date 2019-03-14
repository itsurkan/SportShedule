# ReadMe

## Start the service

1. Open project folder
2. Go to:
```yml
>cd TemplatePass
```

3. Run command:

```yml
>docker-compose up --build
```

4. Open [http://localhost:8080](http://localhost:8080) in the browser

## Run tests

1. Open UnitTests project folder with Visual Studio or Visual Studio Code
2. Go To Test Explorer
3. Run the tests

## Server API

1. CreateShedule (TournamentModel tournament) - creates new schedule for the tournament. Returns created tournament.
2. FindShedule (tournamentName) - returns tournament by name.
3. GetResults (tournamentName) - returns TournamentResultModel that contains information about games results
4. SetMatchResult (TourMatch match) - sets the points form teams depends on match result;



