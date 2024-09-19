

using Microsoft.EntityFrameworkCore;
using ProjectManagementSystemAPI.Data;
using ProjectManagementSystemAPI.Paging;
using System.Linq.Expressions;

namespace ProjectManagementSystemAPI.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<Model.User> GetAll()
        {
            return _context.Set<Model.User>().Where(x => !x.Deleted).AsNoTracking();

        }

        public Task<PagedList<Model.User>> GetAllUsers(PagingParameters pagingParameters)
        {
            return Task.FromResult(PagedList<Model.User>.GetPagedList(GetAll().OrderBy(u => u.Id), pagingParameters.PageNumber, pagingParameters.PageSize));
        
         }
  
    }
}
