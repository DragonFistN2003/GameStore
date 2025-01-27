using GameStore.api.Data;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var connectionString = builder.Configuration.GetConnectionString("GameStore");                      
builder.Services.AddSqlite<GameStoreContext>(connectionString);

var lonewolf = "5 more monkieys jumping on the bed";

app.MapGamesEndpoints();

app.MapGet("/", () => lonewolf);

app.Run();
