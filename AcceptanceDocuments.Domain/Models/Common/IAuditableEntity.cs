namespace AcceptanceDocuments.Domain.Models.Common;

public interface IAuditableEntity
{
    DateTime CreateTime { get; set; }
    DateTime? UpdateTime { get; set; }

    bool IsActive { get; set; }
    bool IsRequired { get; set; }
}
