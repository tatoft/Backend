using AlquilaFacilPlatform.Locals.Domain.Model.Commands;
using AlquilaFacilPlatform.Locals.Domain.Model.Queries;
using AlquilaFacilPlatform.Locals.Domain.Model.ValueObjects;
using AlquilaFacilPlatform.Locals.Domain.Services;

namespace AlquilaFacilPlatform.Locals.Interfaces.ACL.Services;

public class LocalsContextFacade(ILocalCommandService localCommandService) : ILocalsContextFacade
{
    public async Task<int> CreateLocal(string district, string province, string localType, int price, string photoUrl, int localCategoryId)
    {
        var createLocalCommand = new CreateLocalCommand(district, province, localType, price, photoUrl, localCategoryId);
        var local = await localCommandService.Handle(createLocalCommand);
        return local?.Id ?? 0;
    }
}