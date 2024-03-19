using Assigment_Group_Project.ViewModel;
using AutoMapper;
using BusinessObject.Models;

namespace Assigment_Group_Project.Mapper
{
    public partial class MapperConfigs : Profile
    {
        partial void AddVocuherMapperConfig()
        {
            CreateMap<Voucher, VoucherViewModel>().ReverseMap();
        }
    }
}
