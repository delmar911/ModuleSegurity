using Entity.Dto;

namespace Business.Interface
{
    public interface IViewBusiness
    {
        public Task Delete(int id);
        public Task<ViewDto> GetById(int id);
        //Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<ViewDto> Save(ViewDto entity);
        public Task<ViewDto> Update(ViewDto entity);

        public Task<IEnumerable<ViewDto>> GetAll();



    }
}
