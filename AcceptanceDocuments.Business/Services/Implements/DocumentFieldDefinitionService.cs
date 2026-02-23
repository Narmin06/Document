using AcceptanceDocuments.Business.DTOs;
using AcceptanceDocuments.Business.DTOs.Common;
using AcceptanceDocuments.Business.DTOs.DocumentFieldDefinitionDTO;
using AcceptanceDocuments.Business.Services.Interfaces;
using AcceptanceDocuments.Dal.Data;
using AcceptanceDocuments.Dal.Repositories.Interfaces;
using AcceptanceDocuments.Domain.Models;
namespace AcceptanceDocuments.Business.Services.Implements;

public class DocumentFieldDefinitionService : IDocumentFieldDefinitionService
{
    private readonly IDocumentFieldDefinitionRepository _documentRepository;
    private readonly IDocumentTypeFieldDefinitionRepository _documentTypeFieldDefinitionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DocumentFieldDefinitionService(IDocumentFieldDefinitionRepository repository, IDocumentTypeFieldDefinitionRepository documentTypeFieldDefinitionRepository,
             IUnitOfWork unitOfWork)
    {
        _documentRepository = repository;
        _documentTypeFieldDefinitionRepository = documentTypeFieldDefinitionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(DocumentFieldDefinitionCreateRequestDTO documentDto, CancellationToken cancellationToken = default)
    {
        if (documentDto is null)
            throw new ArgumentNullException(nameof(documentDto));

        var documentFieldDefinition = new DocumentFieldDefinition
        {
            Label = documentDto.Label,
            FieldType = documentDto.FieldType,
            IsRequired = documentDto.IsRequired
        };

        _documentRepository.Create(documentFieldDefinition);

        if (documentDto.DocumentTypeId.HasValue)
        {
            var documentTypeFieldDefinition = new DocumentTypeFieldDefinition
            {
                DocumentTypeId = documentDto.DocumentTypeId.Value,
                DocumentFieldDefinitionId = documentFieldDefinition.Id,
                IsRequired = documentDto.IsRequired
            };

            _documentTypeFieldDefinitionRepository.Create(documentTypeFieldDefinition);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var documentFieldDefinition = await _documentRepository.GetByIdAsync(id);

        if(documentFieldDefinition is null)
            throw new KeyNotFoundException($"DocumentFieldDefinition with id {id} not found.");

        _documentRepository.Delete(documentFieldDefinition);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PagedResult<DocumentFieldDefinitionAdminResponseDTO>> GetAllAsync(BaseQueryDTO dto, CancellationToken cancellationToken = default)
    {
        IQueryable<DocumentFieldDefinition> query = _documentRepository.GetAll();

        if (dto is null)
            throw new ArgumentNullException(nameof(dto));

        if(!string.IsNullOrEmpty(dto.Search))
            query = query.Where(x => x.Label.Contains(dto.Search)); 

        int pageNumber = dto.PageNumber <= 0 ? 1 : dto.PageNumber;
        int pageSize = dto.PageSize <= 0 ? 10 : dto.PageSize;
        var pagedResult = await query.ToPagedResultAsync(pageNumber, pageSize, cancellationToken);

        var dtoItems = pagedResult.Items.Select(x => new DocumentFieldDefinitionAdminResponseDTO
        {
            Id = x.Id,
            Label = x.Label,
            IsRequired = x.IsRequired,
            IsDeleted = x.IsDeleted,
        }).ToList();

        return new PagedResult<DocumentFieldDefinitionAdminResponseDTO>
        {
            Items = dtoItems,
            PageNumber = pagedResult.PageNumber,
            PageSize = pagedResult.PageSize,
            TotalCount = pagedResult.TotalCount
        };
    }

    public async Task<PagedResult<DocumentFieldDefinitionResponseDTO>> GetAllModeratorAsync(BaseQueryDTO dto, CancellationToken cancellationToken = default)
    {
        IQueryable<DocumentFieldDefinition> query = _documentRepository.GetAll();

        if(dto is null)
            throw new ArgumentNullException(nameof(dto));

        if (!string.IsNullOrEmpty(dto.Search))
            query = query.Where(x => x.Label.Contains(dto.Search));

        int pageNumber = dto.PageNumber <= 0 ? 1 : dto.PageNumber;
        int pageSize = dto.PageSize <= 0 ? 10 : dto.PageSize;
        var pagedResult = await query.ToPagedResultAsync(pageNumber, pageSize, cancellationToken);

        var dtoItems = pagedResult.Items.Select(x => new DocumentFieldDefinitionResponseDTO
        {
            Label = x.Label,
            IsRequired = x.IsRequired,
        }).ToList();

        return new PagedResult<DocumentFieldDefinitionResponseDTO>
        {
            Items = dtoItems,
            PageNumber = pagedResult.PageNumber,
            PageSize = pagedResult.PageSize,
            TotalCount = pagedResult.TotalCount
        };
    }

    public async Task<DocumentFieldDefinitionResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var documentFieldDefinition = await _documentRepository.GetByIdAsync(id);

        if (documentFieldDefinition is null)
            throw new KeyNotFoundException($"DocumentFieldDefinition with id {id} not found.");

        return new DocumentFieldDefinitionResponseDTO
        {
            Label = documentFieldDefinition.Label,
            IsRequired = documentFieldDefinition.IsRequired,
            DocumentFieldDefinitionId = documentFieldDefinition.Id
        };
    }

    public async Task RecoverAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var documentFieldDefinition = await _documentRepository.GetByIdAsync(id);

        if(documentFieldDefinition is null)
            throw new KeyNotFoundException($"DocumentFieldDefinition with id {id} not found.");

        if (documentFieldDefinition.IsDeleted)
        {
            documentFieldDefinition.IsDeleted = false;
            documentFieldDefinition.DeleteTime = null;
        }
        else
        {
            throw new Exception($"DocumentType with id {id} is not soft deleted, so it cannot be recovered.");
        }
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task SoftDeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var documentFieldDefinition = await _documentRepository.GetByIdAsync(id);

        if(documentFieldDefinition is null)
            throw new KeyNotFoundException($"DocumentFieldDefinition with id {id} not found.");

        if (documentFieldDefinition.IsDeleted)
        {
            throw new Exception($"DocumentType with id {id} is already soft deleted.");
        }
        else
        {
            documentFieldDefinition.IsDeleted = true;
            documentFieldDefinition.DeleteTime = DateTime.UtcNow;
        }
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Guid id, DocumentFieldDefinitionUpdateRequestDTO documentDto, CancellationToken cancellationToken = default)
    {
        var documentFieldDefinition = await _documentRepository.GetByIdAsync(id);

        if(documentFieldDefinition is null)
            throw new KeyNotFoundException($"DocumentFieldDefinition with id {id} not found."); 

        documentFieldDefinition.Label = documentDto.Label;
        documentFieldDefinition.FieldType = documentDto.FieldType;
        documentFieldDefinition.IsRequired = documentDto.IsRequired;

        _documentRepository.Update(documentFieldDefinition);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
