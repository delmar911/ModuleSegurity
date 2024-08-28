using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IUserBusiness
    {
        public Task Deleted(int id);
        public Task<UserDto> GetById(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<UserDto> Save(UserDto entity);
        public Task<UserDto> Update(UserDto entity);

        public Task<IEnumerable<UserDto>> GetAll();
    }
}
