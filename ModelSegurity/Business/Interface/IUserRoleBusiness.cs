using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IUserRoleBusiness
    {
        public Task Delete(int id);
        public Task<UserRoleDto> GetById(int id);
        //Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<UserRoleDto> Save(UserRoleDto entity);
        public Task<UserRoleDto> Update(UserRoleDto entity);

        public Task<IEnumerable<UserRoleDto>> GetAll();
    }
}
