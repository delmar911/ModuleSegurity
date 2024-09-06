using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IDepartmentController
    {
        public Task<ActionResult<IEnumerable<DepartmentDto>>> GetAll();

        public Task<ActionResult<DepartmentDto>> GetById(int id);
        public Task<ActionResult<Department>> Save([FromBody] DepartmentDto DepartmentDto);

        public Task<IActionResult> Update([FromBody] DepartmentDto DepartmentDto);

        public Task<IActionResult> Delete(int id);
    }
}
