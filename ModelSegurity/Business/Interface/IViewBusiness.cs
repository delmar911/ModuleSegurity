using Entity.Dto;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IViewBusiness
    {
        public Task Delete(int id);
        public Task<ViewDto> GetById(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<View> Save(ViewDto entity);
        public Task Update(ViewDto entity);

        public Task<IEnumerable<ViewDto>> GetAll();



    }
}
