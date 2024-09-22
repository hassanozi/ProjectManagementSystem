using Microsoft.EntityFrameworkCore.Query;
using ProjectManagementSystemAPI.Model;
using System.Linq.Expressions;

namespace ProjectManagementSystemAPI.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseModel
    {
        public BaseSpecification()
        {

        }
        public Expression<Func<T, bool>> Criteria { get ; set; }
       
        public Expression<Func<T, object>> OrderBy { get; set; } = x => x.Id;
        public Expression<Func<T, object>> OrderByDesc { get; set; }
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;
      
        public List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> Includes { get ; set  ; } = new List<Func<IQueryable<T>, IIncludableQueryable<T, object>>>();

       
        public void AddCriteria(Expression<Func<T, bool>> criteriaExpression)
        {
            Criteria=(criteriaExpression);
        }
        public void AddOrderBy(Expression<Func<T, object>> OrderByExpression)
        {

            OrderBy = OrderByExpression;

        }

        public void AddOrderByDesc(Expression<Func<T, object>> OrderByDescExpression)
        {

            OrderByDesc = OrderByDescExpression;

        }
        public void AddInclude(Func<IQueryable<T>, IIncludableQueryable<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        
        
    }
}
