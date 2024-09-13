using ProjectManagementSystemAPI.DTO.Users;

using ProjectManagementSystemAPI.DTO.Auth;

namespace HotelReservationApi.Services.Users
{
    public interface IUserService
    {
        Task<UserDTO> CreateUserAsync(UserRegisterDTO registerDTO);
        Task UpdateUserAsync(UserDTO userDTO);
        Task<UserDTO> FindUserByEmailAsync(string email);
        public Task<int> GetUserIdFromToken(string token);
        Task<UserDTO> FindUserByNameAsync(string username);
        Task<bool> CheckUserPasswordAsync(UserDTO user, string password);
        Task SaveChangesAsync();
    }
}
