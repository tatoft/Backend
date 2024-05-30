namespace AlquilaFacilPlatform.Locals.Domain.Model.Commands;

public record CreateLocalCommand(
    string District, string Province, string LocalType, int Price, string PhotoUrl 
    );