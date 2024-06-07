using AlquilaFacilPlatform.Subscriptions.Domain.Model.Commands;
using AlquilaFacilPlatform.Subscriptions.Domain.Services;

namespace AlquilaFacilPlatform.Subscriptions.Interfaces.ACL.Services;

public class SubscriptionsContextFacade(ISubscriptionCommandService subscriptionCommandService, 
    ISubscriptionQueryServices subscriptionQueryServices) : ISubscriptionsContextFacade
{
    public async Task<int> CreateSubscription(int userId, int planId)
    {
        var createSubscriptionCommand = new CreateSubscriptionCommand(userId, planId);
        var subscription = await subscriptionCommandService.Handle(createSubscriptionCommand);
        return subscription?.Id ?? 0;
    }
}