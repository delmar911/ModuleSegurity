using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IDepartmetBusiness
    {
        public Task Delete(int id);
        public Task<DepartmentDto> GetById(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<Department> Save(DepartmentDto entity);
        public Task Update(DepartmentDto entity);
        public Task<IEnumerable<DepartmentDto>> GetAll();
    }
}
