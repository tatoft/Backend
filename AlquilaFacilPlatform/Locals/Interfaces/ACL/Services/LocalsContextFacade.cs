using AlquilaFacilPlatform.Locals.Domain.Model.Commands;
using AlquilaFacilPlatform.Locals.Domain.Model.Queries;
using AlquilaFacilPlatform.Locals.Domain.Model.ValueObjects;
using AlquilaFacilPlatform.Locals.Domain.Services;

namespace AlquilaFacilPlatform.Locals.Interfaces.ACL.Services;

public class LocalsContextFacade(ILocalCommandService localCommandService, ILocalQueryService localQueryService) : ILocalsContextFacade
{
    public async Task<int> CreateLocal(string district, string province, string localType, int price, string photoUrl)
    {
        var createLocalCommand = new CreateLocalCommand(district, province, localType, price, photoUrl);
        var local = await localCommandService.Handle(createLocalCommand);
        return local?.Id ?? 0;
    }
    
    public async Task<int> FetchLocalIdByProvince(string province)
    {
        var getLocalByProvinceQuery = new GetLocalByProvinceQuery(new StreetAddress(province));
        var local = await localQueryService.Handle(getLocalByProvinceQuery);
        return local?.Id ?? 0;
    }
}