using ProductService.Api.Extensions;
using ProductService.Infrastructure.Cross.IoC;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
ElasticLogger.ConfigureSeriLog(builder.Configuration);
// Add services to the container.
DIContainer.RegisterDependencies(builder.Services, builder.Configuration);


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
