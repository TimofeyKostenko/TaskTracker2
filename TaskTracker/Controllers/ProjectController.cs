
using Business.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var project = projectService.GetProject(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var projects = projectService.GetAll();
            return Ok(projects);
        }





        [HttpPost]
        public IActionResult Post([FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var newProject = projectService.CreateProject(project);
            return StatusCode(StatusCodes.Status201Created);

        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Project project)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
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
                return BadRequest();
            }
            projectService.DeleteProject(id);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
