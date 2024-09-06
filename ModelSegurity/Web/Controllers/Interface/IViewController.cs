using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IViewController
    {
        public Task<ActionResult<IEnumerable<ViewDto>>> GetAll();

        public Task<ActionResult<ViewDto>> GetById(int id);
        public Task<ActionResult<View>> Save([FromBody] ViewDto viewDto);

        public Task<IActionResult> Update([FromBody] ViewDto viewDto);

        public Task<IActionResult> Deleted(int id);
    }
}
