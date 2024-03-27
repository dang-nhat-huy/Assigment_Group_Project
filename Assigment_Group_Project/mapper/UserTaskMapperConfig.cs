﻿using Assigment_Group_Project.ViewModel;
using AutoMapper;
using BusinessObject.Models;

namespace Assigment_Group_Project.Mapper
{
    public partial class MapperConfigs : Profile
    {
        partial void AddUserTaskMapperConfig()
        {
            CreateMap<UserTask, UserTaskRequestVM>();
            CreateMap<UserTaskRequestVM, UserTask>()
                .ForMember(dest => dest.Task, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore()); ;
        }
    }
}
