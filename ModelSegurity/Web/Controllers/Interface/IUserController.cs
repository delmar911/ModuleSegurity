using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IUserController
    {
        public Task<ActionResult<IEnumerable<UserDto>>> GetAll();

        public Task<ActionResult<UserDto>> GetById(int id);
        public Task<ActionResult<User>> Save([FromBody] UserDto userDto);

        public Task<IActionResult> Update([FromBody] UserDto userDto);

        public Task<IActionResult> Deleted(int id);
    }
}
