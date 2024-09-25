using MediatR;
using ProjectManagementSystemAPI.DTO.Users;
using ProjectManagementSystemAPI.DTOs.RoleDTOs;
using ProjectManagementSystemAPI.DTOs.UserDTOs;
using ProjectManagementSystemAPI.Enums;
using ProjectManagementSystemAPI.Exceptions;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.CQRS.Users.Queries
{
    public record GetUserByIdQuery(int id) : IRequest<UserReturnDTO>;
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserReturnDTO>
    {
        private readonly IRepository<User> _repository;

        public GetUserByIdQueryHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<UserReturnDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new BusinessException(ErrorCode.NotValidUserID, "Invalid UserID!");
            }
            var user = _repository.GetByID(request.id).MapOne<UserReturnDTO>();
            return user;
        }
    }
}
