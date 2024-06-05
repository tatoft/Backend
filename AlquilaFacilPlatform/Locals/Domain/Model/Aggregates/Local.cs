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
    }
    
    
    public Local(string district, string province, string localType, int price, string photoUrl, int localCategoryId) : this()
    {
        LType = new LocalType(localType);
        Address = new StreetAddress(district, province);
        Price = new NightPrice(price);
        Photo = new PhotoUrl(photoUrl);
        LocalCategoryId = localCategoryId;
    }

    public Local(CreateLocalCommand command)
    {
        LType = new LocalType(command.LocalType);
        Address = new StreetAddress(command.District, command.Province);
        Price = new NightPrice(command.Price);
        Photo = new PhotoUrl(command.PhotoUrl);
    }

    public int Id { get; }
    public LocalType LType { get; private set; }
    public NightPrice Price { get; private set; }
    public PhotoUrl Photo { get; private set; }
    public StreetAddress Address { get; private set; }


    public LocalCategory? LocalCategory { get; internal set; }
    public int LocalCategoryId { get; private set; }


    public string StreetAddress => Address.FullAddress;
    public string LocalType => LType.TypeLocal;
    public int NightPrice => Price.PriceNight;
    public string PhotoUrl => Photo.PhotoUrlLink;
}