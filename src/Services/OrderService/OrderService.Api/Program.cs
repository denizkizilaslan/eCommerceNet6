using EventBus.Base.Abstraction;
using OrderService.Api.Extensions;
using OrderService.Application.Events.EventHandlers;
using OrderService.Application.Events.Events;
using OrderService.Infrastructure.Cross.IoC;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
DIContainer.RegisterDependencies(builder.Services, builder.Configuration);

var serviceProvider = builder.Services.BuildServiceProvider();
var eventBus = serviceProvider.GetRequiredService<IEventBus>();
eventBus.Subscribe<eCommerceOrderCreatedIntegrationEvent, eCommerceOrderCreatedIntegrationEventHandler>();

builder.Services.ConfigureAuth(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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
