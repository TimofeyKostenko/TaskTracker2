using AutoMapper;
using Business.DTO;
using Business.Exceptions;
using Business.Interfaces;
using DAL.Repositories;
using Domain.Entities;


namespace Business
{

    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepo;
        private readonly IMapper mapper;

        public ProjectService(IProjectRepository projectRepo, IMapper mapper)
        {
            this.projectRepo = projectRepo;
            this.mapper = mapper;
        }
        public async Task<ProjectDTO> CreateProjectAsync(ProjectDTO project)
        {
            if (project.StartDate > project.CompletionDate)
            {
                throw new Exception("Start date cannot be earlier than complition date");
            }
            var newProject = new Project()
            { 
                ProjectName = project.ProjectName,
                StartDate = project.StartDate,
                CompletionDate = project.CompletionDate,
                Status = project.Status,
                Priority = project.Priority
            };
            await projectRepo.CreateAsync(newProject);
            return mapper.Map<ProjectDTO>(newProject);
        }
        public async Task DeleteProjectAsync(int projectId)
        {
            var project = await projectRepo.GetAsync(projectId);
            if (project == null)
            {
                throw new EntityNotExistException("Project", projectId);
            }
            await projectRepo.DeleteAsync(project);
        }
        public async Task<ProjectDTO> EditProjectAsync(int projectId, ProjectDTO project)
        {
            var changedProject = await projectRepo.GetAsync(projectId);
            if (project == null)
            {
                throw new EntityNotExistException("Project", projectId);
            }
            changedProject.ProjectName = project.ProjectName;
            changedProject.StartDate = project.StartDate;
            changedProject.CompletionDate = project.CompletionDate;
            changedProject.Status = project.Status;
            changedProject.Priority = project.Priority;

            await projectRepo.UpdateAsync(changedProject);
            return mapper.Map<ProjectDTO>(changedProject);
        }
        public async Task<IEnumerable<ProjectDTO>?> GetAllAsync()
        {
            var allProjects =await projectRepo.GetAllAsync();
            return allProjects.Select(project => mapper.Map<ProjectDTO>(project));
        }

        public async Task<ProjectDTO?> GetProjectAsync(int projectId)
        {
            var project = await projectRepo.GetAsync(projectId);
            if (project == null)
            {
                throw new EntityNotExistException("Project", projectId);
            }
            return mapper.Map<ProjectDTO>(project);
        }

        public async Task<IEnumerable<MissionDTO>?> GetTasksByProjectAsync(int projectId)
        {
            var projectMissions =  await projectRepo.GetTasksAsync(projectId);
            return projectMissions.Select(mission => mapper.Map<MissionDTO>(mission));
        }
    }
}
