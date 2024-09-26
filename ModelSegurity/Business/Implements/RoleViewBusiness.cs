using Business.Interface;
using Data.Interface;
using Entity.Dto;
using Entity.Model.Security;
using System.Data;


namespace Business.Implements
{
    public class RoleViewBusiness : IRoleViewBusiness
    {
        protected readonly IRoleViewData data;
        public RoleViewBusiness(IRoleViewData data)
        {
            this.data = data;
        }
        public async Task Deleted(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<RoleViewDto>> GetAll()
        {
            IEnumerable<RoleViewDto> roleviews = await this.data.GetAll();
           
            return roleviews;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<RoleViewDto> GetById(int id)
        {
            RoleView roleview = await this.data.GetById(id);
            if (roleview == null)
            {
                throw new Exception("Registro no encontrado");
            }
            RoleViewDto roleViewDto = new RoleViewDto();

            roleViewDto.Id = id;
            roleViewDto.ViewId = roleview.ViewId;
            roleViewDto.RoleId = roleview.RoleId;
            
            return roleViewDto;
        }

        public RoleView MappingData(RoleView roleview, RoleViewDto entity)
        {
            roleview.Id = entity.Id;
            roleview.RoleId = entity.RoleId;
            roleview.ViewId = entity.ViewId;
          
            return roleview;
        }
        public async Task<RoleView> Save(RoleViewDto entity)
        {
            RoleView roleview = new RoleView();
            roleview.CreateAt = DateTime.Now.AddHours(-5);
            roleview = this.MappingData(roleview, entity);

            return await this.data.Save(roleview);
        }
        public async Task Update(RoleViewDto entity)
        {
            RoleView roleview = await this.data.GetById(entity.Id);
            if (roleview == null)
            {
                throw new Exception("Registro no encontrado");
            }
            roleview = this.MappingData(roleview, entity);
            await this.data.Update(roleview);
        }

    }
}
