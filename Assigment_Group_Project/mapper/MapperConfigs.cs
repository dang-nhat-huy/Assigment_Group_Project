using AutoMapper;

namespace Assigment_Group_Project.Mapper
{
    public partial class MapperConfigs : Profile
    {
        public MapperConfigs()
        {
            // CreateMap(typeof(Pagination<>), typeof(Pagination<>));
            AddCategoryMapperConfig();
            AddFeedBackMapperConfig();
            AddMenuMapperConfig();
            AddOrderMapperConfig();
            AddOrderDetailMapperConfig();
            AddOrderDetailMenuMapperConfig();
            AddOrderDetailServiceMapperConfig();
            AddServiceMapperConfig();
            AddStatusMapperConfig();
            AddTaskMapperConfig();
            AddUserMapperConfig();
            AddUserTaskMapperConfig();
            AddVocuherMapperConfig();
        }
        partial void AddCategoryMapperConfig();
        partial void AddFeedBackMapperConfig();
        partial void AddMenuMapperConfig();
        partial void AddOrderMapperConfig();
        partial void AddOrderDetailMapperConfig();
        partial void AddOrderDetailMenuMapperConfig();
        partial void AddOrderDetailServiceMapperConfig();
        partial void AddServiceMapperConfig();
        partial void AddStatusMapperConfig();
        partial void AddTaskMapperConfig();
        partial void AddUserMapperConfig();
        partial void AddUserTaskMapperConfig();
        partial void AddVocuherMapperConfig();
    }
}
