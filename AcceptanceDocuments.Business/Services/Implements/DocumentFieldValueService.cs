using AcceptanceDocuments.Business.DTOs;
using AcceptanceDocuments.Business.DTOs.Common;
using AcceptanceDocuments.Business.DTOs.DocumentFieldValueDTO;
using AcceptanceDocuments.Business.Services.Interfaces;
using AcceptanceDocuments.Dal.Data;
using AcceptanceDocuments.Dal.Repositories.Interfaces;
using AcceptanceDocuments.Domain.Models;
namespace AcceptanceDocuments.Business.Services.Implements;

public class DocumentFieldValueService : IDocumentFieldValueService
{
    private readonly IDocumentFieldValueRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DocumentFieldValueService(IDocumentFieldValueRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(DocumentFieldValueCreateRequestDTO documentDto, CancellationToken cancellationToken = default)
    {
        if (documentDto is null)
            throw new ArgumentNullException(nameof(documentDto));

        var documentFieldValue = new DocumentFieldValue
        {
            Value = documentDto.Value,
            DocumentId = documentDto.DocumentId,
            DocumentFieldDefinitionId = documentDto.DocumentFieldDefinitionId
        };

        _repository.Create(documentFieldValue);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var documentFieldValue = await _repository.GetByIdAsync(id);

        if (documentFieldValue is null)
            throw new KeyNotFoundException($"DocumentFieldValue with id {id} not found.");

        _repository.Delete(documentFieldValue);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PagedResult<DocumentFieldValueAdminResponseDTO>> GetAllAsync(BaseQueryDTO dto, CancellationToken cancellationToken = default)
    {
        IQueryable<DocumentFieldValue> query = _repository.GetAll();

        if (dto is null)
            throw new ArgumentNullException(nameof(dto));

        if (!string.IsNullOrEmpty(dto.Search))
            query = query.Where(x => x.Value.Contains(dto.Search));

        int pageNumber = dto.PageNumber <= 0 ? 1 : dto.PageNumber;
        int pageSize = dto.PageSize <= 0 ? 10 : dto.PageSize;
        var pagedResult = await query.ToPagedResultAsync(pageNumber, pageSize, cancellationToken);

        var dtoItems = pagedResult.Items.Select(x => new DocumentFieldValueAdminResponseDTO
        {
            Id = x.Id,
            Value = x.Value,
            DocumentId = x.DocumentId,
            DocumentFieldDefinitionId = x.DocumentFieldDefinitionId,
        }).ToList();

        return new PagedResult<DocumentFieldValueAdminResponseDTO>
        {
            Items = dtoItems,
            TotalCount = pagedResult.TotalCount,
            PageNumber = pagedResult.PageNumber,
            PageSize = pagedResult.PageSize
        };
    }

    public async Task<PagedResult<DocumentFieldValueResponseDTO>> GetAllModeratorAsync(BaseQueryDTO dto, CancellationToken cancellationToken = default)
    {
        IQueryable<DocumentFieldValue> query = _repository.GetAll();

        if (dto is null)
            throw new ArgumentNullException(nameof(dto));

        if (!string.IsNullOrEmpty(dto.Search))
            query = query.Where(x => x.Value.Contains(dto.Search));

        int pageNumber = dto.PageNumber <= 0 ? 1 : dto.PageNumber;
        int pageSize = dto.PageSize <= 0 ? 10 : dto.PageSize;
        var pagedResult = await query.ToPagedResultAsync(pageNumber, pageSize, cancellationToken);

        var dtoItems = pagedResult.Items.Select(x => new DocumentFieldValueResponseDTO
        {
            Value = x.Value,
            DocumentId = x.DocumentId,
            DocumentFieldDefinitionId = x.DocumentFieldDefinitionId,
        }).ToList();

        return new PagedResult<DocumentFieldValueResponseDTO>
        {
            Items = dtoItems,
            TotalCount = pagedResult.TotalCount,
            PageNumber = pagedResult.PageNumber,
            PageSize = pagedResult.PageSize
        };

    }

    public async Task<DocumentFieldValueResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var documentFieldValue = await _repository.GetByIdAsync(id);

        if (documentFieldValue is null)
            throw new KeyNotFoundException($"DocumentFieldValue with id {id} not found.");

        return new DocumentFieldValueResponseDTO
        {
            Value = documentFieldValue.Value,
            DocumentId = documentFieldValue.DocumentId,
            DocumentFieldDefinitionId = documentFieldValue.DocumentFieldDefinitionId,
        };
    }

    public async Task RecoverAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var documentFieldValue = await _repository.GetByIdAsync(id);

        if (documentFieldValue is null)
            throw new KeyNotFoundException($"DocumentFieldValue with id {id} not found.");

        if (documentFieldValue.IsDeleted)
        {
            documentFieldValue.IsDeleted = false;
            documentFieldValue.DeleteTime = null; 
        }
        else
        {
            throw new Exception($"DocumentFieldValue with id {id} is not soft deleted, so it cannot be recovered.");
        }
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task SoftDeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var documentFieldValue = await _repository.GetByIdAsync(id);

        if (documentFieldValue is null)
            throw new KeyNotFoundException($"DocumentFieldValue with id {id} not found.");


        if (documentFieldValue.IsDeleted)
        {
            throw new Exception($"DocumentType with id {id} is already soft deleted.");
        }
        else
        {
            documentFieldValue.IsDeleted = true;
            documentFieldValue.DeleteTime = DateTime.UtcNow;
        }
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Guid id, DocumentFieldValueUpdateRequestDTO documentDto, CancellationToken cancellationToken = default)
    {
        var documentFieldValue = await _repository.GetByIdAsync(id);

        if (documentFieldValue is null)
            throw new KeyNotFoundException($"DocumentFieldValue with id {id} not found.");

        documentFieldValue.Value = documentDto.Value;
        documentFieldValue.DocumentId = documentDto.DocumentId;
        documentFieldValue.DocumentFieldDefinitionId = documentDto.DocumentFieldDefinitionId;

        _repository.Update(documentFieldValue);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
