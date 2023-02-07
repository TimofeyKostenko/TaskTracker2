﻿using Business.DTO;


namespace Business.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDTO>?> GetAllAsync();
        Task<ProjectDTO?> GetProjectAsync(int projectId);
        Task<ProjectDTO> CreateProjectAsync(ProjectDTO project);
        Task<bool> DeleteProjectAsync(int projectId);
        Task<ProjectDTO> EditProjectAsync(int projectId, ProjectDTO project);
        Task<IEnumerable<MissionDTO>?> GetTasksByProjectAsync(int projectId);
    }
}
