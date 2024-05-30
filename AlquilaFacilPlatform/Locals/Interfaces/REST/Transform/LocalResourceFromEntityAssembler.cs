using AlquilaFacilPlatform.Locals.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Locals.Interfaces.REST.Resources;

namespace AlquilaFacilPlatform.Locals.Interfaces.REST.Transform;

public static class LocalResourceFromEntityAssembler
{
    public static LocalResource ToResourceFromEntity(Local entity)
    {
        return new LocalResource(entity.Id, entity.StreetAddress, entity.LocalType, entity.NightPrice, entity.PhotoUrl);
    }
}