using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GameStore.api.Data
{
    public class GameStoreContextFactory : IDesignTimeDbContextFactory<GameStoreContext>
    {
        public GameStoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GameStoreContext>();
            optionsBuilder.UseSqlite("Data Source=gamestore.db"); // Match your actual connection string or use the one in appsettings.json

            return new GameStoreContext(optionsBuilder.Options);
        }
    }
}
