using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using Biopark.CpaSurvey.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Biopark.CpaSurvey.Infra.Data.Management;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{

    private readonly ApplicationDbContext _applicationDbContext;

    private readonly DbSet<T> _dbSet;

    public BaseRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        _dbSet = applicationDbContext.Set<T>();
    }

    public void Add<TEntity>(TEntity entity) where TEntity : T
    {
        _dbSet.Add(entity);
    }

    public void Delete<TEntity>(TEntity entity) where TEntity : T
    {
        _dbSet.Remove(entity);
    }

    public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet;
    }

    public async Task<T> GetByIdAsync(long id)
    {
        return await _dbSet.FindAsync(id).ConfigureAwait(false);
    }

    public void Update<TEntity>(TEntity entity) where TEntity : T
    {
        _dbSet.Update(entity);
    }

    public Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.AnyAsync(predicate);
    }

    public Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return _dbSet.AnyAsync(predicate, cancellationToken);
    }
}