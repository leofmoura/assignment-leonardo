using CoinManager.Application.Coins;
using CoinManager.Application.Categories;
using CoinManager.Application.Providers;
using CoinManager.Infrastructure.Gateio;
using CoinManager.Infrastructure.Kucoin;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryProvider, KucoinAPIProvider>();
builder.Services.AddScoped<ICoinService, CoinService>();
builder.Services.AddScoped<IPrimaryCoinProvider, KucoinAPIProvider>();
builder.Services.AddScoped<ISecondaryCoinProvider, GateioAPIProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/categories", async (ICategoryService categoryService) => await categoryService.GetCategories())
    .WithName("GetCategories")
    .WithOpenApi();

app.MapGet("/categories/{id}/coins", async (string id, ICoinService coinService) =>
        await coinService.GetAggregateCoinsByCategory(id))
    .WithName("GetCoinsByCategory")
    .WithOpenApi();

app.MapGet("/coins/{id}/{provider}", async (string id, string provider, ICoinService coinService) =>
        await coinService.GetCoinBySymbol(id, provider))
    .WithName("GetCoin")
    .WithOpenApi();

app.Run();