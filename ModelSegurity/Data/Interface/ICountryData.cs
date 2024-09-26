using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface ICountryData
    {
        public Task Delete(int id);
        public Task<Country> GetById(int id);
        public Task<IEnumerable<Country>> GetAll();
        public Task<Country> Save(Country entity);
        public Task Update(Country entity);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
