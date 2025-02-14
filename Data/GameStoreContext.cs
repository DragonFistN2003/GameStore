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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Adventure" },
                new Genre { Id = 3, Name = "RPG" },
                new Genre { Id = 4, Name = "Simulation" },
                new Genre { Id = 5, Name = "Strategy" }
            );

            modelBuilder.Entity<Game>().HasData(
                new Game { Id = 1, Name = "Halo", GenreId = 1, Price = 59.99m },
                new Game { Id = 2, Name = "The Witcher 3", GenreId = 3, Price = 39.99m },
                new Game { Id = 3, Name = "The Sims 4", GenreId = 4, Price = 29.99m },
                new Game { Id = 4, Name = "Civilization VI", GenreId = 5, Price = 49.99m }
            );
        }
    }
}