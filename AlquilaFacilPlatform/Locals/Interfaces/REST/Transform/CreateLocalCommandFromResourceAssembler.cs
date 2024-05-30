using AlquilaFacilPlatform.Locals.Domain.Model.Commands;
using AlquilaFacilPlatform.Locals.Interfaces.REST.Resources;

namespace AlquilaFacilPlatform.Locals.Interfaces.REST.Transform;

public static class CreateLocalCommandFromResourceAssembler
{
    public static CreateLocalCommand ToCommandFromResources(CreateLocalResource resource)
    {
        return new CreateLocalCommand(resource.District, resource.Province, resource.LocalType, resource.Price,
            resource.PhotoUrl);
    }
}