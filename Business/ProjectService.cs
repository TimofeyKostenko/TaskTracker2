using Business.Interfaces;
using DAL.Repositories;
using Domain.Entities;


namespace Business
{
    public class ProjectService : IProjectService
    {
        //adding reposiroties for Projects
        private readonly IBaseRepository<Project> projectRepo;

        public ProjectService(IBaseRepository<Project> projectRepo)
        {
            this.projectRepo = projectRepo;
        }
        public async Task<Project> CreateProject(Project project)
        {
            var newProject = new Project()
            {
                ProjectName = project.ProjectName,
                StartDate = project.StartDate,
                CompletionDate = project.CompletionDate,
                Status = project.Status,
                Priority = project.Priority
            };
            await projectRepo.Create(newProject);
            return newProject;
        }


        public async Task<bool> DeleteProject(int id)
        {
            var project = projectRepo.Get(id);
            await projectRepo.Delete(project);
            return true;
        }


        public async Task<Project> EditProject(int id, Project project)
        {
            var changedProject = projectRepo.Get(id);
            if (changedProject == null)
            {
                throw new ValidationException("There is no object with this id", "");
            };

            changedProject.ProjectName = project.ProjectName;
            changedProject.StartDate = project.StartDate;
            changedProject.CompletionDate = project.CompletionDate;
            changedProject.Status = project.Status;
            changedProject.Priority = project.Priority;

            await projectRepo.Update(changedProject);
            return changedProject;
        }


        public IQueryable<Project>? GetAll() => projectRepo.GetAll();
        


        public Project? GetProject(int id) => projectRepo.Get(id);


        public IQueryable<Mission> GetTasksByProject(int id) => projectRepo.GetTasks(id);
        
    }
}
