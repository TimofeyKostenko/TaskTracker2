using Domain.Entities;

namespace DAL.Repositories
{
    public class ProjectRepository : IBaseRepository<Project>
    {
        private readonly ApplicationDbContext db;
        public ProjectRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> Create(Project entity)
        {
            await db.Projects.AddAsync(entity);
            await db.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Delete(Project entity)
        {
            db.Projects.Remove(entity);
            await db.SaveChangesAsync();
            return true;
        }

        public Project? Get(int id)
        {
            return db.Projects.FirstOrDefault(x => x.Id == id);
        }
        
        public IQueryable<Project>? GetAll()
        {
            return db.Projects;
        }

        public async Task<Project> Update(Project entity)
        {
            db.Projects.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public IQueryable<Mission> GetTasks(int projectId)
        {
            var missions = db.Missions.Where(m => m.ProjectId == projectId).OrderBy(m => m.Priority).Select(m => new Mission
            {
                MissionName = m.MissionName,
                Description = m.Description,
                Status = m.Status,
                Priority = m.Priority,
                ProjectId = m.ProjectId
            });
            return missions;
        }
    }
}
