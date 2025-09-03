using MyApi.Services;

namespace MyApi.Tests;

public class CalculatorTest
{
    [Fact]
    public void Add_ReturnsCorrectSum()
    {
        var calc = new Calculator();
        Assert.Equal(10, calc.Add(2, 8));
    }

    [Fact]
    public void Sub_ReturnsCorrectDifference()
    {
        var calc = new Calculator();
        Assert.Equal(4, calc.Sub(10, 6));
    }

    [Fact]
    public void Mul_ReturnsCorrectProduct()
    {
        var calc = new Calculator();
        Assert.Equal(15, calc.Mul(3, 5));
    }
}