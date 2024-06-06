using AlquilaFacilPlatform.Subscriptions.Domain.Model.Entities;

namespace AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;

public partial class Subscription
{
    public int Id { get; }
    public int UserId { get; private set; }
    
    public Plan Plan { get; internal set; }
    public int PlanId { get; private set; }

    public Subscription(int userId, int planId)
    {
        UserId = userId;
        PlanId = planId;
    }

}