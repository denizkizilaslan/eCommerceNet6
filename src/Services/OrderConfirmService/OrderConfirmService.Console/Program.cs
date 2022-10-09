using EventBus.Base.Abstraction;
using EventBus.Base.Configurations;
using EventBus.Factory;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderConfirmService.Console.Events.EventHandlers;
using OrderConfirmService.Console.Events.Events;
using OrderConfirmService.Console.Extensions;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;




ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
IConfiguration configuration = configurationBuilder.AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();

ElasticLogger.ConfigureSeriLog(configuration);

ServiceProvider serviceProvider = new ServiceCollection()
                                            .AddTransient<eCommerceOrderCreatedIntegrationEventHandler>()
                                            .AddSingleton<IEventBus>(serviceProvider =>
                                            {
                                                EventBusConfig config = new()
                                                {
                                                    ConnectionRetryCount = 5,
                                                    EventNameSuffix = "IntegrationEvent",
                                                    SubscriberClientAppName = "OrderService",
                                                    DefaultTopicName = "eCommerceEventBusTopic",
                                                    EventBusType = EventBusType.RabbitMQ,
                                                };
                                                return EventBusFactory.Create(config, serviceProvider);
                                            })
                                           .BuildServiceProvider();


var eventBus = serviceProvider.GetRequiredService<IEventBus>();
eventBus.Subscribe<eCommerceOrderCreatedIntegrationEvent, eCommerceOrderCreatedIntegrationEventHandler>();


Task.Delay(2000).Wait();
Console.WriteLine("Consumer running...");


Host.CreateDefaultBuilder(args)
               .UseSerilog().Build().Run();



 
