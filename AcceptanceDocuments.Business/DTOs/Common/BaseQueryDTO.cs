namespace AcceptanceDocuments.Business.DTOs.Common;

public class BaseQueryDTO 
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? Search { get; set; }
}