using LaserTag_API.Core.Interfaces.IServices;
using LaserTag_API.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaserTag.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ShootLogController : ControllerBase
    {
        private readonly IShootLogService _shootLogService;
        public ShootLogController(IShootLogService shootLogService)
        {
            _shootLogService = shootLogService;
        }
        [HttpGet]
        public async Task<ActionResult<List<shoot_log>>> GetAllShootLog()
        {
            var shootLogList = await _shootLogService.GetAllShootLogsAsync();
            return Ok(shootLogList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<shoot_log>> GetShootLog(string id)
        {
            var shootLog = await _shootLogService.GetShootLogAsync(id);
            if (shootLog == null)
            {
                return BadRequest("ShootLog not found");
            }
            return Ok(shootLog);
        }
        [HttpPost]
        public async Task<ActionResult<List<shoot_log>>> AddShootLog(shoot_log shootLog)
        {
            var addshootLog = await _shootLogService.AddShootLogAsync(shootLog);

            return Ok(addshootLog);
        }
        [HttpPut]
        public async Task<ActionResult<List<shoot_log>>> UpdateShootLog(shoot_log updateShootLog)
        {
            var dbshootLog = await _shootLogService.UpdateShootLogAsync(updateShootLog);

            return Ok(dbshootLog);
        }

        [HttpDelete]
        public async Task<ActionResult<List<shoot_log>>> DeleteShootLog(string id)
        {
            var shootLog = await _shootLogService.DeleteShootLogAsync(id);

            return Ok(shootLog);
        }
    }
}
