using AutoMapper;
using BusinessObject.Models;

namespace Assigment_Group_Project.Mapper
{
    public partial class MapperConfigs : Profile
    {
        partial void AddCategoryMapperConfig()
        {
            CreateMap<Category, Menu>();
        }
    }

}