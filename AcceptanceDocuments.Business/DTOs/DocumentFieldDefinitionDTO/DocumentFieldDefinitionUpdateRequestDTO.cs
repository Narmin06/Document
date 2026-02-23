using AcceptanceDocuments.Domain.Enums;

namespace AcceptanceDocuments.Business.DTOs.DocumentFieldDefinitionDTO;

public class DocumentFieldDefinitionUpdateRequestDTO
{
    public required string Label { get; set; }
    public bool IsRequired { get; set; }
    public EDocumentFieldType FieldType { get; set; }
    //public Guid? DocumentTypeId { get; set; }
}
