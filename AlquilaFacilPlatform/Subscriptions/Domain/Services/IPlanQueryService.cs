using AlquilaFacilPlatform.Subscriptions.Domain.Model.Entities;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.Queries;

namespace AlquilaFacilPlatform.Subscriptions.Domain.Services;

public interface IPlanQueryService
{
    Task<Plan?> Handle(GetPlanByIdQuery query);
    Task<IEnumerable<Plan>> Handle(GetAllPlansQuery query);
}