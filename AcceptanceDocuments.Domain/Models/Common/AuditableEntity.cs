namespace AcceptanceDocuments.Domain.Models.Common;

public class AuditableEntity : BaseEntity, IAuditableEntity
{
    public bool IsActive { get; set; } = true;
    public bool IsRequired { get; set; }
    public DateTime? UpdateTime { get; set; }
    public DateTime CreateTime { get; set; } = DateTime.UtcNow;
}
