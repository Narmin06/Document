using AcceptanceDocuments.Dal.Data;
using AcceptanceDocuments.Dal.Repositories.Interfaces;
using AcceptanceDocuments.Domain.Models;

namespace AcceptanceDocuments.Dal.Repositories.Implements;

public class DocumentTypeFieldDefinitionRepository : Repository<DocumentTypeFieldDefinition>, IDocumentTypeFieldDefinitionRepository
{
    public DocumentTypeFieldDefinitionRepository(AppDbContext context) : base(context)
    {
    }
}
