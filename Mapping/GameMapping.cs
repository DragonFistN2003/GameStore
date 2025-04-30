using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.api.Dtos;
using GameStore.api.Entities;

namespace GameStore.api.Mapping
{
    public static class GameMapping
    {
        public static Game ToEntity(this CreateGameDto game){

            return new()
            {
                Name = game.Name,
                GenreId = game.GenreId,
                GOTY = game.GOTY,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };
        }

        public static Game UpdateEntity(this UpdateGameDto game , int id){

            return new()
            {
                Id = id,
                Name = game.Name,
                GenreId = game.GenreId,
                GOTY = game.GOTY,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };
        }

        public static GameSummaryDto ToGameSummaryDto(this Game game){

            return new(
                game.Id,
                game.Name,
                game.Genre!.Name,
                game.Price,
                game.GOTY,
                game.ReleaseDate
            );

        }

        public static GameDetailsDto ToGameDetailsDto(this Game game){

            return new(
                game.Id,
                game.Name,
                game.GenreId,
                game.Price,
                game.GOTY,
                game.ReleaseDate
            );
        }
    }
}