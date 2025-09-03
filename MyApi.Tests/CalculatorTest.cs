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
}