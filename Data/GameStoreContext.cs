using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.api.Data
{
    public class GameStoreContext(DbContextOptions<GameStoreContext> options) 
        : DbContext(options)
    {
        public DbSet<Game> Games => Set<Game>();
        public DbSet<Genre> Genres => Set<Genre>();
    }
}