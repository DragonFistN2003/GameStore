using GameStore.api.Dtos;

public static class GamesEndPoints
{
    private static readonly List<GameDto> games = new List<GameDto>
    {
        new GameDto(
            1,
            "The Witcher 3: Wild Hunt",
            "RPG",
            29.99m,
            true,
            new DateOnly(2015, 5, 19)
        ),
        new GameDto(
            2,
            "Grand Theft Auto V",
            "Action",
            19.99m,
            true,
            new DateOnly(2013, 9, 17)
        ),
    };

    public static void MapGamesEndpoints(this IEndpointRouteBuilder endpoints)
    {
        // Create / game
        endpoints.MapPost("/games", (CreateGameDto newGame) =>
        {
            if (string.IsNullOrEmpty(newGame.Name) || string.IsNullOrEmpty(newGame.Genre) || newGame.Price <= 0 || newGame.ReleaseDate == default)
            {
                return Results.BadRequest("Invalid game data. All fields must be provided and valid.");
            }

            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.GOTY,
                newGame.ReleaseDate
            );
            games.Add(game);

            return Results.CreatedAtRoute("GetGame", new { Id = game.Id }, game);
        });

        // Read / games
        endpoints.MapGet("/games", () =>
        {
            return Results.Ok(games);
        });

        // Read / game by id
        endpoints.MapGet("/games/{id}", (int id) =>
        {
            var game = games.Find(g => g.Id == id);
            return game is not null ? Results.Ok(game) : Results.NotFound("this game doesn't exist in the list");
        }).WithName("GetGame");

        // Update / game
        endpoints.MapPut("/games/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            if (string.IsNullOrEmpty(updatedGame.Name) || string.IsNullOrEmpty(updatedGame.Genre) || updatedGame.Price <= 0 || updatedGame.ReleaseDate == default)
            {
                return Results.BadRequest("Invalid game data. All fields must be provided and valid.");
            }

            var index = games.FindIndex(game => game.Id == id);
            if (index == -1)
            {
                return Results.NotFound("this game doesn't exist in the list");
            }

            games[index] = new GameDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.GOTY,
                updatedGame.ReleaseDate
            );

            return Results.NoContent();
        });

        // Delete / game
        endpoints.MapDelete("/games/{id}", (int id) =>
        {
            var game = games.Find(g => g.Id == id);
            if (game is not null)
            {
                games.Remove(game);
                return Results.Ok(game);
            }
            return Results.NotFound();
        });
    }
}