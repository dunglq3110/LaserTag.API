using LaserTag_API.Core.Interfaces.IServices;
using LaserTag_API.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaserTag.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeController : ControllerBase
    {
        private readonly IAttributeService _attributeService;
        public AttributeController(IAttributeService attributeService)
        {
            _attributeService = attributeService;
        }
        [HttpGet]
        public async Task<ActionResult<List<attribute>>> GetAllAttribute()
        {
            var attributeList = await _attributeService.GetAllAttributesAsync();
            return Ok(attributeList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<attribute>> GetAttribute(string id)
        {
            var attribute = await _attributeService.GetAttributesAsync(id);
            if (attribute == null)
            {
                return BadRequest("Player not found");
            }
            return Ok(attribute);
        }
        [HttpPost]
        public async Task<ActionResult<List<attribute>>> AddAttribute(attribute attribute)
        {
            var addattribute = await _attributeService.AddAttributeAsync(attribute);

            return Ok(addattribute);
        }
        [HttpPut]
        public async Task<ActionResult<List<attribute>>> UpdateAttribute(attribute updateAttribute)
        {
            var dbattribute = await _attributeService.UpdateAttributeAsync(updateAttribute);

            return Ok(dbattribute);
        }

        [HttpDelete]
        public async Task<ActionResult<List<attribute>>> DeleteAttribute(string id)
        {
            var attribute = await _attributeService.DeleteAttributeAsync(id);

            return Ok(attribute);
        }
    }
}
