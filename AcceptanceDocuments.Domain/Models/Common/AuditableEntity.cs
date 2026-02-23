
namespace AcceptanceDocuments.Domain.Models.Common;

public class AuditableEntity : BaseEntity, IAuditableEntity
{
    public DateTime CreateTime { get; set; } = DateTime.UtcNow;
    public DateTime? UpdateTime { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsRequired { get; set; }
}
