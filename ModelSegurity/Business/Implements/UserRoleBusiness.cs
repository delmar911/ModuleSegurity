using Business.Interface;
using Data.Interface;
using Entity.Dto;
using Entity.Model.Security;


namespace Business.Implements
{
    public class UserRoleBusiness : IUserRoleBusiness
    {
       protected readonly IUserRoleData data;

       public UserRoleBusiness(IUserRoleData data)
       {

        this.data = data; 
       }
        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<UserRoleDto>> GetAll()
        {
            IEnumerable<UserRoleDto> userroles = await this.data.GetAll();
            
            return userroles;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<UserRoleDto> GetById(int id)
        {
            UserRole userrole = await this.data.GetById(id);
            if (userrole == null)
            {
                throw new Exception("Registro no encontrado");
            }
            UserRoleDto userroleDto = new UserRoleDto();
            {
                userroleDto.Id = id;
                userroleDto.RoleId = userrole.RoleId;
                userroleDto.UserId = userrole.UserId;
                userroleDto.State = userrole.State;
                
            }
            return userroleDto;
        }
        public UserRole MappingData(UserRole userRole, UserRoleDto entity)
        {
            userRole.Id = entity.Id;
            userRole.RoleId = entity.RoleId;
            userRole.UserId = entity.UserId;
            userRole.State = entity.State;

            return userRole;
        }
        public async Task<UserRole> Save(UserRoleDto entity)
        {
            UserRole userrole = new UserRole
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            userrole = this.MappingData(userrole, entity);
            return await this.data.Save(userrole);
        }
        public async Task Update(UserRoleDto entity)
        {
            UserRole userrole = await this.data.GetById(entity.Id);
            if (userrole == null)
            {
                throw new Exception("Registro no encontrado");
            }
            userrole = this.MappingData(userrole, entity);
            await this.data.Update(userrole);
        }
    }
}
