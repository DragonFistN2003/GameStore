using GameStore.api.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure services
var connectionString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connectionString);

// Build the app
var app = builder.Build();

var lonewolf = "5 more monkeys jumping on the bed";

// Map endpoints
app.MapGamesEndpoints();

// Apply database migrations
app.MigrateDb();

// Map a test endpoint
app.MapGet("/", () => lonewolf);

app.Run();
