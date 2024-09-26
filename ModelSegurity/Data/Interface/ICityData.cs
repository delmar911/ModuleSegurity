using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interface
{
    public interface ICityData
    {
        public Task Delete(int id);
        public Task<City> GetById(int id);
        public Task<IEnumerable<CityDto>> GetAll();
        public Task<City> Save(City entity);
        public Task Update(City entity);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
