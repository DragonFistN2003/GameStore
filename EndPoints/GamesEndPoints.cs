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

        endpoints.MapPost("/games", async (CreateGameDto newGame , GameStoreContext dbcontext) =>
        {

            Game game =  newGame.ToEntity();
            
            dbcontext.Games.Add(game);
           await dbcontext.SaveChangesAsync();


            return Results.CreatedAtRoute("GetGame", new { Id = game.Id }, game.ToGameDetailsDto());
        });



        // Read / games==============================================

        endpoints.MapGet("/games", async (GameStoreContext dbcontext) =>
        {
            return await dbcontext.Games.Include(game => game.Genre).Select(game => game.ToGameSummaryDto()).AsNoTracking().ToListAsync();
        });



        // Read / game by id=========================================

        endpoints.MapGet("/games/{id}", async (int id , GameStoreContext dbcontext) =>
        {
            Game? game = await dbcontext.Games.FindAsync(id);

            return game is not null ? Results.Ok(game.ToGameDetailsDto()) : Results.NotFound("this game doesn't exist in the list");
        })
        .WithName("GetGame");



        // Update / game==============================================

        endpoints.MapPut("/games/{id}", async (int id, UpdateGameDto updatedGame , GameStoreContext dbcontext) =>
        {
            var existingGame = await dbcontext.Games.FindAsync(id);

            if (existingGame is null)
            {
                return Results.NotFound("this game doesn't exist in the list");
            }

            dbcontext.Entry(existingGame).CurrentValues.SetValues(updatedGame.UpdateEntity(id));

            await dbcontext.SaveChangesAsync();

            return Results.Ok(existingGame.ToGameDetailsDto());
        });



        // Delete / game==============================================

        endpoints.MapDelete("/games/{id}", async (int id , GameStoreContext dbcontext) =>
        {
            var game = dbcontext.Games.Where(game => game.Id == id);
            
            await game.ExecuteDeleteAsync();

            await dbcontext.SaveChangesAsync();

            return Results.NoContent();
        });
    }
}