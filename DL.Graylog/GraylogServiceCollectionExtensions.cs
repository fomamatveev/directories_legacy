using Serilog;
using Serilog.Events;
using Serilog.Sinks.Graylog;

namespace DL.Graylog;

public static class GraylogServiceCollectionExtensions
{
    public static IServiceCollection AddGraylog(this IServiceCollection serviceCollection)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Graylog(new GraylogSinkOptions
            {
                HostnameOrAddress = "localhost",
                Port = 12201,
                TransportType = Serilog.Sinks.Graylog.Core.Transport.TransportType.Udp,
                UseSsl = true,
                MinimumLogEventLevel = LogEventLevel.Information,
            })
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Error)
            .CreateLogger();

        serviceCollection.AddLogging(c => c.AddSimpleConsole().AddSerilog());

        return serviceCollection;
    }
}