using Business.DTO;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskTracker.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MissionsController : ControllerBase
    {
        private readonly IMissionService missionService;

        public MissionsController(IMissionService missionService)
        {
            this.missionService = missionService;
        }
        //get Task by Id
        [HttpGet("{missionId}")]
        public async Task<IActionResult> GetAsync(int missionId)
        {
            var mission = await missionService.GetMissionAsync(missionId);
            return Ok(mission);
        }
        //get all tasks
        [HttpGet]
        public  async Task<IActionResult> GetAsync()
        {
            var missions = await missionService.GetAllAsync();
            return Ok(missions);
        }
        // create new task
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] MissionDTO mission)
        {
            var newMission = await missionService.CreateMissionAsync(mission);
            var routeValues = new { name = newMission.MissionName };
            return CreatedAtRoute(routeValues, newMission);
        }
        //update task data 
        [HttpPut("{missionId}")]
        public async Task<IActionResult> PutAsync(int missionId, [FromBody] MissionDTO mission)
        {
            await missionService.EditMissionAsync(missionId, mission);
            return NoContent();
        }

        [HttpDelete("{missionId}")]
        public async Task<IActionResult> DeleteAsync(int missionId)
        {           
            await missionService.DeleteMissionAsync(missionId);
            return NoContent();
        }
    }
}
