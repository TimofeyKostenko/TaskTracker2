using Business.DTO;

namespace Business.Interfaces
{
    public interface IMissionService
    {
        Task<IEnumerable<MissionDTO>?> GetAllAsync();
        Task<MissionDTO?> GetMissionAsync(int missionId);
        Task<MissionDTO> CreateMissionAsync(MissionDTO mission);
        Task<bool> DeleteMissionAsync(int missionId);
        Task<MissionDTO> EditMissionAsync(int missionId, MissionDTO mission);
    }
}
