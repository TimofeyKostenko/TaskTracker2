using Domain.Entities;


namespace Business.Interfaces
{
    public interface IProjectService
    {
        IQueryable<Project> GetAll();

        Project GetProject(int id);


        Task<Project> CreateProject(Project project);

        Task<bool> DeleteProject(int id);

        Task<Project> EditProject(int id, Project project);
        IQueryable<Mission> GetTasksByProject(int id);
    }
}
