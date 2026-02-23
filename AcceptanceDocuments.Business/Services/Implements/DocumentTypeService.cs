using AcceptanceDocuments.Business.DTOs;
using AcceptanceDocuments.Business.DTOs.DocumentTypeDTO;
using AcceptanceDocuments.Business.Services.Interfaces;
using AcceptanceDocuments.Dal.Data;
using AcceptanceDocuments.Dal.Repositories.Interfaces;
using AcceptanceDocuments.Domain.Models;
namespace AcceptanceDocuments.Business.Services.Implements;

public class DocumentTypeService : IDocumentTypeService
{
    private readonly IDocumentTypeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DocumentTypeService(IDocumentTypeRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(DocumentTypeCreateRequestDTO documentTypeDto, CancellationToken cancellationToken = default)
    {
        if (documentTypeDto is null)
            throw new ArgumentNullException(nameof(documentTypeDto));

        var documentType = new DocumentType
        {
            Name = documentTypeDto.Name
        };

        _repository.Create(documentType);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var documentType = await _repository.GetByIdAsync(id);

        if (documentType is null)
            throw new KeyNotFoundException($"DocumentType with id {id} not found.");

        _repository.Delete(documentType);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PagedResult<DocumentTypeAdminResponseDTO>> GetAllAsync(DocumentTypeQueryDTO dto, CancellationToken cancellationToken = default)
    {
        IQueryable<DocumentType> query = _repository.GetAll();

        if( dto is null) 
             throw new ArgumentNullException(nameof(dto));    

        if(dto.CreatedFrom.HasValue)
            query = query.Where(x => x.CreateTime >= dto.CreatedFrom.Value);

        if(dto.CreatedTo.HasValue)
            query = query.Where(x => x.CreateTime <= dto.CreatedTo.Value);

        if(!string.IsNullOrEmpty(dto.Search))
            query = query.Where(x => x.Name.Contains(dto.Search));

        int pageNumber = dto.PageNumber <= 0 ? 1 : dto.PageNumber;
        int pageSize = dto.PageSize <= 0 ? 10 : dto.PageSize;
        var pagedResult = await query.ToPagedResultAsync(pageNumber, pageSize, cancellationToken);

        var dtoItems = pagedResult.Items.Select(x => new DocumentTypeAdminResponseDTO
        {
            Id = x.Id,
            Name = x.Name,
            CreateTime = x.CreateTime,
            IsDeleted = x.IsDeleted
        }).ToList();

        return new PagedResult<DocumentTypeAdminResponseDTO>
        {
            Items = dtoItems,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = pagedResult.TotalCount
        };
    }

    public async Task<PagedResult<DocumentTypeResponseDTO>> GetAllModeratorAsync(DocumentTypeQueryDTO dto, CancellationToken cancellationToken = default)
    {
        IQueryable<DocumentType> query = _repository.GetAll(x => !x.IsDeleted);

        if( dto is null) 
                throw new ArgumentNullException(nameof(dto));

        if(dto.CreatedFrom.HasValue)
            query = query.Where(x => x.CreateTime >= dto.CreatedFrom.Value);

       if(dto.CreatedTo.HasValue)
            query = query.Where(x => x.CreateTime <= dto.CreatedTo.Value); 

       int pageNumber = dto.PageNumber <= 0 ? 1 : dto.PageNumber;
       int pageSize = dto.PageSize <=0 ? 10 : dto.PageSize;
       var pagedResult = await query.ToPagedResultAsync(pageNumber, pageSize, cancellationToken);
       var dtoItems = pagedResult.Items.Select(x=>new DocumentTypeResponseDTO
       {
           Name = x.Name
       }).ToList();

        return new PagedResult<DocumentTypeResponseDTO>
        {
            Items = dtoItems,
            PageNumber = pagedResult.PageNumber,
            PageSize = pagedResult.PageSize,
            TotalCount = pagedResult.TotalCount
        };
    }

    public async Task<DocumentTypeResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var documentType = await _repository.GetByIdAsync(id, cancellationToken);

        if( documentType is null)
            throw new ArgumentNullException(nameof(documentType));

        return new DocumentTypeResponseDTO
        {
            Name = documentType.Name
        };
    }

    public async Task RecoverAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var documentType = await _repository.GetByIdAsync(id);

        if(documentType is null)
            throw new KeyNotFoundException($"DocumentType with id {id} not found.");

        if (documentType.IsDeleted)
        {
            documentType.IsDeleted = false;
            documentType.DeleteTime = null;
        }
        else
        {
            throw new Exception($"DocumentType with id {id} is not soft deleted, so it cannot be recovered.");
        }
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task SoftDeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var documentType = await _repository.GetByIdAsync(id);

        if(documentType is null)
            throw new KeyNotFoundException($"DocumentType with id {id} not found.");

        if (documentType.IsDeleted)
        {
            throw new Exception($"DocumentType with id {id} is already soft deleted.");
        }
        else
        {
            documentType.IsDeleted = true;
            documentType.DeleteTime = DateTime.UtcNow;
        }
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Guid id, DocumentTypeUpdateRequestDTO documentTypeDto, CancellationToken cancellationToken = default)
    {
       var documentType = await _repository.GetByIdAsync(id);

        if (documentType is null)
            throw new KeyNotFoundException($"DocumentType with id {id} not found.");

        documentType.Name = documentTypeDto.Name;

        _repository.Update(documentType);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
