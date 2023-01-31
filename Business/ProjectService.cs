using Business.Interfaces;
using DAL.Repositories;
using Domain.Entities;


namespace Business
{
    public class ProjectService : IProjectService
    {
        //adding reposiroties for Projects
        private readonly IProjectRepository projectRepo;

        public ProjectService(IProjectRepository projectRepo)
        {
            this.projectRepo = projectRepo;
        }
        public async Task<Project> CreateProjectAsync(Project project)
        {
            var newProject = new Project()
            { 
                ProjectName = project.ProjectName,
                StartDate = project.StartDate,
                CompletionDate = project.CompletionDate,
                Status = project.Status,
                Priority = project.Priority
            };
            await projectRepo.CreateAsync(newProject);
            return newProject;
        }
        public async Task<bool> DeleteProjectAsync(int projectId)
        {
            var project = await projectRepo.GetAsync(projectId);
            await projectRepo.DeleteAsync(project);
            return true;
        }
        public async Task<Project> EditProjectAsync(int projectId, Project project)
        {
            var changedProject = await projectRepo.GetAsync(projectId);
            if (changedProject == null)
            {
                throw new ValidationExceptionA("There is no object with this id", "");
            };

            changedProject.ProjectName = project.ProjectName;
            changedProject.StartDate = project.StartDate;
            changedProject.CompletionDate = project.CompletionDate;
            changedProject.Status = project.Status;
            changedProject.Priority = project.Priority;

            await projectRepo.UpdateAsync(changedProject);
            return changedProject;
        }
        public async Task<IEnumerable<Project>?> GetAllAsync() => await projectRepo.GetAllAsync();
        public async Task<Project?> GetProjectAsync(int projectId) => await projectRepo.GetAsync(projectId);
        public async Task<IEnumerable<Mission>?> GetTasksByProjectAsync(int projectId) => await projectRepo.GetTasksAsync(projectId);
    }
}
