using Entity.Dto;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IRoleViewBusiness
    {
        public Task Deleted(int id);
        public Task<RoleViewDto> GetById(int id);
        
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<RoleView> Save(RoleViewDto entity);
        public Task Update(RoleViewDto entity);

        public Task<IEnumerable<RoleViewDto>> GetAll();
    }
}
