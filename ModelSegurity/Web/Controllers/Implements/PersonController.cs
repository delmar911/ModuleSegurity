using Business.Interface;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{

    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase, IPersonController
    {
        private readonly IPersonBusiness _personBusiness;

        public PersonController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetAll()
        {
            var result = await _personBusiness.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> GetById(int id)
        {
            try
            {
                var result = await _personBusiness.GetById(id);
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
        public async Task<ActionResult<Person>> Save([FromBody] PersonDto personDto)
        {
            if (personDto == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _personBusiness.Save(personDto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] PersonDto personDto)
        {
            if (personDto == null || personDto.Id == 0)
            {
                return BadRequest();
            }
            await _personBusiness.Update(personDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleted(int id)
        {
            await _personBusiness.Deleted(id);
            return NoContent();
        }
    }   

}
