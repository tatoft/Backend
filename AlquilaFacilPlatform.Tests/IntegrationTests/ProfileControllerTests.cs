using System.Net;
using AlquilaFacilPlatform.Profiles.Interfaces.REST;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AlquilaFacilPlatform.Tests.IntegrationTests;

public class ProfileControllerTests : IClassFixture<WebApplicationFactory<ProfilesController>>
{
    private HttpClient _client;

    public ProfileControllerTests(WebApplicationFactory<ProfilesController> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAllProfiles_ReturnsOkResponse()
    {
        // Act
        var response = await _client.GetAsync("/api/v1/profiles");
        
        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200
        var responseString = await response.Content.ReadAsStringAsync();
        Assert.NotEmpty(responseString); // Assures the response is not empty
    }

    [Fact]
    public async Task GetProfileById_ReturnsOkResponse()
    {
        // Arrange
        int profileId = 1; // An already existing id
        
        // Act
        var response = await _client.GetAsync("/api/v1/profiles/{profileId}");
        
        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200
        var responseString = await response.Content.ReadAsStringAsync();
        Assert.NotEmpty(responseString); // Assures the response is not empty
    }

    [Fact]
    public async Task GetProfileById_ReturnsNotFoundResponse()
    {
        //Arrange
        int profileId = 999; // An invalid/not registered id
        
        // Act
        var response = await _client.GetAsync("api/v1/profiles/{profileId}");
        
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode); // Status Code 404
    }
}