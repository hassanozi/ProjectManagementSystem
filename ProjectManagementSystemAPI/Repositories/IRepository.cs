using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Specification;
using System.Linq.Expressions;

namespace ProjectManagementSystemAPI.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        T GetByID(int id);
        Task<T> GetByIdAsync(int id);
        Task<IQueryable<T>> GetAllPag(Expression<Func<T, bool>> predicate,
             int take = 10, int skip = 0,
            params Expression<Func<T, object>>[] includes
            );
        T GetWithTrackinByID(int id);
        Task<IQueryable<T>> GetAll(BaseSpecification<T> baseSpecification);
        Task<T> AddAsync(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        Task<T> First(Expression<Func<T, bool>> predicate);
        Task SaveChangesAsync();
    }
}
