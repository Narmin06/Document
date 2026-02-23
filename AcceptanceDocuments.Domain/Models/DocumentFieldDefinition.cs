using AcceptanceDocuments.Domain.Enums;
using AcceptanceDocuments.Domain.Models.Common;

namespace AcceptanceDocuments.Domain.Models;

// field-in metadata-ları saxlanılır
public class DocumentFieldDefinition : AuditableEntity, ISoftDeletable
{
    public string Label { get; set; } = null!; 
    public  EDocumentFieldType FieldType { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeleteTime { get; set; }

    public ICollection<DocumentFieldValue> FieldValues { get; set; } = new List<DocumentFieldValue>();
    public ICollection<DocumentTypeFieldDefinition> DocumentTypeFieldDefinitions { get; set; } = new List<DocumentTypeFieldDefinition>();
}
