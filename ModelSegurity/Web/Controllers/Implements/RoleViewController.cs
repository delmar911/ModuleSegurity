using Business.Interface;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;


namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class RoleViewController : ControllerBase, IRoleViewController
    {
        private readonly IRoleViewBusiness _roleViewBusiness;

        public RoleViewController(IRoleViewBusiness roleViewBusiness)
        {
            _roleViewBusiness = roleViewBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleViewDto>>> GetAll()
        {
            var result = await _roleViewBusiness.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleViewDto>> GetById(int id)
        {
            var result = await _roleViewBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<RoleView>> Save([FromBody] RoleViewDto roleViewDto)
        {
            if (roleViewDto == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _roleViewBusiness.Save(roleViewDto);
            return CreatedAtAction(nameof(GetById), new {id = result.Id});
        }
        [HttpPut("{id}")] 
        public async Task<IActionResult> Update([FromBody] RoleViewDto roleViewDto)
        {
            if(roleViewDto == null || roleViewDto.Id == 0)
            {
                return BadRequest();
            }
            await _roleViewBusiness.Update(roleViewDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleted(int id)
        {
            await _roleViewBusiness.Deleted(id);
            return NoContent();
        }
    }
}
