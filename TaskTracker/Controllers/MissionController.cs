
using Business.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskTracker.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly IMissionService missionService;

        public MissionController(IMissionService missionService)
        {
            this.missionService = missionService;
        }

        //get Task by Id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var mission = missionService.GetMission(id);
            if (mission == null)
            {
                return NotFound("There is no task with this ID");
            }
            return Ok(mission);
        }

        //get all tasks
        [HttpGet]
        public IActionResult Get()
        {
            var missions = missionService.GetAll();
            return Ok(missions);
        }

        // create new task
        [HttpPost]
        public IActionResult Post([FromBody] Mission mission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Incorrect data");
            }
            var newMission = missionService.CreateMission(mission);
            return StatusCode(StatusCodes.Status201Created);

        }

        //update task data 
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Mission mission)
        {
            if (mission == null)
            {
                return BadRequest("There is no task with this ID");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Incorrect data");
            }
            missionService.EditMission(id, mission);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var mission = missionService.GetMission(id);
            if (mission == null)
            {
                return BadRequest("There is no task with this ID");
            }
            missionService.DeleteMission(id);
            var newMissions = missionService.GetAll();
            return NoContent();
        }
    }
}
