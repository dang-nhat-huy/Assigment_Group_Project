using Assigment_Group_Project.ViewModel;
using AutoMapper;
using Task = BusinessObject.Models.Task;

namespace Assigment_Group_Project.Mapper
{
    public partial class MapperConfigs : Profile
    {
        partial void AddTaskMapperConfig()
        {
            CreateMap<Task, TaskRequestVM>();
            CreateMap<TaskRequestVM, Task>()
                .ForMember(dest => dest.UserTasks, opt => opt.Ignore());
        }
    }
}
