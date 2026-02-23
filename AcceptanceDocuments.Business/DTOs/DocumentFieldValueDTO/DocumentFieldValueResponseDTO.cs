namespace AcceptanceDocuments.Business.DTOs.DocumentFieldValueDTO;

public class DocumentFieldValueResponseDTO
{
    public string Value { get; set; }  = null!;
    public Guid DocumentFieldValueId { get; set; }
    public Guid DocumentId { get; set; }  
    public Guid DocumentFieldDefinitionId { get; set; } 
}