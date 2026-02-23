namespace AcceptanceDocuments.Business.DTOs.DocumentFieldValueDTO;

public class DocumentFieldValueUpdateRequestDTO
{
    public string Value { get; set; }
    public Guid DocumentId { get; set; }
    public Guid DocumentFieldDefinitionId { get; set; }
}
