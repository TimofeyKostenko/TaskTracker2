using AutoMapper;
using Business.DTO;
using Domain.Entities;

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
