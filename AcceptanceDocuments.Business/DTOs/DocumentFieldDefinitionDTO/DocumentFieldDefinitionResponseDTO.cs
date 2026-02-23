namespace AcceptanceDocuments.Business.DTOs.DocumentFieldDefinitionDTO;

public class DocumentFieldDefinitionResponseDTO
{ 
    public string Label { get; set; }  =string.Empty;
    public bool IsRequired { get; set; }  
    public Guid DocumentFieldDefinitionId { get; set; }
}