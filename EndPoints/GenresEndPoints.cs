using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using GameStore.api.Data;
using GameStore.api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.api.EndPoints
{
    public static class GenresEndPoints
    {
        public static void MapGenresEndPoints(this IEndpointRouteBuilder endpoint){
            
            
            endpoint.MapGet("/genres" , async (GameStoreContext dbcontext) => {

                return await dbcontext.Genres.Select(genre => genre.ToGenreDto()).AsNoTracking().ToListAsync();
                
            });
        }
    }
}