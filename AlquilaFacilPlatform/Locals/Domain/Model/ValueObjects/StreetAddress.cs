namespace AlquilaFacilPlatform.Locals.Domain.Model.ValueObjects;

public record StreetAddress(string District, string Province)
{
    public StreetAddress() : this(string.Empty, string.Empty)
    {
        
    }

    public StreetAddress(string province) : this(province, string.Empty)
    {
        
    }

    public string FullAddress => $"{District}, {Province}";
}