using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CityBike.Api.Tests;

public record PriceResponse(int Seconds, decimal Price);

public class ApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetBike_UnknownId_ReturnsNotFound()
    {
        // Act
        HttpResponseMessage response =
            await _client.GetAsync("/api/bikes/99");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetPrice_61Seconds_Returns15()
    {
        // Act
        HttpResponseMessage response =
            await _client.GetAsync("/api/price?seconds=61");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        PriceResponse? body =
            await response.Content.ReadFromJsonAsync<PriceResponse>();

        Assert.NotNull(body);
        Assert.Equal(15m, body.Price);
    }

    [Fact]
    public async Task GetPrice_NegativeSeconds_ReturnsBadRequest()
    {
        // Act
        HttpResponseMessage response =
            await _client.GetAsync("/api/price?seconds=-5");

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task GetAdminCustomers_WithoutKey_ReturnsUnauthorized()
    {
        // Act
        HttpResponseMessage response =
            await _client.GetAsync("/api/admin/customers");

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GetAdminCustomers_WithKey_ReturnsOk()
    {
        // Arrange
        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            "/api/admin/customers");

        request.Headers.Add("X-Api-Key", "test-admin-key");

        // Act
        HttpResponseMessage response =
            await _client.SendAsync(request);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
