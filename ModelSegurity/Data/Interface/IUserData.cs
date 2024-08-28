using Entity.Model.Security;

namespace Data.Interface
{
    public interface IUserData
    {

        public Task Delete(int id);
        public Task<User> GetById(int id);

        Task<IEnumerable<User>> GetAll();
        public Task<User> Save(User entity);
        public Task<User>Update(User entity);
    }
}


