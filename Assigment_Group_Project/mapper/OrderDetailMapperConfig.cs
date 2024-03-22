using Assigment_Group_Project.ViewModel;
using AutoMapper;
using BusinessObject.Models;

namespace Assigment_Group_Project.Mapper
{
    public partial class MapperConfigs : Profile
    {
        partial void AddOrderDetailMapperConfig()
        {
            CreateMap<OrderDetailRequestVM, OrderDetail>()
                .ForMember(dest => dest.OrderDetailMenus, opt => opt.Ignore())
                .ForMember(dest => dest.OrderDetailServices, opt => opt.Ignore());
            CreateMap<OrderDetail, OrderDetailRequestVM>();


            CreateMap<OrderDetailUpdateRequestVM, OrderDetail>()
                .ForMember(dest => dest.OrderDetailMenus, opt => opt.Ignore())
                .ForMember(dest => dest.OrderDetailServices, opt => opt.Ignore());
            CreateMap<OrderDetail, OrderDetailUpdateRequestVM>();
        }
    }
}