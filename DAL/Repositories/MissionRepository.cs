using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MissionRepository : IBaseRepository<Mission>
    {
        private readonly ApplicationDbContext db;

        public MissionRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> Create(Mission entity)
        {
            await db.Missions.AddAsync(entity);
            await db.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Delete(Mission entity)
        {
            db.Missions.Remove(entity);
            await db.SaveChangesAsync();
            return true;
        }

        public Mission? Get(int id)
        {
            return db.Missions.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Mission>? GetAll()
        {
            return db.Missions;
        }

        public IQueryable<Mission> GetTasks(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Mission> Update(Mission entity)
        {
            db.Missions.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
