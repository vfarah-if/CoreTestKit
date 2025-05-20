namespace Domain.Calculator;

public static class Calculator
{
    public static int Sum(params int[] values)
    {
        return values.Sum();
    }
}