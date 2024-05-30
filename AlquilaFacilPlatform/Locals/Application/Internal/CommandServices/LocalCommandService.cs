using AlquilaFacilPlatform.Locals.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Locals.Domain.Model.Commands;
using AlquilaFacilPlatform.Locals.Domain.Repositories;
using AlquilaFacilPlatform.Locals.Domain.Services;
using AlquilaFacilPlatform.Locals.Infraestructure.Persistence.EFC.Repositories;
using AlquilaFacilPlatform.Shared.Domain.Repositories;

namespace AlquilaFacilPlatform.Locals.Application.Internal.CommandServices;

public class LocalCommandService (ILocalRepository localRepository, IUnitOfWork unitOfWork) : ILocalCommandService
{
    public async Task<Local?> Handle(CreateLocalCommand command)
    {
        var local = new Local(command);
        try
        {
            await localRepository.AddAsync(local);
            await unitOfWork.CompleteAsync();
            return local;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
        finally
        {
            
        }
    }
}