using System.Linq.Expressions;

namespace Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
public interface IBaseRepository<T>
{
    void Add<TEntity>(TEntity entity) where TEntity : T;

    void Update<TEntity>(TEntity entity) where TEntity : T;

    void Delete<TEntity>(TEntity entity) where TEntity : T;

    IQueryable<T> GetAll();

    Task<T> GetByIdAsync(long id);

    Task<T> GetAsync<TKey>(TKey id);

    IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
}