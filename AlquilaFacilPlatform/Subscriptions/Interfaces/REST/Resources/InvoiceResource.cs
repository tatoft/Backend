using AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;

namespace AlquilaFacilPlatform.Subscriptions.Interfaces.REST.Resources;

public record InvoiceResource(int Id, SubscriptionResource Subscription, float Amount, DateTime Date);