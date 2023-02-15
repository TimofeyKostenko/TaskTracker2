using Business.DTO;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace TaskTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectsController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetAsync(int projectId)
        {
            var project = await projectService.GetProjectAsync(projectId);
            return Ok(project);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var projects = await projectService.GetAllAsync();
            return Ok(projects);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProjectDTO project)
        {
            var newProject = await projectService.CreateProjectAsync(project);
            return CreatedAtRoute(new { }, newProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int projectId, [FromBody] ProjectDTO project)
        {
            await projectService.EditProjectAsync(projectId, project);
            return NoContent();
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteAsync(int projectId)
        {
            await projectService.DeleteProjectAsync(projectId);
            return NoContent();
        }


        [HttpGet("{projectId}/Missions")]
        public async Task<IActionResult> GetAllMissionsByProjectAsync(int projectId)
        {
            var project = await projectService.GetProjectAsync(projectId); 
            var missions = await projectService.GetTasksByProjectAsync(projectId);
            return Ok(missions);
        }
    }
}
