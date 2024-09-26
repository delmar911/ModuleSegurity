using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interface
{
    public interface IModuleData
    {
        public Task Delete(int id);
        public Task<Module> GetById(int id);
        Task<IEnumerable<ModuleDto>> GetAll();
        public Task<Module> Save(Module entity);
        public Task Update(Module entity);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
