using AutoMapper;
using Business.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProjectDTO, Project>();
            CreateMap<MissionDTO, Mission>();
            CreateMap<Project, ProjectDTO>();
            CreateMap<Mission, MissionDTO>();
        }
    }
}
