using Business.Interface;
using Data.Interface;
using Entity.Dto;
using Entity.Model.Security;


namespace Business.Implements
{
    public class ModuleBusiness : IModuleBusiness
    {
        protected readonly IModuleData data;
        public ModuleBusiness(IModuleData data)
        {
            this.data = data;
        }
        public async Task Deleted(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<ModuleDto>> GetAll()
        {
            IEnumerable<ModuleDto> modules = await this.data.GetAll();
           
            return modules;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<ModuleDto> GetById(int id)
        {
            Module module = await this.data.GetById(id);
            if (module == null)
            {
                throw new Exception("Registro no encontrado");
            }
            ModuleDto moduleDto = new ModuleDto
            {
                Id = module.Id,
                Description = module.Description,
                State = module.State
            };
            return moduleDto;
        }

        public Module MappingData(Module module, ModuleDto entity)
        {
            module.Id = entity.Id;
            module.Description = entity.Description;
            module.State = entity.State;


            return module;
        }
        public async Task<Module> Save(ModuleDto entity)
        {
            Module module = new Module();
            module.CreateAt = DateTime.Now.AddHours(-5);
            module = this.MappingData(module, entity);

            return await this.data.Save(module);
        }
        public async Task Update(ModuleDto entity)
        {
            Module module = await this.data.GetById(entity.Id);
            if (module == null)
            {
                throw new Exception("Registro no encontrado");
            }
            module = this.MappingData(module, entity);
            await this.data.Update(module);
        }
       
    }


}
