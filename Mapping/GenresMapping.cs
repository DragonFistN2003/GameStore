using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.api.Dtos;
using GameStore.api.Entities;

namespace GameStore.api.Mapping
{
    public static class GenresMapping
    {
        public static GenresDto ToGenreDto(this Genre genre){

            return new GenresDto(genre.Id , genre.Name);
            
        }
    }
}