using System.Linq.Expressions;

namespace ProjectManagementSystemAPI.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        T GetByID(int id);
        T GetWithTrackinByID(int id);
        Task<T> AddAsync(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        Task<T> First(Expression<Func<T, bool>> predicate);
        Task SaveChangesAsync();
    }
}
