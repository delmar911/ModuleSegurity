﻿using Business.Implements;
using Business.Interface;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase, ICountryController
    {
        private readonly ICountryBusiness _countryBusiness;

        public CountryController(ICountryBusiness countryBusiness)
        {
            _countryBusiness = countryBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetAll()
        {
            var result = await _countryBusiness.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetById(int id)
        {
            try
            {
                var result = await _countryBusiness.GetById(id);
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
        public async Task<ActionResult<Country>> Save([FromBody] CountryDto countryDto)
        {
            if (countryDto == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _countryBusiness.Save(countryDto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CountryDto countryDto)
        {
            if (countryDto == null || countryDto.Id == 0)
            {
                return BadRequest();
            }
            await _countryBusiness.Update(countryDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _countryBusiness.Delete(id);
            return NoContent();
        }
    }
}
