using AcceptanceDocuments.Business.DTOs.DocumentFieldValueDTO;
using AcceptanceDocuments.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace AcceptanceDocuments.Business.DTOs.DocumentDTO
{
    public class DocumentUpdateRequestDTO
    {
        public string? DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }
        public string? Note { get; set; }
        public required IFormFile File { get; set; }
        public string? FileValueJson { get; set; }
        public IEnumerable<DocumentFieldValueCreateRequestDTO>? FileValue { get; set; }
    }
}