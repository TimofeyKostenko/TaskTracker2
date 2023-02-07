using Business.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
