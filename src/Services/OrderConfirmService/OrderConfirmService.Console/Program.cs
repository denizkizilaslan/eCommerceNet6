using EventBus.Base.Abstraction;
using EventBus.Base.Configurations;
using EventBus.Factory;
using Microsoft.Extensions.DependencyInjection;
using OrderConfirmService.Console.Events.EventHandlers;
using OrderConfirmService.Console.Events.Events;

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

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Consumer running...");
//System.Console.ReadLine();
