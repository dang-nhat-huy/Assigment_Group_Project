using Assigment_Group_Project.ViewModel;
using AutoMapper;
using BusinessObject.Models;

namespace Assigment_Group_Project.Mapper
{
    public partial class MapperConfigs : Profile
    {
        partial void AddUserOrderMapperConfig()
        {
            CreateMap<UserOrder, UserOrderRequestVM>();
            CreateMap<UserOrderRequestVM, UserOrder>()
                .ForMember(dest => dest.Order, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore()); ;
        }
    }
}
