using Entity.Dto;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IUserBusiness
    {
        public Task Deleted(int id);
        public Task<UserDto> GetById(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<User> Save(UserDto userDto);
        public Task Update(UserDto userDto);

        public Task<IEnumerable<UserDto>> GetAll();
    }
}
