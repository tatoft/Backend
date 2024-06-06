using AlquilaFacilPlatform.Subscriptions.Domain.Model.Commands;

namespace AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;

public partial class Subscription
{
    public int Id { get; }
    public int UserId { get; private set; }
    public int PlanId { get; private set; }

    public Subscription()
    {
        UserId = 0;
        PlanId = 0;
    }

    public Subscription(int userId, int planId)
    {
        UserId = userId;
        PlanId = planId;
    }

    public Subscription(CreateSubscriptionCommand command)
    {
        UserId = command.UserId;
        PlanId = command.PlanId;
    }
    

}