namespace MyApi.Services;

public class Calculator : ICalculator
{
    public int Add(int a, int b) => a + b;

    public int Mul(int a, int b) => a * b;

    public int Sub(int a, int b) => a - b;
}
