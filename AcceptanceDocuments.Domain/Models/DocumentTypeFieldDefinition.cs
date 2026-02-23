using AcceptanceDocuments.Domain.Models.Common;

namespace AcceptanceDocuments.Domain.Models;

public class DocumentTypeFieldDefinition : BaseEntity
{
    public Guid DocumentTypeId { get; set; }
    public DocumentType DocumentType { get; set; } = null!;

    public Guid DocumentFieldDefinitionId { get; set; }
    public DocumentFieldDefinition DocumentFieldDefinition { get; set; } = null!;

    public bool IsRequired { get; set; } = false;
}
