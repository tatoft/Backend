using AlquilaFacilPlatform.Profiles.Domain.Model.Commands;
using AlquilaFacilPlatform.Profiles.Interfaces.REST.Resources;

namespace AlquilaFacilPlatform.Profiles.Interfaces.REST.Transform;

public class UpdateProfileCommandFromResourceAssembler
{
    public static UpdateProfileCommand ToCommandFromResource(UpdateProfileResource resource)
    {
        return new UpdateProfileCommand(resource.Name, resource.FatherName, resource.MotherName, resource.DateOfBirth,
            resource.DocumentNumber, resource.Phone, resource.UserId);
    }
}