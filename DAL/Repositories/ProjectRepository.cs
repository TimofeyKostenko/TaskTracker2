using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext db;
        public ProjectRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(Project project)
        {
            await db.Projects.AddAsync(project);
            await db.SaveChangesAsync();

        }
        public async Task DeleteAsync(Project project)
        {
            db.Projects.Remove(project);
            await db.SaveChangesAsync();
        }
        public async Task<Project?> GetAsync(int projectId)
        {
            return await db.Projects.SingleOrDefaultAsync(x => x.Id == projectId);
        }
        public async Task<IEnumerable<Project>?> GetAllAsync()
        {
            return await db.Projects.ToListAsync();
        }
        public async Task<Project?> UpdateAsync(Project project)
        {
            db.Projects.Update(project);
            await db.SaveChangesAsync();
            return project;
        }
        public async Task<IEnumerable<Mission>?> GetTasksAsync(int projectId)
        {
            var missions = await  db.Missions.Where(m => m.ProjectId == projectId).OrderBy(m => m.Priority).Select(m => new Mission
            {
                MissionName = m.MissionName,
                Description = m.Description,
                Status = m.Status,
                Priority = m.Priority,
                ProjectId = m.ProjectId
            }).ToListAsync();
            return missions;/// ??????????????????????????????????????
        }
    }
}
