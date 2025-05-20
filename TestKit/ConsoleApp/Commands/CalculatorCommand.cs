using System.CommandLine;
using Domain.Calculator;
using Microsoft.Extensions.Logging;

namespace ConsoleApp.Commands;
public interface ICalculatorCommand
{
    Command Create();
}


public class CalculatorCommand(ILogger<CalculatorCommand> logger) : ICalculatorCommand
{
    public Command Create()
    {
        var command = new Command(
            "add",
            "Add an array of numbers by command."
        );
        var delimitedNumbersOption = new Option<string>(
            name: "--values",
            description: "Numbers to add, comma delimited.",
            getDefaultValue: () =>
                "1,2"
        );
        command.Add(delimitedNumbersOption);
        command.SetHandler(Add, delimitedNumbersOption);
        return command;
    }

    private void Add(string numbersDelimited)
    {
        var numbers = numbersDelimited.Split(",").Select(int.Parse);
        var enumerable = numbers as int[] ?? numbers.ToArray();
        var result = Calculator.Sum(enumerable.ToArray());
        logger.LogInformation("Sum of the values [{numbersDelimited}] is {result}", numbersDelimited, result);
    }
}