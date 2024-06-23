namespace AlquilaFacilPlatform.Profiles.Interfaces.REST.Resources;

public record UpdateProfileResource(int Id, string Name, string FatherName, string MotherName, string Phone, string DocumentNumber, 
    string DateOfBirth);