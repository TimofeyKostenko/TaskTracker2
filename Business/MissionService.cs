using Business.Interfaces;
using DAL.Repositories;
using Domain.Entities;

namespace Business
{
    public class MissionService  : IMissionService
    {
        private readonly IBaseRepository<Mission> missionRepo;

        public MissionService(IBaseRepository<Mission> missionRepo)
        {
            this.missionRepo = missionRepo;
        }

        public Mission CreateMission(Mission mission)
        {
            var newMission = new Mission()
            {
                MissionName = mission.MissionName,
                ProjectId = mission.ProjectId,
                Description = mission.Description,
                Status = mission.Status,
                Priority = mission.Priority
            };
            missionRepo.Create(newMission);
            return newMission;
        }


        public async Task<bool> DeleteMission(int id)
        {
            var mission = missionRepo.Get(id);
            await missionRepo.Delete(mission);
            return true;
        }


        public async Task<Mission> EditMission(int id, Mission mission)
        {
            var changedMission = missionRepo.Get(id);
            if (changedMission == null)
            {
                throw new ValidationException("This object does not exist", "");
            };

            changedMission.MissionName = mission.MissionName;
            changedMission.ProjectId = mission.ProjectId;
            changedMission.Description = mission.Description;
            changedMission.Status = mission.Status;
            changedMission.Priority = mission.Priority;

            await missionRepo.Update(changedMission);
            return changedMission;
        }


        public IQueryable<Mission>? GetAll() => missionRepo.GetAll();


        public Mission? GetMission(int id) => missionRepo.Get(id);


        public IQueryable<Mission>? GetMissionsProject(int projectId)
        {
            return missionRepo.GetAll().Where(x => x.ProjectId == projectId); ;
        }
    }
}