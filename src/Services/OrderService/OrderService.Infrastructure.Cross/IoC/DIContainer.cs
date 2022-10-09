using EventBus.Base.Abstraction;
using EventBus.Base.Configurations;
using EventBus.Factory;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Application.Repositories.Abstraction;
using OrderService.Domain.Mapping;
using OrderService.Infrastructure.Repository;
using RabbitMQ.Client;

namespace OrderService.Infrastructure.Cross.IoC
{
    public static class DIContainer
    {
        public static void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            //todo
            var connStr = "Server=localhost;Database=eCommerceDB;Trusted_Connection=True;";

            var _sessionFactory = Fluently.Configure()
                                      .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connStr))
                                      .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OrderMap>())
                                      .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OrderItemMap>())

                                      .BuildSessionFactory();


            services.AddScoped(factory =>
            {
                return _sessionFactory.OpenSession();
            });


            services.AddSingleton<IEventBus>(serviceProvider =>
                {
                    EventBusConfig config = new()
                    {
                        ConnectionRetryCount = 5,
                        EventNameSuffix = "IntegrationEvent",
                        SubscriberClientAppName = "OrderService",
                        DefaultTopicName= "eCommerceEventBusTopic",
                        EventBusType = EventBusType.RabbitMQ,
                        //Default Settings
                        //Connection = new ConnectionFactory()
                        //{
                        //    HostName = "localhost",
                        //    Port = 15672,
                        //    UserName = "guest",
                        //    Password = "guest",
                        //    VirtualHost="/"
                        //}
                    };
                    return EventBusFactory.Create(config, serviceProvider);
                });

     

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IOrderService, Application.Repositories.Concrete.OrderService>();
        }
    }
}
