using Entity.Dto;

namespace Business.Interface
{
    public interface IPersonBusiness
    {
        public Task Deleted(int id);
        public Task<PersonDto> GetById(int id);
       
        public Task<PersonDto> Save(PersonDto entity);
        public Task<PersonDto> Update(PersonDto entity);
        
    }
}
