using Assigment_Group_Project.ViewModel;
using AutoMapper;
using BusinessObject.Models;

namespace Assigment_Group_Project.Mapper
{
    public partial class MapperConfigs : Profile
    {
        partial void AddFeedBackMapperConfig()
        {
            CreateMap<FeedbackRequestVM, Feedback>()
                .ForMember(dest => dest.User, opt => opt.Ignore());
            CreateMap<Feedback, FeedbackRequestVM>();
        }
    }
}
