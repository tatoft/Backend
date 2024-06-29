using System.Net;
using AlquilaFacilPlatform.IAM.Interfaces.REST;
using AlquilaFacilPlatform.Profiles.Interfaces.REST;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AlquilaFacilPlatform.Tests.IntegrationTests;

public class UserControllerTests : IClassFixture<WebApplicationFactory<UsersController>>
{
    private HttpClient _client;

    public UserControllerTests(WebApplicationFactory<UsersController> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAllProfiles_ReturnsOkResponse()
    {
        // Act
        var response = await _client.GetAsync("/api/v1/users");
        
        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200
        var responseString = await response.Content.ReadAsStringAsync();
        Assert.NotEmpty(responseString); // Assures the response is not empty
    }

    [Fact]
    public async Task GetProfileById_ReturnsOkResponse()
    {
        // Arrange
        int userId = 1; // An already existing id
        
        // Act
        var response = await _client.GetAsync("/api/v1/users/{userId}");
        
        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200
        var responseString = await response.Content.ReadAsStringAsync();
        Assert.NotEmpty(responseString); // Assures the response is not empty
    }

    [Fact]
    public async Task GetProfileById_ReturnsNotFoundResponse()
    {
        //Arrange
        int userId = 999; // An invalid/not registered id
        
        // Act
        var response = await _client.GetAsync("api/v1/users/{userId}");
        
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode); // Status Code 404
    }
}