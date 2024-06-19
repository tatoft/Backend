using AlquilaFacilPlatform.IAM.Domain.Model.Aggregates;
using AlquilaFacilPlatform.IAM.Domain.Respositories;
using AlquilaFacilPlatform.Locals.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Locals.Domain.Model.Commands;
using AlquilaFacilPlatform.Locals.Domain.Model.Entities;
using AlquilaFacilPlatform.Locals.Domain.Repositories;
using AlquilaFacilPlatform.Locals.Domain.Services;
using AlquilaFacilPlatform.Locals.Infraestructure.Persistence.EFC.Repositories;
using AlquilaFacilPlatform.Shared.Domain.Repositories;

namespace AlquilaFacilPlatform.Locals.Application.Internal.CommandServices;

public class LocalCommandService (ILocalRepository localRepository, ILocalCategoryRepository localCategoryRepository, IUnitOfWork unitOfWork) : ILocalCommandService
{
    
    public async Task<Local?> Handle(CreateLocalCommand command)
    {
        var userAuthenticated = User.GlobalVariables.UserId;
        var local = new Local(command.District, command.Street, command.LocalType, command.Country, command.City, command.Price, command.PhotoUrl,
            command.LocalCategoryId);
        local.UserId = userAuthenticated;
        await localRepository.AddAsync(local);
        await unitOfWork.CompleteAsync();
        var localCategory = await localCategoryRepository.FindByIdAsync(command.LocalCategoryId);
        local.LocalCategory = localCategory;
        return local;
    }
}