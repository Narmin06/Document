using AcceptanceDocuments.Domain.Enums;
using AcceptanceDocuments.Domain.Models.Common;
namespace AcceptanceDocuments.Domain.Models;

public class Documentt : AuditableEntity, ISoftDeletable
{
    public string DocumentCode { get; set; } = string.Empty;
    public string DocumentNumber { get; set; } = "Nomresiz";
    public DateTime DocumentDate { get; set; }
    public string? Note { get; set; }
    public string FilePathUrl { get; set; } = string.Empty;      


    public bool IsDeleted { get; set; }
    public DateTime? DeleteTime { get; set; }


    public Guid DocumentTypeId { get; set; }
    public string DocumentTypeName { get; set; } = string.Empty; //Elave eledim
    public DocumentType DocumentType { get; set; } = null!;

    public ICollection<DocumentFieldValue> FieldValues { get; set; } = new List<DocumentFieldValue>();

}
