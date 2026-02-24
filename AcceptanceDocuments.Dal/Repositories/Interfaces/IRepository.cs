using AcceptanceDocuments.Domain.Models.Common;
using System.Linq.Expressions;

namespace AcceptanceDocuments.Dal.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity, new()
{
    IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null,
                               Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null,
                               bool tracking = false);

    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? filter = null,
                              Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null,
                              bool tracking = false, CancellationToken cancellationToken= default);
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<int> SaveChangeAsync();
}
