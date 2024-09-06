using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interface
{
    public interface IViewData
    {
        public Task Delete(int id);
        public Task<View> GetById(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<View>> GetAll();
        public Task<View> Save(View entity);
        public Task<View> Update(View entity);
    }
}
