using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IRoleViewController
    {
        public Task<ActionResult<IEnumerable<RoleViewDto>>> GetAll();

        public Task<ActionResult<RoleViewDto>> GetById(int id);
        public Task<ActionResult<RoleView>> Save([FromBody] RoleViewDto roleViewDto);

        public Task<IActionResult> Update([FromBody] RoleViewDto roleViewDto);

        public Task<IActionResult> Deleted(int id);
    }
}
