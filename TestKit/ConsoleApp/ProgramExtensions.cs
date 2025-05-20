using System.CommandLine;
using System.Diagnostics.CodeAnalysis;
using ConsoleApp.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp;

[ExcludeFromCodeCoverage]
public static class ProgramExtensions
{
    public static IServiceCollection AddApplicationCommands(this IServiceCollection services)
    {
        return services.AddSingleton<ICalculatorCommand, CalculatorCommand>();
    }

    public static IServiceCollection AddRootCommand(this IServiceCollection services)
    {
        return services.AddTransient<RootCommand>(provider =>
        {
            var root = new RootCommand("Testing Command Line Utility.");
            var calculatorCommand = provider.GetRequiredService<ICalculatorCommand>();
            root.AddCommand(calculatorCommand.Create());
            return root;
        });
    }
}