namespace AcceptanceDocuments.Business.DTOs.DocumentFieldValueDTO;

public class DocumentFieldValueCreateRequestDTO
{
    public string Value { get; set; }  = string.Empty;
    public Guid DocumentFieldDefinitionId { get; set; }  
}
