using AcceptanceDocuments.Domain.Models.Common;
using System.Reflection.Metadata;
namespace AcceptanceDocuments.Domain.Models;

public class DocumentFieldValue : AuditableEntity, ISoftDeletable
{
    public string Value { get; set; } = null!;

    public Guid DocumentId { get; set; }
    public Documentt Document { get; set; } = null!;

    public Guid DocumentFieldDefinitionId { get; set; }
    public DocumentFieldDefinition DocumentFieldDefinition { get; set; } = null!;
    public bool IsDeleted { get; set; }
    public DateTime? DeleteTime { get; set; }
}
