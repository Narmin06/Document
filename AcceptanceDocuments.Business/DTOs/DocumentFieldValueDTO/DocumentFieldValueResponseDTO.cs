namespace AcceptanceDocuments.Business.DTOs.DocumentFieldValueDTO;

public class DocumentFieldValueResponseDTO
{
    public string Value { get; set; }  = null!;
    public string FieldDefinitionName { get; set; } = null!;
    public Guid DocumentFieldDefinitionId { get; set; } 
}