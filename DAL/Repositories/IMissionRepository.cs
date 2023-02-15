using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IMissionRepository
    {
        Task<IEnumerable<Mission>?> GetAllAsync();
        Task CreateAsync(Mission mission);
        Task DeleteAsync(Mission mission);
        Task<Mission?> GetAsync(int missionId);
        Task<Mission?> UpdateAsync(Mission mission);
    }
}
