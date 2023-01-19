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
        IQueryable<Mission>? GetAll();

        Mission GetMission(int id);


        Mission CreateMission(Mission mission);

        Task<bool> DeleteMission(int id);

        Task<Mission> EditMission(int id, Mission mission);

        IQueryable<Mission> GetMissionsProject(int projectId);
    }
}
