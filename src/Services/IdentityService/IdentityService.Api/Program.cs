using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using IdentityService.Api.Domain.Mapping;
using IdentityService.Api.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//todo
//var connStr = builder.Configuration.GetSection("ConnectionStrings");
var connStr = "Server=localhost;Database=eCommerceDB;Trusted_Connection=True;";
var _sessionFactory = Fluently.Configure()
                          .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connStr))
                          .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                          .BuildSessionFactory();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddSession();

builder.Services.AddScoped(factory =>
{
    return _sessionFactory.OpenSession();
});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IdentityService.Api.Application.Repositories.Abstraction.IIdentityService, IdentityService.Api.Application.Repositories.Concrete.IdentityService>();

//builder.Services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
//builder.Services.AddSession();

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
//app.UseSession();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
