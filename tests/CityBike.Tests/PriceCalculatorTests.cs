using CityBike.Core;
using Xunit;

namespace CityBike.Tests;

public class PriceCalculatorTests
{
    private readonly PriceCalculator _calculator = new();

      // Cykelresa på 18 minuter
    [Fact]
    public void Calculate_18Minutes_Returns55()
    {
        // Act
        decimal price = _calculator.Calculate(18 * 60);

        // Assert
        Assert.Equal(55m, price);
    }

      // Upplåsningsavgift
    [Fact] 
    public void Calculate_0Seconds_ReturnsUnlockFee10()
  {
      // Act
      decimal price = _calculator.Calculate(0);

      // Assert
      Assert.Equal(10m, price);
  }

    // Maxpris 250 kr
    [Fact]
    public void Calculate_100minutes_ReturnsMaxPrice250()
    {
        // Act
        decimal price = _calculator.Calculate(100 * 60);

        // Assert
        Assert.Equal(250m, price);
    }

      // Cykelresa på 61 sekunder
    [Fact]
    public void Calculate_61Seconds_Returns15()
    {
        // Act
        decimal price = _calculator.Calculate(61);

        // Assert
        Assert.Equal(15m, price);
    }

      // Negativ tid
    [Fact]
    public void Calculate_NegativeSeconds_ThrowsArgumentOutOfRangeException()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(
          () => _calculator.Calculate(-1));
    }
  [Theory]
  [InlineData(0, 10.0)]
  [InlineData(1, 12.5)]
  [InlineData(59, 12.5)]
  [InlineData(60, 12.5)]
  [InlineData(61, 15.0)]
  [InlineData(120, 15.0)]
  [InlineData(121, 17.5)]
  [InlineData(5760, 250.0)]
  [InlineData(5761, 250.0)]
public void Calculate_BoundaryValues_ReturnsExpectedPrice(
    int seconds, double expectedPrice)
{
    // Act
    decimal price = _calculator.Calculate(seconds);

    // Assert
    Assert.Equal((decimal)expectedPrice, price);
}
  // Maxpriset
[Fact]
public void Calculate_MaxIntSeconds_ReturnsMaxPrice250()
{
    // Act
    decimal price = _calculator.Calculate(int.MaxValue);

    // Assert
    Assert.Equal(250m, price);
}
}