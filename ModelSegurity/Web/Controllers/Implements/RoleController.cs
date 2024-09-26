using Business.Interface;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase, IRoleController
    {
        private readonly IRoleBusiness _roleBusiness;

        public RoleController(IRoleBusiness roleBusiness)
        {
            _roleBusiness = roleBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetAll()
        {
            var result = await _roleBusiness.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetById(int id)
        {
            try
            {
                var result = await _roleBusiness.GetById(id);
                    if (result == null)
                    {
                        return NotFound();
                    }
                    return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(201, "El registro no exite");
            }

        }
        [HttpPost]
        public async Task<ActionResult<Role>> Save([FromBody] RoleDto roleDto)
        {
            if (roleDto == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _roleBusiness.Save(roleDto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] RoleDto roleDto)
        {
            if (roleDto == null || roleDto.Id == 0)
            {
                return BadRequest();
            }
            await _roleBusiness.Update(roleDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleted(int id)
        {
            await _roleBusiness.Delete(id);
            return NoContent();
        }
    }
}
