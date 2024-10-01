using LaserTag_API.Core.Interfaces.IRepositories;
using LaserTag_API.Core.Interfaces.IServices;
using LaserTag_API.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaserTag.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedBaseController : ControllerBase
    {
        private readonly ISharedService _sharedService;
        public SharedBaseController(ISharedService sharedService)
        {
            _sharedService = sharedService;
        }
        [HttpGet]
        public async Task<ActionResult<List<shared_base>>> GetAllSharedBase()
        {
            var list = await _sharedService.GetAllSharedBaseAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<shared_base>> GetSharedBase(string id)
        {
            var shared_Base = await _sharedService.GetSharedBaseByBaseId(id);
            if (shared_Base == null)
            {
                return BadRequest("Shared Base not found");
            }
            return Ok(shared_Base);
        }

    }
}
