using Business.Interface;
using Data.Interface;
using Entity.Dto;
using Entity.Model.Security;

namespace Business.Implements
{
    public class ViewBusiness : IViewBusiness
    {
        protected readonly IViewData data;
        public ViewBusiness(IViewData data)
        {
            this.data = data;        
        }
        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<ViewDto>> GetAll()
        {
            IEnumerable<View> views = await this.data.GetAll();
            var viewDtos = views.Select(view => new ViewDto
            {
                Id = view.Id,
                Name = view.Name,
                Description = view.Description,
                Module = view.Module,
                ModuleId = view.ModuleId,
                State = view.State

            });
            return viewDtos;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<ViewDto> GetById(int id)
        {
            View view = await this.data.GetById(id);
            if (view == null)
            {
                throw new Exception("Registro no encontrado");
            }
            ViewDto viewDto = new ViewDto
            {
                Id = view.Id,

            };
            return viewDto;
        }

        public View MappingData(View view, ViewDto entity)
        {
            view.Id = entity.Id;
            view.Name = entity.Name;
            view.Description = entity.Description;
            view.Module = entity.Module;
            view.ModuleId = entity.ModuleId;
            view.State = entity.State;
            return view;
        }
        public async Task<View> Save(ViewDto entity)
        {
            View view = new View();
            view.CreateAt = DateTime.Now.AddHours(-5);
            view = this.MappingData(view, entity);
            view.Module = null;

            return await this.data.Save(view);
        }

        public Task<View> Save(View view)
        {
            throw new NotImplementedException();
        }

        public async Task Update(ViewDto entity)
        {
            View view = await this.data.GetById(entity.Id);
            if(view == null)
            {
                throw new Exception("Registro no encontrado");
            }
            view = this.MappingData(view, entity);
            await this.data.Update(view);
        }

       
    }
}
