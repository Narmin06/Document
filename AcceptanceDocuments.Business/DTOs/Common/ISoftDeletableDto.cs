namespace AcceptanceDocuments.Business.DTOs.Common;

public interface ISoftDeletableDto
{
    bool IsDeleted { get; set; }
    DateTime? DeleteTime { get; set; }
}
