using ProjectManagementSystemAPI.Paging;

namespace ProjectManagementSystemAPI.Repositories.User
{
    public interface IUserRepository 
    {
         IQueryable<Model.User> GetAll();

        Task<PagedList<Model.User>> GetAllUsers(PagingParameters pagingParameters);
    }
}
