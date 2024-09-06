using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface ICityController
    {
        public Task<ActionResult<IEnumerable<CityDto>>> GetAll();

        public Task<ActionResult<CityDto>> GetById(int id);
        public Task<ActionResult<City>> Save([FromBody] CityDto CityDto);

        public Task<IActionResult> Update([FromBody] CityDto CityDto);

        public Task<IActionResult> Delete(int id);
    }
}
