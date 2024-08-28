using Entity.Dto;

namespace Business.Interface
{
    public interface IRoleViewBusiness
    {
        public Task Deleted(int id);
        public Task<RoleViewDto> GetById(int id);
        //Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<RoleViewDto> Save(RoleViewDto entity);
        public Task<RoleViewDto> Update(RoleViewDto entity);

        public Task<IEnumerable<RoleViewDto>> GetAll();
    }
}
