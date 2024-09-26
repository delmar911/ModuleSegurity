using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interface
{
    public interface IPersonData
    {
        public Task Delete(int id);
        public Task<Person> GetById(int id);

        Task<IEnumerable<PersonDto>> GetAll();
        public Task<Person> Save(Person entity);
        public Task Update(Person entity);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
