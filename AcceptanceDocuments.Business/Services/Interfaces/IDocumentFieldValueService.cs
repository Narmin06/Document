using AcceptanceDocuments.Business.DTOs;
using AcceptanceDocuments.Business.DTOs.Common;
using AcceptanceDocuments.Business.DTOs.DocumentDTO;
using AcceptanceDocuments.Business.DTOs.DocumentFieldValueDTO;

namespace AcceptanceDocuments.Business.Services.Interfaces;

public interface IDocumentFieldValueService
{
    Task<PagedResult<DocumentFieldValueAdminResponseDTO>> GetAllAsync(BaseQueryDTO dto, CancellationToken cancellationToken = default!);
    Task<PagedResult<DocumentFieldValueResponseDTO>> GetAllModeratorAsync(BaseQueryDTO dto, CancellationToken cancellationToken = default!);
    Task<DocumentFieldValueResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task CreateAsync(DocumentFieldValueCreateRequestDTO documentDto, CancellationToken cancellationToken = default!);
    Task UpdateAsync(Guid id, DocumentFieldValueUpdateRequestDTO documentDto, CancellationToken cancellationToken = default!);
    Task SoftDeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task RecoverAsync(Guid id, CancellationToken cancellationToken = default!);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
}
