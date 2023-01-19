using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProjectService
    {
        IQueryable<Project> GetAll();

        Project GetProject(int id);


        Task<Project> CreateProject(Project project);

        Task<bool> DeleteProject(int id);

        Task<Project> EditProject(int id, Project project);
    }
}
