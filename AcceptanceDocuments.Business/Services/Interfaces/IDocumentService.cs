using AcceptanceDocuments.Business.DTOs;
using AcceptanceDocuments.Business.DTOs.DocumentDTO;

namespace AcceptanceDocuments.Business.Services.Interfaces;

public interface IDocumentService
{
    Task<PagedResult<DocumentAdminResponseDTO>> GetAllAsync(DocumentQueryDTO dto, CancellationToken cancellationToken = default!);
    Task<PagedResult<DocumentResponseDTO>> GetAllModeratorAsync(DocumentQueryDTO dto, CancellationToken cancellationToken = default!);
    Task<DocumentAdminResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task CreateAsync(DocumentCreateRequestDTO documentDto, CancellationToken cancellationToken = default!);
    Task UpdateAsync(Guid id, DocumentUpdateRequestDTO documentDto, CancellationToken cancellationToken = default!);
    Task SoftDeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task RecoverAsync(Guid id, CancellationToken cancellationToken = default!);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
}


