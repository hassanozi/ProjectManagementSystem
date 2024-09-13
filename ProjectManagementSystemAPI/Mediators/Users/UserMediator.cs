using ProjectManagementSystemAPI.DTO.Auth;
using ProjectManagementSystemAPI.DTO;
using ProjectManagementSystemAPI.Model;
using HotelReservationApi.Services.Users;

using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.DTO.Users;

using HotelReservationApi.Services;

using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace HotelReservationApi.Mediators.Users
{
    public class UserMediator : IUserMediator
    {
        private readonly IUserService _userService;
       
        IHttpContextAccessor _httpContextAccessor;
        public UserMediator(IUserService userService, 
           
            IHttpContextAccessor httpContextAccessor
            )
        {
            _userService = userService;
           
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResultDTO> LoginAsync(UserLoginDTO loginDTO)
        {
            var userDTO = await _userService.FindUserByEmailAsync(loginDTO.Email);

            if (userDTO is null || !await _userService.CheckUserPasswordAsync(userDTO, loginDTO.Password))
            {
                return ResultDTO.Faliure("Email or Password is incorrect");
            }

            var token = TokenGenerator.GenerateToken(userDTO);
            _httpContextAccessor.HttpContext.Session.SetString("AuthToken", token);

            
            return ResultDTO.Sucess(token, "Login Successed!");
        }

        public async Task<ResultDTO> RegisterAsync(UserRegisterDTO registerDTO)
        {
            

            var userDTO = await _userService.FindUserByEmailAsync(registerDTO.Email);

            if (userDTO is not null)
            {
                return ResultDTO.Faliure("Email is already registered!");
            }

            userDTO = await _userService.FindUserByNameAsync(registerDTO.UserName);

            if (userDTO is not null)
            {
                return ResultDTO.Faliure("Username is alerady registered!");
            }

            var userCreatedDTO = await _userService.CreateUserAsync(registerDTO);

           // await _userRoleService.AddUserToRoleAsync(userCreatedDTO, registerDTO.Role);

            //if(registerDTO.Role == RoleType.Staff)
            //{
            //    StaffDTO staffDTO = userCreatedDTO.MapOne<StaffDTO>(); 
            //    await _staffService.AddStaff(staffDTO);
            //}

            //if (registerDTO.Role == RoleType.Customer)
            //{
            //    CustomerDTO customerDTO = userCreatedDTO.MapOne<CustomerDTO>();
            //    await _customerService.AddCustomer(customerDTO);
            //}

            var token = TokenGenerator.GenerateToken(userCreatedDTO);
        
            return ResultDTO.Sucess(token, "User Registration Successed");
        }
    }
}
