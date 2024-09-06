using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface ICountryController
    {
        public Task<ActionResult<IEnumerable<CountryDto>>> GetAll();

        public Task<ActionResult<CountryDto>> GetById(int id);
        public Task<ActionResult<Country>> Save([FromBody] CountryDto countryDto);

        public Task<IActionResult> Update([FromBody] CountryDto countryDto);

        public Task<IActionResult> Delete(int id);
    }
}
