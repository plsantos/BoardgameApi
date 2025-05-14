using BoardgameApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using BoardgameApi.Repository;
using BoardgameApi.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Services
builder.Services.TryAddScoped<IMatchService, MatchService>();
builder.Services.AddAutoMapper(typeof(ApiProfile));


// Respositories
var mongoDBSettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));
builder.Services.AddDbContext<IBoardgameRepository, BoardgameDbContext>(options =>
options.UseMongoDB(mongoDBSettings.AtlasURI ?? "", mongoDBSettings.DatabaseName ?? ""));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


