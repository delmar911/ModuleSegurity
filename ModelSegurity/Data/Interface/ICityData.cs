using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interface
{
    public interface ICityData
    {
        public Task Delete(int id);
        public Task<City> GetById(int id);
        public Task<IEnumerable<City>> GetAll();
        public Task<City> Save(City entity);
        public Task<City> Update(City entity);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
