using AcceptanceDocuments.Dal.Data;
using AcceptanceDocuments.Dal.Repositories.Interfaces;
using AcceptanceDocuments.Domain.Models.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AcceptanceDocuments.Dal.Repositories.Implements;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
{
    protected readonly AppDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public void Create(TEntity entity) => _dbSet.Add(entity);

    public void Update(TEntity entity) => _dbSet.Update(entity);

    public void Delete(TEntity entity) => _dbSet.Remove(entity);

    public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null,
                                     Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null,
                                     bool tracking = false)
    {
        IQueryable<TEntity> query = tracking ? _dbSet : _dbSet.AsNoTracking();

        if (includes is not null)
            query = includes(query);

        if (filter is not null)
            query = query.Where(filter);

        return _dbSet.AsQueryable();
    }

    public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter,
                                           Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null,
                                           bool tracking = false,
                                           CancellationToken ct = default)

      => GetAll(filter, includes, tracking).FirstOrDefaultAsync(ct);


    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }

    public async Task<int> SaveChangeAsync()
    {
        return await _context.SaveChangesAsync();
    }
}

