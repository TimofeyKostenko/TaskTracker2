using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DAL
{
    public class ApplicationDbContext : DbContext // creating a database context to interact with database
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
            //Map entity to table
            modelBuilder.Entity<Mission>().ToTable("Missions", "dbo");
            modelBuilder.Entity<Project>().ToTable("Projects", "dbo");

            modelBuilder.Entity<Project>().HasMany(p => p.Missions).WithOne(m => m.Project).HasForeignKey(m => m.ProjectId);

        }

    }
}