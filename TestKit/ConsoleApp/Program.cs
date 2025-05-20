using System.CommandLine;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsoleApp;

[ExcludeFromCodeCoverage]
public class Program
{
    public static async Task<int> Main(string[] args)
    {
        var host = CreateHost(args);
        using var scope = host.Services.CreateScope();

        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("Running test command utility");

        var rootCommand = services.GetRequiredService<RootCommand>();
        return await rootCommand.InvokeAsync(args);
    }

    private static IHost CreateHost(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

        builder.Services
            .AddApplicationCommands()
            .AddRootCommand();

        builder.ConfigureLogging();

        return builder.Build();
    }
}