using AcceptanceDocuments.Business.DTOs.DocumentFieldValueDTO;
using Microsoft.AspNetCore.Http;

namespace AcceptanceDocuments.Business.DTOs.DocumentDTO
{
    public class DocumentUpdateRequestDTO
    {
        public string? DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }
        public string? Note { get; set; }
        public IFormFile? File { get; set; }
        public string? FieldValueJson { get; set; }
        public IEnumerable<DocumentFieldValueCreateRequestDTO>? FieldValues { get; set; }
    }
}