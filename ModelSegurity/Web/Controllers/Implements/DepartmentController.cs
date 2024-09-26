using Business.Implements;
using Business.Interface;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase, IDepartmentController
    {
        private readonly IDepartmetBusiness _departmetBusiness;

        public DepartmentController(IDepartmetBusiness departmetBusiness)
        {
            _departmetBusiness = departmetBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAll()
        {
            var result = await _departmetBusiness.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetById(int id)
        {
            try
            {
                var result = await _departmetBusiness.GetById(id);
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
        public async Task<ActionResult<Department>> Save([FromBody] DepartmentDto departmentDto)
        {
            if (departmentDto == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _departmetBusiness.Save(departmentDto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] DepartmentDto departmentDto)
        {
            if (departmentDto == null || departmentDto.Id == 0)
            {
                return BadRequest();
            }
            await _departmetBusiness.Update(departmentDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _departmetBusiness.Delete(id);
            return NoContent();
        }

    }
}
