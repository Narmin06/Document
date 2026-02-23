using AcceptanceDocuments.Business.DTOs;
using AcceptanceDocuments.Business.DTOs.DocumentDTO;
using AcceptanceDocuments.Business.DTOs.DocumentTypeDTO;

namespace AcceptanceDocuments.Business.Services.Interfaces;

public interface IDocumentTypeService
{
    Task<PagedResult<DocumentTypeAdminResponseDTO>> GetAllAsync(DocumentTypeQueryDTO dto, CancellationToken cancellationToken = default!);
    Task<PagedResult<DocumentTypeResponseDTO>> GetAllModeratorAsync(DocumentTypeQueryDTO dto, CancellationToken cancellationToken = default!);
    Task<DocumentTypeResponseDTO>GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);

    Task CreateAsync(DocumentTypeCreateRequestDTO documentDto, CancellationToken cancellationToken = default!);
    Task UpdateAsync(Guid id, DocumentTypeUpdateRequestDTO documentDto, CancellationToken cancellationToken = default!);
    Task SoftDeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task RecoverAsync(Guid id, CancellationToken cancellationToken = default!);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
}
