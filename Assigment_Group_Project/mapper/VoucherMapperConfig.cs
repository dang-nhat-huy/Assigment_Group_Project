using Assigment_Group_Project.ViewModel;
using AutoMapper;
using BusinessObject.Models;

namespace Assigment_Group_Project.Mapper
{
    public partial class MapperConfigs : Profile
    {
        partial void AddVocuherMapperConfig()
        {
             CreateMap<Voucher, VoucherViewModel>()
                .ForMember(des => des.ExpireDay, opt => opt.MapFrom(src => src.ExpireDate.Value.Day.ToString()))
                .ForMember(des => des.ExpireMonth, opt => opt.MapFrom(src => src.ExpireDate.Value.Month.ToString()))
                .ForMember(des => des.ExpireYear, opt => opt.MapFrom(src => src.ExpireDate.Value.Year.ToString()))
                .ForMember(des => des.ExpireHour, opt => opt.MapFrom(src => src.ExpireDate.Value.Hour.ToString()))
                .ForMember(des => des.ExpireMinute, opt => opt.MapFrom(src => src.ExpireDate.Value.Minute.ToString()))
                .ReverseMap();
        }
    }
}
