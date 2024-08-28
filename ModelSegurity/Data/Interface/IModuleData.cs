using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interface
{
    public interface IModuleData
    {
        public Task Delete(int id);
        public Task<Module> GetById(int id);
        Task<IEnumerable<Module>> GetAll();
        public Task<Module> Save(Module entity);
        public Task<Module> Update(Module entity);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
