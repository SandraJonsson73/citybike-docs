using CityBike.Core;
using Xunit;

namespace CityBike.Tests;

public class AgeValidatorTests
{
    private readonly AgeValidator _validator = new();

      // Person som är 17 år och 364 dagar gammal
    [Fact]
    public void IsAdult_Turns18Tomorrow_ReturnsFalse()
    {
        // Arrange
        DateOnly birthDate = new(2008, 3, 20);
        DateOnly today = new(2026, 3, 19);

        // Act
        bool isAdult = _validator.IsAdult(birthDate, today);

        // Assert
        Assert.False(isAdult);
    }

      // Person som är 18 år idag
    [Fact]
public void IsAdult_Turns18Today_ReturnsTrue()
{
    // Arrange
    DateOnly birthDate = new(2008, 3, 19);
    DateOnly today = new(2026, 3, 19);

    // Act
    bool isAdult = _validator.IsAdult(birthDate, today);

    // Assert
    Assert.True(isAdult);
}

  // Personen fyllde 18 år igår  
[Fact]
public void IsAdult_Turned18Yesterday_ReturnsTrue()
{
    // Arrange
    DateOnly birthDate = new(2008, 3, 18);
    DateOnly today = new(2026, 3, 19);

    // Act
    bool isAdult = _validator.IsAdult(birthDate, today);

    // Assert
    Assert.True(isAdult);
}
}