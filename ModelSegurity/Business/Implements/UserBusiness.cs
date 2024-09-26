using Business.Interface;
using Data.Interface;
using Entity.Dto;
using Entity.Model.Security;

namespace Business.Implements
{
    public class UserBusiness : IUserBusiness
    {
        protected readonly IUserData data;
        public UserBusiness(IUserData data)
        {
            this.data = data;
        }
        public async Task Deleted(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            IEnumerable<UserDto> users = await this.data.GetAll();

            return users;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<UserDto> GetById(int id)
        {

            User user = await this.data.GetById(id);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }
            UserDto userDto = new UserDto();
            
                userDto.Id = user.Id;
                userDto.Username = user.Username;
                userDto.Password = user.Password;
                userDto.State = user.State;
                userDto.PersonId = user.PersonId;
            
            return userDto;
        }
        public User MappingData(User user, UserDto entity)
        {
            user.Id = entity.Id;
            user.Username = entity.Username;
            user.Password = entity.Password;
            user.State = entity.State;
            user.PersonId = entity.PersonId;

            return user;
        }
        public async Task<User> Save(UserDto entity)
        {
            User user = new User();
            user.CreateAt = DateTime.Now.AddHours(-5);
            user = this.MappingData(user, entity);

            return await this.data.Save(user);
        }
        public async Task Update(UserDto entity)
        {
            User user = await this.data.GetById(entity.Id);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }
            user = this.MappingData(user, entity);
            await this.data.Update(user);
        }
    }
}
