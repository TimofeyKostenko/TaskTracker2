using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class MissionRepository : IMissionRepository
    {
        private readonly ApplicationDbContext db;

        public MissionRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task CreateAsync(Mission mission)
        {
            await db.Missions.AddAsync(mission);
            await db.SaveChangesAsync();
        }
        public async Task DeleteAsync(Mission mission)
        {
            db.Missions.Remove(mission);
            await db.SaveChangesAsync();
        }
        public async Task<Mission?> GetAsync(int missionId)
        {
            return await db.Missions.SingleOrDefaultAsync(x => x.Id == missionId);
        }
        public async Task<IEnumerable<Mission>?> GetAllAsync()
        {

            return await db.Missions.ToListAsync();
        }
        public async Task<Mission?> UpdateAsync(Mission mission)
        {
            db.Missions.Update(mission);
            await db.SaveChangesAsync();
            return mission;
        }
    }
}
