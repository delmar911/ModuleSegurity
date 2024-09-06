using Entity.Dto;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IPersonBusiness
    {
        public Task Deleted(int id);
        public Task<PersonDto> GetById(int id);
       
        public Task<Person> Save(PersonDto entity);
        public Task Update(PersonDto entity);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();

        public Task<IEnumerable<PersonDto>> GetAll();
    }
}
