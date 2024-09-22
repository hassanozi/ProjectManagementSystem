using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using ProjectManagementSystemAPI.Model;
using System.Linq.Expressions;

namespace ProjectManagementSystemAPI.Specification
{
    public interface ISpecification<T>where T : BaseModel
    {
        public Expression<Func<T,bool>> Criteria { get; set;}
        public List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> Includes { get; set; }

        public Expression<Func<T, object>> OrderBy {get; set; }
        public Expression<Func<T, object>> OrderByDesc { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
       
    }
}
