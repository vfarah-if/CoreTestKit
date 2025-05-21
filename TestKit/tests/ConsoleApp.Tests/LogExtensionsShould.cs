using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsoleApp.Tests;

public class LogExtensionsShould
{
    [Fact]
    public void AddLoggingWithDefaultBaseline()
    {
        var builder = Host.CreateApplicationBuilder();

        builder.AddLogging();

        var serviceProvider = builder.Services.BuildServiceProvider();
        var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger("TestLogger");
        Assert.NotNull(logger);
    }
}