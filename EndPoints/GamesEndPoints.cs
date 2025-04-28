using GameStore.api.Data;
using GameStore.api.Dtos;
using GameStore.api.Entities;
using GameStore.api.Mapping;

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
        endpoints.MapPost("/games", (CreateGameDto newGame , GameStoreContext dbcontext) =>
        {

            Game game =  newGame.ToEntity();
            game.Genre = dbcontext.Genres.Find(newGame.GenreId);
            
            dbcontext.Games.Add(game);
            dbcontext.SaveChanges();


            return Results.CreatedAtRoute("GetGame", new { Id = game.Id }, game.ToDto());
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