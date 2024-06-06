using AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Subscriptions.Interfaces.REST.Resources;

namespace AlquilaFacilPlatform.Subscriptions.Interfaces.REST.Transform;

public static class SubscriptionResourceFromEntityAssembler
{
    public static SubscriptionResource ToResourceFromEntity(Subscription entity)
    {
        return new SubscriptionResource(entity.Id, 
            entity.UserId, 
            PlanResourceFromEntityAssembler.ToResourceFromEntity(entity.Plan));
    }
}