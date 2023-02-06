﻿using AutoMapper;
using Business.DTO;
using Business.Interfaces;
using DAL.Repositories;
using Domain.Entities;

namespace Business
{
    public class MissionService  : IMissionService
    {
        private readonly IMissionRepository missionRepo;
        private readonly IMapper mapper;

        public MissionService(IMapper mapper, IMissionRepository missionRepo)
        {
            this.missionRepo = missionRepo;
            this.mapper = mapper;
        }
        public async Task<MissionDTO> CreateMissionAsync(MissionDTO mission)
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
            return mapper.Map<MissionDTO>(mission); 
        }
        public async Task<bool> DeleteMissionAsync(int missionId)
        {
            var mission = await missionRepo.GetAsync(missionId);
            await missionRepo.DeleteAsync(mission);
            return true;
        }
        public async Task<MissionDTO> EditMissionAsync(int missionId, MissionDTO mission)
        {
            var changedMission = await missionRepo.GetAsync(missionId);
            if  (changedMission == null)
            {

            }
            changedMission.MissionName = mission.MissionName;
            changedMission.ProjectId = mission.ProjectId;
            changedMission.Description = mission.Description;
            changedMission.Status = mission.Status;
            changedMission.Priority = mission.Priority;

            await missionRepo.UpdateAsync(changedMission);
            return mapper.Map<MissionDTO>(mission);
        }
        public async Task<IEnumerable<Mission>?> GetAllAsync()
        {
            return await missionRepo.GetAllAsync();
        }
        public async Task<Mission?> GetMissionAsync(int missionId)
        {
            return await missionRepo.GetAsync(missionId);

        }
    }
}