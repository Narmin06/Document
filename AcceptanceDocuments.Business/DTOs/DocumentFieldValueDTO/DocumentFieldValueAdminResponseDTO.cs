using AcceptanceDocuments.Business.DTOs.Common;
using AcceptanceDocuments.Domain.Models.Common;

namespace AcceptanceDocuments.Business.DTOs.DocumentFieldValueDTO;

public class DocumentFieldValueAdminResponseDTO : AuditableEntityDto, ISoftDeletableDto
{
    public string Value { get; set; } = string.Empty;
    public Guid DocumentFieldValueId { get; set; }
    public Guid DocumentId { get; set; }
    public Guid DocumentFieldDefinitionId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeleteTime { get; set; }
}
