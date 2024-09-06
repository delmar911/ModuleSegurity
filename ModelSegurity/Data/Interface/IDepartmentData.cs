using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IDepartmentData
    {
        public Task Delete(int id);
        public Task<Department> GetById(int id);
        public Task<IEnumerable<Department>> GetAll();
        public Task<Department> Save(Department entity);
        public Task<Department> Update(Department entity);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
