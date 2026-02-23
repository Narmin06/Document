using AcceptanceDocuments.Dal.Data;
using AcceptanceDocuments.Dal.Repositories.Interfaces;
using AcceptanceDocuments.Domain.Models;
namespace AcceptanceDocuments.Dal.Repositories.Implements;

public class DocumentRepository: Repository<Documentt>, IDocumentRepository
{
    public DocumentRepository(AppDbContext context) : base(context)
    { }
}

