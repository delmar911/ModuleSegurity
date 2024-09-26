using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interface
{
    public interface IUserRoleData
    {
        public Task Delete(int id);
        public Task<UserRole> GetById(int id);

        Task<IEnumerable<UserRoleDto>> GetAll();
        public Task<UserRole> Save(UserRole entity);
        public Task Update(UserRole entity);

        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
