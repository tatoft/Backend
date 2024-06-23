using AlquilaFacilPlatform.IAM.Domain.Model.Aggregates;

namespace AlquilaFacilPlatform.Tests.UnitTests;

public class UserTests
{
    [Fact]
    public void UpdateUsername_ShouldChangeUsername()
    {
        string initialUsername = "initialUsername";
        string newUsername = "newUsername";
        var user = new User(initialUsername, "passwordHash");

        user.UpdateUsername(newUsername);

        Assert.Equal(newUsername, user.Username);
    }
    
    [Fact]
    public void UpdatePasswordHash_ShouldChangePasswordHash()
    {
        string username = "username";
        string initialPasswordHash = "initialHash";
        string newPasswordHash = "newHash";
        var user = new User(username, initialPasswordHash);

        user.UpdatePasswordHash(newPasswordHash);

        Assert.Equal(newPasswordHash, user.PasswordHash);
    }
}