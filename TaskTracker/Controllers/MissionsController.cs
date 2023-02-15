using Business.DTO;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;



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
      
        [HttpGet("{missionId}")]
        public async Task<IActionResult> GetAsync(int missionId)
        {
            var mission = await missionService.GetMissionAsync(missionId);
            return Ok(mission);
        }

        [HttpGet]
        public  async Task<IActionResult> GetAsync()
        {
            var missions = await missionService.GetAllAsync();
            return Ok(missions);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] MissionDTO mission)
        {
            var newMission = await missionService.CreateMissionAsync(mission);
            return CreatedAtRoute(new { }, newMission);
        }

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
