using AcceptanceDocuments.Business.DTOs.Common;
namespace AcceptanceDocuments.Business.DTOs;

public class DocumentQueryDTO : BaseQueryDTO
{
    public Guid? DocumentTypeId { get; set; }

    public DateTime? CreatedFrom { get; set; }
    public DateTime? CreatedTo { get; set; }
}