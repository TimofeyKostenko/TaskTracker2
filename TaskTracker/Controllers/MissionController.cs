using Business;
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


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var mission = missionService.GetMission(id);
            if (mission == null)
            {
                return NotFound();
            }
            return Ok(mission);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var missions = missionService.GetAll();
            return Ok(missions);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Mission mission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var newMission = missionService.CreateMission(mission);
            return StatusCode(StatusCodes.Status201Created);

        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Mission mission)
        {
            if (mission == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
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
                return BadRequest();
            }
            missionService.DeleteMission(id);
            var newMissions = missionService.GetAll();
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
