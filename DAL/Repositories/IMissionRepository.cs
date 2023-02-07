using Domain.Entities;
namespace DAL.Repositories
{
    public interface IMissionRepository
    {
        Task<IEnumerable<Mission>?> GetAllAsync();
        Task<bool> CreateAsync(Mission mission);
        Task<bool> DeleteAsync(Mission mission);
        Task<Mission?> GetAsync(int missionId);
        Task<Mission?> UpdateAsync(Mission mission);
    }
}
