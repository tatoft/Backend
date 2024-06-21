namespace AlquilaFacilPlatform.Subscriptions.Interfaces.ACL;

public interface ISubscriptionsContextFacade
{
    Task<int> CreateSubscription(int planId);
}