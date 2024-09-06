using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;


namespace Web.Controllers.Interface
{
    public interface IModuleController
    {
        public Task<ActionResult<IEnumerable<ModuleDto>>> GetAll();

        public Task<ActionResult<ModuleDto>> GetById(int id);
        public  Task<ActionResult<Module>> Save([FromBody] ModuleDto moduleDto);

        public  Task<IActionResult> Update([FromBody] ModuleDto moduleDto);

        public Task<IActionResult> Deleted(int id);
    }
}
