namespace AlquilaFacilPlatform.Subscriptions.Interfaces.REST.Resources;

public record SubscriptionResource(int Id, PlanResource Plan, string Status);