using GameStore.api.Data;
using GameStore.api.EndPoints;

var builder = WebApplication.CreateBuilder(args);

// Configure services
var connectionString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connectionString);

// Build the app
var app = builder.Build();

var lonewolf = "5 more monkeys jumping on the bed";

// Map endpoints
app.MapGamesEndpoints();

app.MapGenresEndPoints();
// Apply database migrations
await app.MigrateDbAsync();

// Map a test endpoint
app.MapGet("/", () => lonewolf);

app.Run();
