using AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;

namespace AlquilaFacilPlatform.Subscriptions.Domain.Model.Entities;

public class Invoice
{
    public int Id { get; private set; }
    public float Amount { get; private set; }
    public DateTime Date { get; private set; }
    
    public Subscription Subscription { get; internal set; }
    public int SubscriptionId { get; private set; }

    public Invoice(int subscriptionId, float amount, DateTime date)
    {
        SubscriptionId = subscriptionId;
        Amount = amount;
        Date = date;
    }
}