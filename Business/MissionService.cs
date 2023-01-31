using Business.Interfaces;
using DAL.Repositories;
using Domain.Entities;

namespace Business
{
    public class MissionService  : IMissionService
    {
        private readonly IMissionRepository missionRepo;

        public MissionService(IMissionRepository missionRepo)
        {
            this.missionRepo = missionRepo;
        }
        public async Task<Mission> CreateMissionAsync(Mission mission)
        {
            var newMission = new Mission()
            {
                MissionName = mission.MissionName,
                ProjectId = mission.ProjectId,
                Description = mission.Description,
                Status = mission.Status,
                Priority = mission.Priority
            };
            await missionRepo.CreateAsync(newMission);
            return newMission;
        }
        public async Task<bool> DeleteMissionAsync(int missionId)
        {
            var mission = await missionRepo.GetAsync(missionId);
            await missionRepo.DeleteAsync(mission);
            return true;
        }
        public async Task<Mission> EditMissionAsync(int missionId, Mission mission)
        {
            var changedMission = await missionRepo.GetAsync(missionId);
            if (changedMission == null)
            {
                throw new ValidationExceptionA("This object does not exist", "");
            };

            changedMission.MissionName = mission.MissionName;
            changedMission.ProjectId = mission.ProjectId;
            changedMission.Description = mission.Description;
            changedMission.Status = mission.Status;
            changedMission.Priority = mission.Priority;

            await missionRepo.UpdateAsync(changedMission);
            return changedMission;
        }
        public async Task<IEnumerable<Mission>?> GetAllAsync()
        {
            return await missionRepo.GetAllAsync();
        }
        public async Task<Mission?> GetMissionAsync(int missionId) => await missionRepo.GetAsync(missionId);
    }
}