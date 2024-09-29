using LaserTag_API.Core.Interfaces.IServices;
using LaserTag_API.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaserTag.API.Controllers
{
    public class SharedGroupController : ControllerBase
    {
        private readonly ISharedService _sharedService;
        public SharedGroupController(ISharedService sharedService)
        {
            _sharedService = sharedService;
        }
        [HttpGet]
        public async Task<ActionResult<List<shared_group>>> GetAllSharedGroup()
        {
            var list = await _sharedService.GetAllSharedGroupAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<shared_group>> GetSharedGroup(string id)
        {
            var shared_Group = await _sharedService.GetSharedGroupByGroupId(id);
            if (shared_Group == null)
            {
                return BadRequest("Shared Group not found");
            }
            return Ok(shared_Group);
        }

        [HttpPost]
        public async Task<ActionResult<List<shared_group>>> AddSharedGroup(shared_group shared_Group)
        {
            var addsharedgroup = await _sharedService.CreateNewSharedGroupAsync(shared_Group);

            return Ok(addsharedgroup);
        }
    }
}
