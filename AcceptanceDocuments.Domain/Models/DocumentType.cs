using AcceptanceDocuments.Domain.Models.Common;
namespace AcceptanceDocuments.Domain.Models;

public class DocumentType :AuditableEntity,ISoftDeletable
{
    public string Name { get; set; } = string.Empty; 
  
    public bool IsDeleted { get; set; }
    public DateTime? DeleteTime { get; set; }

    public ICollection<Documentt> Documents { get; set; } = new List<Documentt>();
    public ICollection<DocumentTypeFieldDefinition> DocumentTypeFieldDefinitions { get; set; } = new List<DocumentTypeFieldDefinition>();
}
