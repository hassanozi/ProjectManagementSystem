using ProjectManagementSystemAPI.Data;
using ProjectManagementSystemAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ProjectManagementSystemAPI.Specification;
using System.Linq;

namespace ProjectManagementSystemAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {  
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            entity.Deleted = true;
            Update(entity);
        }

        public void Delete(int id)
        {
            T entity = _context.Find<T>(id);
            Delete(entity);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().Where(x => !x.Deleted).AsNoTracking();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(  predicate).AsNoTracking();
        }

        public T GetByID(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public T GetWithTrackinByID(int id)
        {
            return _context.Set<T>()
                    .Where(x => !x.Deleted && x.Id == id)
                    .AsTracking()
                    .FirstOrDefault();
        }
        public async Task<IQueryable<T>> GetAllPag(Expression<Func<T, bool>> predicate,
             int take=10, int skip=0,
            params Expression<Func<T, object>>[] includes 
            )
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

           
                query = query.Where(predicate).Skip(skip).Take(take);
           

            //var result = await query.Skip(skip).Take(take);//.ToListAsync();

            return query;
        } 
        public async Task<IQueryable<T>> GetAll(BaseSpecification<T> baseSpecification
            )
        {
            IQueryable<T> query = _context.Set<T>();
            
            query = baseSpecification.Includes.Aggregate(query, (current, include) => include(current));
           

            if (baseSpecification.Criteria != null)
            {
                query = query.Where(baseSpecification.Criteria);
            }

            var result =  query.Skip(baseSpecification.Skip)
                .Take(baseSpecification.Take)
                ;

            return result;
        }
        public async Task<T> First(Expression<Func<T, bool>> predicate)
        {
            return await Get(predicate).FirstOrDefaultAsync();
        }

        public async System.Threading.Tasks.Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
