using AcceptanceDocuments.Dal.Data;
using AcceptanceDocuments.Dal.Repositories.Interfaces;
using AcceptanceDocuments.Domain.Models;

namespace AcceptanceDocuments.Dal.Repositories.Implements;

public class DocumentFieldValueRepository : Repository<DocumentFieldValue>, IDocumentFieldValueRepository
{
    public DocumentFieldValueRepository(AppDbContext context) : base(context)
    { }
}

