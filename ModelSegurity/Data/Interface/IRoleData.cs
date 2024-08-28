using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interface
{
    public interface IRoleData
    {
        public Task Delete(int id);
        public Task<Role> GetById(int id);
        public Task<Role> Save(Role entity);
        public Task<Role> Update(Role entity);
        public Task<IEnumerable<Role>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();

    }
}
