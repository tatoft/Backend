namespace AlquilaFacilPlatform.Locals.Interfaces.ACL;

public interface ILocalsContextFacade
{
    Task<int> CreateLocal(string district, string province, string localType, int price, string photoUrl, int localCategoryId);
}