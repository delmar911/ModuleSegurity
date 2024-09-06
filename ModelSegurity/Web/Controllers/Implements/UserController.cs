﻿using Business.Interface;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase, IUserController
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var result = await _userBusiness.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var result = await _userBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<User>> Save([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("userDto is null");
            }
            var result = await _userBusiness.Save(userDto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UserDto userDto)
        {
            if (userDto == null || userDto.Id == 0)
            {
                return BadRequest();
            }
            await _userBusiness.Update(userDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleted(int id)
        {
            await _userBusiness.Deleted(id);
            return NoContent();
        }
    }
}
