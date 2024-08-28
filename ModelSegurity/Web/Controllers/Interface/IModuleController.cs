using Entity.Dto;
using System.Reflection;

namespace Web.Controllers.Interface
{
    public interface IModuleController
    {
        public Task<IEnumerable<ModuleDto>> GetAll();
        public Task<ModuleDto> GetById(int id);
        public Task<Module>Save(ModuleDto entity);
        public Task Update(ModuleDto entity);
        public Task Deleted(int id);
    }
}
