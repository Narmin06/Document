using AcceptanceDocuments.Business.DTOs.Common;
using AcceptanceDocuments.Domain.Models.Common;

namespace AcceptanceDocuments.Business.DTOs.DocumentTypeDTO;

public class DocumentTypeAdminResponseDTO : AuditableEntity, ISoftDeletableDto
{
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public DateTime? DeleteTime { get; set; }
}
