

using Domain.Entities;

namespace DAL.Repositories
{
    public interface IProjectRepository

    {
       Task<IEnumerable<Project>?> GetAllAsync();
        Task CreateAsync(Project project);
        Task DeleteAsync(Project project);
        Task<Project?> GetAsync(int ProjectId);
        Task<Project?> UpdateAsync(Project project);
        Task<IEnumerable<Mission>?> GetTasksAsync(int projectId);
    }
}
