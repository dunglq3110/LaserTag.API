using LaserTag_API.Core.Interfaces.IServices;
using LaserTag_API.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaserTag.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HitLogController : ControllerBase
    {
        private readonly IHitLogService _hitLogService;
        public HitLogController(IHitLogService hitLogService)
        {
            _hitLogService = hitLogService;
        }
        [HttpGet]
        public async Task<ActionResult<List<hit_log>>> GetAllHitLog()
        {
            var hitLogList = await _hitLogService.GetAllHitLogsAsync();
            return Ok(hitLogList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<hit_log>> GetHitLog(string id)
        {
            var hitLog = await _hitLogService.GetHitLogAsync(id);
            if (hitLog == null)
            {
                return BadRequest("HitLog not found");
            }
            return Ok(hitLog);
        }
        [HttpPost]
        public async Task<ActionResult<List<hit_log>>> AddHitLog(hit_log hitLog)
        {
            var addhitLog = await _hitLogService.AddHitLogAsync(hitLog);

            return Ok(addhitLog);
        }
        [HttpPut]
        public async Task<ActionResult<List<hit_log>>> UpdateHitLog(hit_log updateHitLog)
        {
            var dbhitLog = await _hitLogService.UpdateHitLogAsync(updateHitLog);

            return Ok(dbhitLog);
        }

        [HttpDelete]
        public async Task<ActionResult<List<hit_log>>> DeleteHitLog(string id)
        {
            var hitLog = await _hitLogService.DeleteHitLogAsync(id);

            return Ok(hitLog);
        }
    }
}
