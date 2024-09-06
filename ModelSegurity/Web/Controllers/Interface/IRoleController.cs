using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IRoleController
    {
        public Task<ActionResult<IEnumerable<RoleDto>>> GetAll();

        public Task<ActionResult<RoleDto>> GetById(int id);
        public Task<ActionResult<Role>> Save([FromBody] RoleDto roleDto);

        public Task<IActionResult> Update([FromBody] RoleDto roleDto);

        public Task<IActionResult> Deleted(int id);
    }
}
