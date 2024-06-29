using AlquilaFacilPlatform.Locals.Domain.Model.Entities;
using AlquilaFacilPlatform.Locals.Domain.Model.Queries;
using AlquilaFacilPlatform.Locals.Domain.Repositories;
using AlquilaFacilPlatform.Locals.Domain.Services;

namespace AlquilaFacilPlatform.Locals.Application.Internal.QueryServices;

public class LocalCategoryQueryService(ILocalCategoryRepository localCategoryRepository) : ILocalCategoryQueryService
{
    public async Task<LocalCategory?> Handle(GetLocalCategoryByIdQuery query)
    {
        return await localCategoryRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<LocalCategory>> Handle(GetAllLocalCategoriesQuery query)
    {
        return await localCategoryRepository.ListAsync();
    }
}