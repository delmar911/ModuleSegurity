using Entity.Dto;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IUserBusiness
    {
        public Task<IEnumerable<UserDto>> GetAll();
        public Task Deleted(int id);
        public Task<UserDto> GetById(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<User> Save(UserDto entity);
        public Task Update(UserDto entity);

    }
}
