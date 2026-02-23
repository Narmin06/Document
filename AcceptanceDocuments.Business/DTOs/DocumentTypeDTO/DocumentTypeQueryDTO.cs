using AcceptanceDocuments.Business.DTOs.Common;

namespace AcceptanceDocuments.Business.DTOs.DocumentTypeDTO;

public class DocumentTypeQueryDTO : BaseQueryDTO
{
    public DateTime? CreatedFrom { get; set; }
    public DateTime? CreatedTo { get; set; }
}