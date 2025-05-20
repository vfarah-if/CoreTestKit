using static Domain.Calculator.Calculator;

namespace Domain.Tests.Calculator;

public class CalculatorShould
{
    [Theory]
    [InlineData(new[] { 1, 2 }, 3)]
    [InlineData(new[] { 1, 2, 3 }, 6)]
    [InlineData(new[] { 0, 0, 0 }, 0)]
    [InlineData(new[] { -1, -2, 3 }, 0)]
    public void AddAnyNumbers(int[] values, int expected)
    {
        var actual = Sum(values);

        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Superseded by AddAnyNumbers")]
    public void AddTwoNumbers()
    {
        var actual = Sum(1, 2);

        Assert.Equal(3, actual);
    }

    [Fact(Skip = "Superseded by AddAnyNumbers")]
    public void AddThreeNumbers()
    {
        var actual = Sum(1, 2, 3);

        Assert.Equal(6, actual);
    }

}