using AutoMapper;
using ProjectManagementSystemAPI.DTO.Users;
using ProjectManagementSystemAPI.DTOs.AuthDTOs;
using ProjectManagementSystemAPI.DTOs.UserDTOs;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.ViewModels.Auth;

namespace ProjectManagementSystemAPI.MapperProfile
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<UserLoginViewModel, UserLoginDTO>();
            CreateMap<UserRegisterViewModel, UserRegisterDTO>();

            CreateMap<UserRegisterDTO, User>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();

            CreateMap<User, UserReturnDTO>().ReverseMap();

            //CreateMap<UserDTO, CustomerDTO>()
            //    .ForMember(dest => dest.UserId , opt => opt.MapFrom(src=>src.Id))
            //    .ReverseMap();
            //CreateMap<Staff, StaffDTO>().ReverseMap();
            //CreateMap<Customer, CustomerDTO>().ReverseMap();

            CreateMap<UserCreateDTO, User>();

            CreateMap<UserDTO, User>()
                //.ForMember(dest => dest.Claims, opt => opt.Ignore())
                //.ForMember(dest => dest.Customer, opt => opt.Ignore())
                //.ForMember(dest => dest.Staff, opt => opt.Ignore())
                .ForMember(dest => dest.UserRoles, opt => opt.Ignore());

            //CreateMap<User, UserDTO>()
            //   .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.UserRoles != null && src.UserRoles.Any()
            //    ? src.UserRoles.First().Role.Name : string.Empty));
        }

    }
}
