using ApiRest.Context;
using ApiRest.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HTTP.
builder.Services.AddHttpClient("CatFactClient", client =>
{
    client.BaseAddress = new Uri("https://catfact.ninja/");
});

builder.Services.AddHttpClient("GiphyClient", client =>
{
    client.BaseAddress = new Uri("https://api.giphy.com/v1/gifs/");
});

// Registro de Servicios.
builder.Services.AddScoped<ICatFactService, CatFactService>();
builder.Services.AddScoped<IGiphyService, GiphyService>();
builder.Services.AddScoped<IHistoryService, HistoryService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyClientAppCors",
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors("MyClientAppCors");

app.UseAuthorization();
app.MapControllers();
app.Run();
