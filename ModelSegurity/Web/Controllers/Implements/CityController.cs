using Business.Interface;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase, ICityController
    {
        private readonly ICityBusiness _cityBusiness; 

        public CityController(ICityBusiness cityBusiness)
        {
            _cityBusiness = cityBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetAll()
        {
            var result = await _cityBusiness.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetById(int id)
        {
            try
            {
                var result = await _cityBusiness.GetById(id);
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
        public async Task<ActionResult<City>> Save([FromBody] CityDto cityDto)
        {
            if (cityDto == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _cityBusiness.Save(cityDto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CityDto cityDto)
        {
            if (cityDto == null || cityDto.Id == 0)
            {
                return BadRequest();
            }
            await _cityBusiness.Update(cityDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cityBusiness.Delete(id);
            return NoContent();
        }
    }
}
