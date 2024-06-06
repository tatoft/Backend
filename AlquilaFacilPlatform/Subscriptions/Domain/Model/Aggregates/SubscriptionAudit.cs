using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;

public partial class SubscriptionAudit : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] 
    public DateTimeOffset? CreatedDate { get; set; }

    [Column("UpdatedAt")] 
    public DateTimeOffset? UpdatedDate { get; set; }

}