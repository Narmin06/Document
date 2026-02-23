using AcceptanceDocuments.Business.DTOs.Common;
namespace AcceptanceDocuments.Business.DTOs.DocumentFieldDefinitionDTO;

public class DocumentFieldDefinitionAdminResponseDTO : AuditableEntityDto, ISoftDeletableDto
{
    public string Label { get; set; } = string.Empty;
    public bool IsRequired { get; set; }
    public Guid DocumentFieldDefinitionId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeleteTime { get; set; }
}
