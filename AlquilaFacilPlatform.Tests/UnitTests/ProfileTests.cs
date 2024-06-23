using AlquilaFacilPlatform.Profiles.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Profiles.Domain.Model.Commands;

namespace AlquilaFacilPlatform.Tests.UnitTests;

public class ProfileTests
{ 
    [Fact]
    public void Profile_Constructor_WithParameters_ShouldInitializeProperties()
    { 
        string name = "John";
        string fatherName = "Doe";
        string motherName = "Smith";
        string dateOfBirth = "1990-01-01";
        string documentNumber = "12345678";
        string phone = "123456789";
        int userId = 1;
        
        var profile = new Profile(name, fatherName, motherName, dateOfBirth, documentNumber, phone, userId);
        
        Assert.Equal(name, profile.Name.Name);
        Assert.Equal(fatherName, profile.Name.FatherName);
        Assert.Equal(motherName, profile.Name.MotherName);
        Assert.Equal(dateOfBirth, profile.Birth.BirthDate);
        Assert.Equal(documentNumber, profile.DocumentN.NumberDocument);
        Assert.Equal(phone, profile.PhoneN.PhoneNumber);
        Assert.Equal(userId, profile.UserId);
    }

    [Fact]
    public void Profile_Update_ShouldUpdateProperties()
    {
        var profile = new Profile("Jane", "Johnson", "Doe", "1995-02-15", "87654321", "987654321", 2);
        var updateCommand = new UpdateProfileCommand(
            "New Jane",
            "New Johnson",
            "New Doe",
            "2000-01-01",
            "12345678",
            "999999999",
            2
        );
        
        profile.Update(updateCommand);
        
        Assert.Equal(updateCommand.Name, profile.Name.Name);
        Assert.Equal(updateCommand.FatherName, profile.Name.FatherName);
        Assert.Equal(updateCommand.MotherName, profile.Name.MotherName);
        Assert.Equal(updateCommand.DateOfBirth, profile.Birth.BirthDate);
        Assert.Equal(updateCommand.DocumentNumber, profile.DocumentN.NumberDocument);
        Assert.Equal(updateCommand.Phone, profile.PhoneN.PhoneNumber);
        Assert.Equal(2, profile.UserId); // Verify UserId remains the same
    }

}