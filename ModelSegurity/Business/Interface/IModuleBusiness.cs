using Entity.Dto;

namespace Business.Interface
{
    public interface IModuleBusiness
    {
        public Task Deleted(int id);
        public Task<ModuleDto> GetById(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<ModuleDto> Save(ModuleDto entity);
        public Task<ModuleDto> Update(ModuleDto entity);

        public Task<IEnumerable<ModuleDto>> GetAll();


    }
}
