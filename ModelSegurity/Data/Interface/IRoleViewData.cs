using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interface
{
    public interface IRoleViewData
    {
        public Task Delete(int id);
        public Task<RoleView> GetById(int id);
        public Task<RoleView> Save(RoleView entity);
        public Task<RoleView> Update(RoleView entity);
        public Task<IEnumerable<RoleView>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
