using CityBike.Core;
using Moq;
using Xunit;

namespace CityBike.Tests;

public class BookingServiceTests
{
    private readonly Mock<IBikeRepository> _bikes = new();
    private readonly Mock<IUnlockClient> _unlockClient = new();
    private readonly BookingService _service;

    public BookingServiceTests()
    {
        _service = new BookingService(_bikes.Object, _unlockClient.Object);
    }

    [Fact]
    public void Book_ValidBike_UnlocksBikeExactlyOnce()
    {
        // Arrange
        _bikes.Setup(b => b.GetById(1))
              .Returns(new Bike(1, "Available", 82));

        _unlockClient.Setup(u => u.Unlock(1))
                    .Returns(true);

        // Act
        BookingResult result = _service.Book(1);

        // Assert
        Assert.Equal(BookingResult.Unlocked, result);

        _unlockClient.Verify(u => u.Unlock(1), Times.Once());
    }

    [Fact]
    public void Book_UnknownBike_ReturnsBikeNotFoundAndDoesNotUnlock()
    {
        // Arrange
        _bikes.Setup(b => b.GetById(99))
              .Returns((Bike?)null);

        // Act
        BookingResult result = _service.Book(99);

        // Assert
        Assert.Equal(BookingResult.BikeNotFound, result);

        _unlockClient.Verify(u => u.Unlock(It.IsAny<int>()), Times.Never());
    }

    [Fact]
    public void Book_BookedBike_ReturnsBikeNotAvailableAndDoesNotUnlock()
    {
        // Arrange
        _bikes.Setup(b => b.GetById(2))
              .Returns(new Bike(2, "Booked", 64));

        // Actc
        BookingResult result = _service.Book(2);

        // Assert
        Assert.Equal(BookingResult.BikeNotAvailable, result);

        _unlockClient.Verify(u => u.Unlock(It.IsAny<int>()), Times.Never());
    }

    [Fact]
    public void Book_LowBattery_ReturnsBatteryTooLowAndDoesNotUnlock()
    {
        // Arrange
        _bikes.Setup(b => b.GetById(3))
              .Returns(new Bike(3, "Available", 9));

        // Act
        BookingResult result = _service.Book(3);

        // Assert
        Assert.Equal(BookingResult.BatteryTooLow, result);

        _unlockClient.Verify(u => u.Unlock(It.IsAny<int>()), Times.Never());
    }

    [Fact]
    public void Book_BatteryExactlyAtLimit_UnlocksBike()
    {
        // Arrange
        _bikes.Setup(b => b.GetById(3))
              .Returns(new Bike(3, "Available", 10));

        _unlockClient.Setup(u => u.Unlock(3))
                    .Returns(true);

        // Act
        BookingResult result = _service.Book(3);

        // Assert
        Assert.Equal(BookingResult.Unlocked, result);

        _unlockClient.Verify(u => u.Unlock(3), Times.Once());
    }

    [Fact]
    public void Book_UnlockFails_ReturnsUnlockFailed()
    {
        // Arrange
        _bikes.Setup(b => b.GetById(1))
              .Returns(new Bike(1, "Available", 82));

        _unlockClient.Setup(u => u.Unlock(1))
                    .Returns(false);

        // Act
        BookingResult result = _service.Book(1);

        // Assert
        Assert.Equal(BookingResult.UnlockFailed, result);

        _unlockClient.Verify(u => u.Unlock(1), Times.Once());
    }
}
