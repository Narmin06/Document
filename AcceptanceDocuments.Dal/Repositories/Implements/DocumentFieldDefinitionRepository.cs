using AcceptanceDocuments.Dal.Data;
using AcceptanceDocuments.Dal.Repositories.Interfaces;
using AcceptanceDocuments.Domain.Models;

namespace AcceptanceDocuments.Dal.Repositories.Implements
{
    public class DocumentFieldDefinitionRepository : Repository<DocumentFieldDefinition>, IDocumentFieldDefinitionRepository
    {
        public DocumentFieldDefinitionRepository(AppDbContext context) : base(context)
        { }

        public void AddFieldValue(DocumentFieldValue documentFieldValue)
        {
            _context.Set<DocumentFieldValue>().Add(documentFieldValue);
        }
    }
}