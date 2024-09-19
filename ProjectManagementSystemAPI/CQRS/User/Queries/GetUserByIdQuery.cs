using MediatR;
using ProjectManagementSystemAPI.DTO.Users;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.CQRS.User.Queries
{
    public record GetUserByIdQuery(int id) : IRequest<UserReturnDto>;

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserReturnDto>
    {
        private readonly IRepository<Model.User> _userRepository;

        public GetUserByIdQueryHandler(IRepository<Model.User> repository)
        {
            _userRepository = repository;
        }
        public async Task<UserReturnDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (request is null || request.id <= 0)
            {
                throw new Exception();  
            } 
                
            var user =  _userRepository.GetByID(request.id).MapOne<UserReturnDto>();
            return user;

        }
    }
}
