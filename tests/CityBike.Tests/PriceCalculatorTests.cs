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
}