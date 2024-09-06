using Entity.Dto;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IRoleBusiness
    {
        public Task Delete(int id);
        public Task<RoleDto> GetById(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<Role> Save(RoleDto entity);
        public Task Update(RoleDto entity);
        public Task<IEnumerable<RoleDto>> GetAll();
    }
}
