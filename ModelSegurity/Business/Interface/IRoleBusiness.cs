using Entity.Dto;

namespace Business.Interface
{
    public interface IRoleBusiness
    {
        public Task Deleted(int id);
        public Task<RoleDto> GetById(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<RoleDto> Save(RoleDto entity);
        public Task<RoleDto> Update(RoleDto entity);

        public Task<IEnumerable<RoleDto>> GetAll();
    }
}
