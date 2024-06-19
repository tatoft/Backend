using AlquilaFacilPlatform.Locals.Domain.Model.Commands;
using AlquilaFacilPlatform.Locals.Domain.Model.Entities;
using AlquilaFacilPlatform.Locals.Domain.Model.ValueObjects;

namespace AlquilaFacilPlatform.Locals.Domain.Model.Aggregates;

public partial class Local
{
    public Local()
    {
        LType = new LocalType();
        Address = new StreetAddress();
        Price = new NightPrice();
        Photo = new PhotoUrl();
        Place = new CityPlace();
    }
    
    
    public Local(string district, string street, string localType, string country, string city, int price, string photoUrl, int localCategoryId) : this()
    {
        LType = new LocalType(localType);
        Address = new StreetAddress(district, street);
        Price = new NightPrice(price);
        Photo = new PhotoUrl(photoUrl);
        Place = new CityPlace(country, city);
        LocalCategoryId = localCategoryId;
    }

    public Local(CreateLocalCommand command)
    {
        LType = new LocalType(command.LocalType);
        Address = new StreetAddress(command.District, command.Street);
        Price = new NightPrice(command.Price);
        Photo = new PhotoUrl(command.PhotoUrl);
        Place = new CityPlace(command.Country, command.City);
    }

    public int Id { get; }
    public LocalType LType { get; private set; }
    public NightPrice Price { get; private set; }
    public PhotoUrl Photo { get; private set; }
    public StreetAddress Address { get; private set; }
    public CityPlace Place { get; private set; }
    public LocalCategory? LocalCategory { get; internal set; }
    public int LocalCategoryId { get; private set; }
    public int UserId { get; set; }

    
    public string StreetAddress => Address.FullAddress;
    public string LocalType => LType.TypeLocal;
    public int NightPrice => Price.PriceNight;
    public string PhotoUrl => Photo.PhotoUrlLink;
    public string CityPlace => Place.FullCityPlace;
}