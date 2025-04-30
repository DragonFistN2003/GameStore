using GameStore.api.Data;
using GameStore.api.Dtos;
using GameStore.api.Entities;
using GameStore.api.Mapping;
using Microsoft.EntityFrameworkCore;

public static class GamesEndPoints
{
    public static void MapGamesEndpoints(this IEndpointRouteBuilder endpoints)
    {


        // Create / game========================================

        endpoints.MapPost("/games", (CreateGameDto newGame , GameStoreContext dbcontext) =>
        {

            Game game =  newGame.ToEntity();
            
            dbcontext.Games.Add(game);
            dbcontext.SaveChanges();


            return Results.CreatedAtRoute("GetGame", new { Id = game.Id }, game.ToGameDetailsDto());
        });



        // Read / games==============================================

        endpoints.MapGet("/games", (GameStoreContext dbcontext) =>
        {
            return dbcontext.Games.Include(game => game.Genre).Select(game => game.ToGameSummaryDto()).AsNoTracking();
        });



        // Read / game by id=========================================

        endpoints.MapGet("/games/{id}", (int id , GameStoreContext dbcontext) =>
        {
            Game? game = dbcontext.Games.Find(id);

            return game is not null ? Results.Ok(game.ToGameDetailsDto()) : Results.NotFound("this game doesn't exist in the list");
        })
        .WithName("GetGame");



        // Update / game==============================================

        endpoints.MapPut("/games/{id}", (int id, UpdateGameDto updatedGame , GameStoreContext dbcontext) =>
        {
            var existingGame = dbcontext.Games.Find(id);

            if (existingGame is null)
            {
                return Results.NotFound("this game doesn't exist in the list");
            }

            dbcontext.Entry(existingGame).CurrentValues.SetValues(updatedGame.UpdateEntity(id));

            dbcontext.SaveChanges();

            return Results.Ok(existingGame.ToGameDetailsDto());
        });



        // Delete / game==============================================

        endpoints.MapDelete("/games/{id}", (int id , GameStoreContext dbcontext) =>
        {
            var game = dbcontext.Games.Where(game => game.Id == id);
            
            game.ExecuteDelete();

            dbcontext.SaveChanges();

            return Results.NoContent();
        });
    }
}