using GamesLib.Services.Service.GamesService;

var builder = WebApplication.CreateBuilder(args);

{
builder.Services.AddControllers();
builder.Services.AddScoped<IGameService, GameService>();
}

var app = builder.Build();

{
app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
}