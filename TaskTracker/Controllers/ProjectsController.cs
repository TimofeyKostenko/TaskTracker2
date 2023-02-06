using Business.DTO;
using Business.Interfaces;
using Business.NotImplExceptionFilterAttribute;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskTracker.Controllers
{
    [NotImplExceptionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectsController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        //get project by id
        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetAsync(int projectId)
        {
            var project = await projectService.GetProjectAsync(projectId);
            if (project == null)
            {
                return BadRequest("There is no project with this ID");
            }
            return Ok(project);
        }

        //get all the projects
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var projects = await projectService.GetAllAsync();
            return Ok(projects);
        }
       //Create new project
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProjectDTO project)
        {
            var newProject = await projectService.CreateProjectAsync(project);
            var routeValues = new { ProjectName = newProject.ProjectName};
            return CreatedAtRoute(routeValues, newProject);
        }

        // update project data
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int projectId, [FromBody] ProjectDTO project)
        {
            var currentProject = await projectService.GetProjectAsync(projectId);
            if (currentProject == null)
            {
                return BadRequest("There is no project with this ID");
            }
            await projectService.EditProjectAsync(projectId, project);
            return NoContent();
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteAsync(int projectId)
        {
            var mission = await projectService.GetProjectAsync(projectId);
            if (mission == null)
            {
                return BadRequest("There is no project with this ID");
            }
            await projectService.DeleteProjectAsync(projectId);
            return NoContent();
        }

        //get all tasks of one project by projectId
        [HttpGet("{projectId}/Missions")]
        public async Task<IActionResult> GetAllMissionsByProjectAsync(int projectId)
        {
            var project = await projectService.GetProjectAsync(projectId);
            if (project == null)
            {
                return BadRequest("There is no project with this ID");
            }
            var missions = await projectService.GetTasksByProjectAsync(projectId);
            return Ok(missions);
        }
    }
}
