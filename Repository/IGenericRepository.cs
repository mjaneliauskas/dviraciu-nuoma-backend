using System.Linq.Expressions;

namespace dviraciu_nuoma_backend.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);
        T? Add(T entity);
        T? Delete(T entity);
        T? Update(T entity);
    }
}
