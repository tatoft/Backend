using AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;

namespace AlquilaFacilPlatform.Subscriptions.Domain.Model.Entities;

public class Plan
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Service { get; set; }
    public float Price { get; set; }
    
    public ICollection<Subscription> Subscriptions { get; }
    
    public Plan()
    {
        Name = string.Empty;
        Service = string.Empty;
        Price = 0;
    }

    public Plan(string name, string service, float price)
    {
        Name = name;
        Service = service;
        Price = price;
    }
}