using AlquilaFacilPlatform.IAM.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Shared.Domain.Repositories;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.Commands;
using AlquilaFacilPlatform.Subscriptions.Domain.Repositories;
using AlquilaFacilPlatform.Subscriptions.Domain.Services;

namespace AlquilaFacilPlatform.Subscriptions.Application.Internal.CommandServices;

public class SubscriptionCommandService(ISubscriptionRepository subscriptionRepository, 
    IPlanRepository planRepository, 
    IUnitOfWork unitOfWork)
    : ISubscriptionCommandService
{
    public async Task<Subscription?> Handle(CreateSubscriptionCommand command)
    {
        var userAuthenticated = User.GlobalVariables.UserId;
        var subscription = new Subscription(command.PlanId);
        subscription.UserId = userAuthenticated;
        await subscriptionRepository.AddAsync(subscription);
        await unitOfWork.CompleteAsync();
        var plan = await planRepository.FindByIdAsync(command.PlanId);
        subscription.Plan = plan;
        return subscription;
    }
}