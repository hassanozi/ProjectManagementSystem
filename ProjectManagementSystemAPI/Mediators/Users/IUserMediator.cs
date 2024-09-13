using ProjectManagementSystemAPI.DTO.Auth;
using ProjectManagementSystemAPI.DTO;

namespace HotelReservationApi.Mediators.Users
{
    public interface IUserMediator
    {
        Task<ResultDTO> RegisterAsync(UserRegisterDTO registerDTO);
        Task<ResultDTO> LoginAsync(UserLoginDTO loginDTO);
    }
}
