using AcceptanceDocuments.Dal.Data;
using AcceptanceDocuments.Dal.Repositories.Interfaces;
using AcceptanceDocuments.Domain.Models;
namespace AcceptanceDocuments.Dal.Repositories.Implements;

public class DocumentTypeRepository : Repository<DocumentType>, IDocumentTypeRepository
{
    public DocumentTypeRepository(AppDbContext context) : base(context)
    { }
}
