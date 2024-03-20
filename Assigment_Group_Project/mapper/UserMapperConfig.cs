using Assigment_Group_Project.ViewModel;
using AutoMapper;
using BusinessObject.Models;

namespace Assigment_Group_Project.Mapper
{
    public partial class MapperConfigs : Profile
    {
        partial void AddUserMapperConfig()
        {
            CreateMap<SignUpUserVM, User>()
                .ForMember(dest => dest.UserOrders, opt => opt.Ignore())
                .ForMember(dest => dest.UserTasks, opt => opt.Ignore());
            CreateMap<User, SignUpUserVM>();


            CreateMap<UserCreateByAdminVM, User>()
                .ForMember(dest => dest.UserOrders, opt => opt.Ignore())
                .ForMember(dest => dest.UserTasks, opt => opt.Ignore());
            CreateMap<User, UserCreateByAdminVM>();


            CreateMap<UserUpdateByCustomerVM, User>()
                .ForMember(dest => dest.UserOrders, opt => opt.Ignore())
                .ForMember(dest => dest.UserTasks, opt => opt.Ignore());
            CreateMap<User, UserUpdateByCustomerVM>();
        }
    }
}
