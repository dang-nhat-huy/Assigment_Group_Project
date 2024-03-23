using Assigment_Group_Project.ViewModel;
using AutoMapper;
using BusinessObject.Models;

namespace Assigment_Group_Project.Mapper
{
    public partial class MapperConfigs : Profile
    {
        partial void AddRoomMapperConfig()
        {
            CreateMap<RoomRequestVM, Room>()
                .ForMember(dest => dest.OrderDetails, opt => opt.Ignore());
            CreateMap<Room, RoomRequestVM>();
        }
    }
}
