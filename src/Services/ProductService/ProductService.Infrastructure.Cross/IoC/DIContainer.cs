using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Application.Repositories.Abstraction;
using ProductService.Application.Repositories.Concrete;
using ProductService.Domain.Mapping;
using ProductService.Infrastructure.Repository;

namespace ProductService.Infrastructure.Cross.IoC
{
    public static class DIContainer
    {
        public static void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            var connStr = configuration.GetSection("ConnectionStrings");

            var _sessionFactory = Fluently.Configure()
                                      .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connStr["DefaultConnection"]))
                                      .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BrandMap>())
                                      .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductMap>())

                                      .BuildSessionFactory();


            services.AddScoped(factory =>
            {
                return _sessionFactory.OpenSession();
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<IProductService, ProducttService>();
        }
    }
}
