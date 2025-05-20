using System.CommandLine;
using ConsoleApp.Commands;
using Microsoft.Extensions.Logging;
using Moq;

namespace ConsoleApp.Tests.Commands;

public class CalculatorCommandShould
{
    private readonly Mock<ILogger<CalculatorCommand>> _mockLogger;
    private readonly Command _command;

    public CalculatorCommandShould()
    {
        _mockLogger = new Mock<ILogger<CalculatorCommand>>();
        _command = new CalculatorCommand(_mockLogger.Object).Create();
    }

    [Fact]
    public async Task LogCorrectSum_WhenGivenCommaSeparatedNumbers()
    {
        var exitCode = await _command.InvokeAsync("--values 3,4,5");

        Assert.Equal(0, exitCode);

        _mockLogger.Verify(
            logger => logger.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((o, _) =>
                    o.ToString()!.Contains("Sum of the values [3,4,5] is 12")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once
        );
    }

    [Fact]
    public async Task LogError_WhenGivenEmptyInput()
    {
        var exitCode = await _command.InvokeAsync("--values ");

        Assert.Equal(1, exitCode);
    }
}