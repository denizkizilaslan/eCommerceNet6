using BasketService.Api.Core.Application.Repositories;
using BasketService.Api.Extensions;
using BasketService.Api.Infrastructure.Repository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
ElasticLogger.ConfigureSeriLog(builder.Configuration);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.ConfigureAuth(builder.Configuration);
builder.Services.AddSingleton(s => s.ConfigureRedis(builder.Configuration));
builder.Services.AddScoped<IBasketService, BasketService.Api.Infrastructure.Repository.BasketService>();

builder.Services.AddControllers();
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

