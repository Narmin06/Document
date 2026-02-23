using AcceptanceDocuments.Business.DTOs;
using AcceptanceDocuments.Business.DTOs.Common;
using AcceptanceDocuments.Business.DTOs.DocumentDTO;
using AcceptanceDocuments.Business.DTOs.DocumentFieldDefinitionDTO;

namespace AcceptanceDocuments.Business.Services.Interfaces;

public interface IDocumentFieldDefinitionService
{
    Task<PagedResult<DocumentFieldDefinitionAdminResponseDTO>> GetAllAsync(BaseQueryDTO dto, CancellationToken cancellationToken = default!);
    Task<PagedResult<DocumentFieldDefinitionResponseDTO>> GetAllModeratorAsync(BaseQueryDTO dto, CancellationToken cancellationToken = default!);
    Task<DocumentFieldDefinitionResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task CreateAsync(DocumentFieldDefinitionCreateRequestDTO documentDto, CancellationToken cancellationToken = default!);
    Task UpdateAsync(Guid id, DocumentFieldDefinitionUpdateRequestDTO documentDto, CancellationToken cancellationToken = default!);
    Task SoftDeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task RecoverAsync(Guid id, CancellationToken cancellationToken = default!);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
}
