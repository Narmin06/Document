using AcceptanceDocuments.Business.DTOs.DocumentFieldValueDTO;

namespace AcceptanceDocuments.Business.DTOs.DocumentDTO;

public class DocumentResponseDTO
{
    public string DocumentCode { get; set; } = string.Empty;
    public string DocumentNumber { get; set; } = string.Empty;
    public DateTime DocumentDate { get; set; }
    public string DocumentTypeName { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public string FileUrl { get; set; } = string.Empty;
    public DateTime RegsitrationDate { get; set; }
    public IEnumerable<DocumentFieldValueResponseDTO> FieldValues { get; set; } = new List<DocumentFieldValueResponseDTO>();
}
