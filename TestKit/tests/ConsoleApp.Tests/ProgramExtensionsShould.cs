using System.CommandLine;
using System.CommandLine.Parsing;
using ConsoleApp.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp.Tests;

public class ProgramExtensionsShould
{
    private ServiceCollection _services;

    public ProgramExtensionsShould()
    {
        _services = new ServiceCollection();
        _services
            .AddLogging()
            .AddSingleton<ICalculatorCommand, CalculatorCommand>() 
            .AddRootCommand();   
    }
    
    [Fact]
    public void RegisterRootCommandWithCalculatorCommand()
    {
        var provider = _services.BuildServiceProvider();
        var rootCommand = provider.GetRequiredService<RootCommand>();
        Assert.NotNull(rootCommand);
        Assert.Contains(rootCommand.Children, symbol => symbol.Name == "add");
    }
    
    [Fact]
    public async Task ExecuteCalculatorCommand_ReturnsExpectedExitCode()
    {
        var provider = _services.BuildServiceProvider();
        var rootCommand = provider.GetRequiredService<RootCommand>();
        var parser = new Parser(rootCommand);

        var exitCode = await parser.InvokeAsync("add");

        Assert.Equal(0, exitCode);
    }
}