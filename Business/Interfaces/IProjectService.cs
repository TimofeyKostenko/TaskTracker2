using Domain.Entities;


namespace Business.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>?> GetAllAsync();
        Task<Project?> GetProjectAsync(int projectId);
        Task<Project> CreateProjectAsync(Project project);
        Task<bool> DeleteProjectAsync(int projectId);
        Task<Project> EditProjectAsync(int projectId, Project project);
        Task<IEnumerable<Mission>?> GetTasksByProjectAsync(int projectId);
    }
}
