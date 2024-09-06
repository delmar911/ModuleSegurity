using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IPersonController
    {
        public Task<ActionResult<IEnumerable<PersonDto>>> GetAll();

        public Task<ActionResult<PersonDto>> GetById(int id);
        public Task<ActionResult<Person>> Save([FromBody] PersonDto entity);

        public Task<IActionResult> Update([FromBody] PersonDto entity);

        public Task<IActionResult> Deleted(int id);
    }
}
