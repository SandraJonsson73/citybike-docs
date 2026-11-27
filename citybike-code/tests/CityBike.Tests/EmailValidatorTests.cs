using CityBike.Core;
using Xunit;

namespace CityBike.Tests;

public class EmailValidatorTests
{
    private readonly EmailValidator _validator = new();

    [Fact]
    public void IsValid_ValidEmail_ReturnsTrue()
    {
        // Arrange
        string email = "anna@stad.se";

        // Act
        bool isValid = _validator.IsValid(email);

        // Assert
        Assert.True(isValid);
    }

    [Theory]
[InlineData("anna@")]
[InlineData("anna@.")]
[InlineData("@stad.se")]
[InlineData("")]
public void IsValid_InvalidEmail_ReturnsFalse(string email)
{
    // Act
    bool isValid = _validator.IsValid(email);

    // Assert
    Assert.False(isValid);
}
}