using Entity.Dto;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IModuleBusiness
    {
        public Task Deleted(int id);
        public Task<ModuleDto> GetById(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<Module> Save(ModuleDto entity);
        public Task Update(ModuleDto entity);
        public Task<IEnumerable<ModuleDto>> GetAll();


    }
}
