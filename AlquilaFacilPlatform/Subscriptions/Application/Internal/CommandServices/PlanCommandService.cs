using AlquilaFacilPlatform.Shared.Domain.Repositories;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.Commands;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.Entities;
using AlquilaFacilPlatform.Subscriptions.Domain.Repositories;
using AlquilaFacilPlatform.Subscriptions.Domain.Services;

namespace AlquilaFacilPlatform.Subscriptions.Application.Internal.CommandServices;

public class PlanCommandService(IPlanRepository planRepository, IUnitOfWork unitOfWork) : IPlanCommandService
{
    public async Task<Plan?> Handle(CreatePlanCommand command)
    {
        var plan = new Plan(command.Name, command.Service, command.Price);
        await planRepository.AddAsync(plan);
        await unitOfWork.CompleteAsync();
        return plan;
    }
}