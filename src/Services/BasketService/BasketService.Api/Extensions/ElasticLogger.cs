using Serilog.Sinks.Elasticsearch;
using Serilog;
using System.Reflection;

namespace BasketService.Api.Extensions
{
    public class ElasticLogger
    {
        public static void ConfigureSeriLog(IConfiguration configuration)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .WriteTo.Debug()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:ElasticUri"]))
                {
                    AutoRegisterTemplate = true,
                    IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
                })
                .Enrich.WithProperty("Environment", configuration["SeriLogConfig:Environment"])
                .ReadFrom.Configuration(configuration, "ElasticConfiguration")
                .CreateLogger();
        }
    }
}
