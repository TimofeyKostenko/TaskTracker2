
using Business.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        //get project by id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var project = projectService.GetProject(id);
            if (project == null)
            {
                return BadRequest("There is no project with this ID");
            }
            return Ok(project);
        }

        //get all the projects
        [HttpGet]
        public IActionResult Get()
        {
            var projects = projectService.GetAll();
            return Ok(projects);
        }
       //Create new project
        [HttpPost]
        public IActionResult Post([FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Incorrect data");
            }
            var newProject = projectService.CreateProject(project);
            return StatusCode(StatusCodes.Status201Created);

        }

        // update project data
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Project project)
        {
            var currentProject = projectService.GetProject(id);
            if (currentProject == null)
            {
                return BadRequest("There is no project with this ID");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Incorrect data");
            }
            var newProject = projectService.EditProject(id, project);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var mission = projectService.GetProject(id);
            if (mission == null)
            {
                return BadRequest("There is no project with this ID");
            }
            projectService.DeleteProject(id);
            return StatusCode(StatusCodes.Status201Created);
        }

        //get all tasks of one project by projectId
        [HttpGet("{projectId}/Missions")]
        public IActionResult GetallMissionsByProject(int projectId)
        {
            var project = projectService.GetProject(projectId);
            if (project == null)
            {
                return BadRequest("There is no project with this ID");
            }
            var missions = projectService.GetTasksByProject(projectId);
            return Ok(missions);

        }
    }
}
