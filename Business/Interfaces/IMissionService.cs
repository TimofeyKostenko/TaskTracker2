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
        Task<IEnumerable<Mission>?> GetAllAsync();
        Task<Mission?> GetMissionAsync(int missionId);
        Task<Mission> CreateMissionAsync(Mission mission);
        Task<bool> DeleteMissionAsync(int missionId);
        Task<Mission> EditMissionAsync(int missionId, Mission mission);
    }
}
