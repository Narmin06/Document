using AcceptanceDocuments.Dal.Repositories.Interfaces;
using AcceptanceDocuments.Domain.Models;
using AcceptanceDocuments.Domain.Models.Common;
namespace AcceptanceDocuments.Dal.Data;

//Commit mentiqi
public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity, new();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}