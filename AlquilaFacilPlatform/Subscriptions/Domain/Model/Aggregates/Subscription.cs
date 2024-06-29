using AlquilaFacilPlatform.Subscriptions.Domain.Model.Entities;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.ValueObjects;

namespace AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;

public partial class Subscription
{
    public int Id { get; }
    
    public int UserId { get; set; }
    
    public ESubscriptionStatus Status { get; protected set; }
    
    public ICollection<Invoice> Invoices { get; }
    
    public Plan Plan { get; internal set; }
    public int PlanId { get; private set; }

    public Subscription(int planId)
    {
        PlanId = planId;
        Status = ESubscriptionStatus.Pending;
    }

    public void Active() => Status = ESubscriptionStatus.Active;
    public void Pending() => Status = ESubscriptionStatus.Pending;
    public void Expired() => Status = ESubscriptionStatus.Expired;
    public void Cancelled() => Status = ESubscriptionStatus.Cancelled;
    public void Suspended() => Status = ESubscriptionStatus.Suspended;
    public void Trial() => Status = ESubscriptionStatus.Trial;
    public void RenewalDue() => Status = ESubscriptionStatus.RenewalDue;

    public ESubscriptionStatus GetStatus()
    {
        return Status;
    }
}