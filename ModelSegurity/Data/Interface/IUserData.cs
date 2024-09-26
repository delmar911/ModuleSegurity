using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interface
{
    public interface IUserData
    {

        public Task Delete(int id);
        public Task<User> GetById(int id);
        Task<IEnumerable<UserDto>> GetAll();
        public Task<User> Save(User entity);
        public Task Update(User entity);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}


