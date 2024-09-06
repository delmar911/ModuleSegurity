using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IUserRoleController
    {
        public Task<ActionResult<IEnumerable<UserRoleDto>>> GetAll();

        public Task<ActionResult<UserRoleDto>> GetById(int id);
        public Task<ActionResult<UserRole>> Save([FromBody] UserRoleDto userRoleViewDto);

        public Task<IActionResult> Update([FromBody] UserRoleDto userRoleViewDto);

        public Task<IActionResult> Deleted(int id);
    }
}
