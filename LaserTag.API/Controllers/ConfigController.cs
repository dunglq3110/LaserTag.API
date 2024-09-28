using LaserTag_API.Core.Interfaces.IServices;
using LaserTag_API.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaserTag.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigService _configService;
        public ConfigController(IConfigService configService)
        {
            _configService = configService;
        }
        [HttpGet]
        public async Task<ActionResult<List<config>>> GetAllConfig()
        {
            var configList = await _configService.GetAllConfigsAsync();
            return Ok(configList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<config>> GetConfig(int id)
        {
            var config = await _configService.GetConfigsAsync(id);
            if (config == null)
            {
                return BadRequest("Player not found");
            }
            return Ok(config);
        }
        [HttpPost]
        public async Task<ActionResult<List<config>>> AddConfig(config config)
        {
            var addconfig = await _configService.AddConfigAsync(config);

            return Ok(addconfig);
        }
        [HttpPut]
        public async Task<ActionResult<List<config>>> UpdateConfig(config updateConfig)
        {
            var dbconfig = await _configService.UpdateConfigAsync(updateConfig);

            return Ok(dbconfig);
        }

        [HttpDelete]
        public async Task<ActionResult<List<config>>> DeleteConfig(int id)
        {
            var config = await _configService.DeleteConfigAsync(id);

            return Ok(config);
        }
    }
}
