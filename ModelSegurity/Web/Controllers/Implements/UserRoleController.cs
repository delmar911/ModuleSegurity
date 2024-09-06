using Business.Implements;
using Business.Interface;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class UserRoleController : ControllerBase, IUserRoleController
    {
        private readonly IUserRoleBusiness _userRoleBusiness;

        public UserRoleController(IUserRoleBusiness userRoleBusiness)
        {
            _userRoleBusiness = userRoleBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRoleDto>>> GetAll()
        {
            var result = await _userRoleBusiness.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoleDto>> GetById(int id)
        {
            var result =  await _userRoleBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<UserRole>>Save([FromBody] UserRoleDto userRoleViewDto)
        {
            if (userRoleViewDto == null)
            {
                return BadRequest("userRoleViewDto is null");
            }
            var result = await _userRoleBusiness.Save(userRoleViewDto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UserRoleDto userRoleViewDto)
        {
            if(userRoleViewDto == null || userRoleViewDto.Id == 0)
            {
                return BadRequest();
            }
            await _userRoleBusiness.Update(userRoleViewDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleted(int id)
        {
            await _userRoleBusiness.Delete(id);
            return NoContent();
        }
    }
}
