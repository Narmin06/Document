namespace AcceptanceDocuments.Domain.Models.Common;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
    DateTime? DeleteTime { get; set; }
}
