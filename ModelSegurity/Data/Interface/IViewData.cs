using Entity.Model.Security;

namespace Data.Interface
{
    public interface IViewData
    {
        public Task Delete(int id);
        public Task<View> GetById(int id);

        Task<IEnumerable<View>> GetAll();
        public Task<View> Save(View entity);
        public Task<View> Update(View entity);
    }
}
