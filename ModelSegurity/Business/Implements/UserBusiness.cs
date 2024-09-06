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
            IEnumerable<User> users = await this.data.GetAll();
            var UserDtos = users.Select(users => new UserDto
            {
                Id = users.Id,
                Username = users.Username,
                Password = users.Password,
                State = users.State
            });
            return UserDtos;
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
            {  
                userDto.Id = user.Id;
                userDto.Username = user.Username;
                userDto.Password = user.Password;
                userDto.State = user.State;
            }
            return userDto;
        }
        public User MappingData(User user, UserDto entity)
        {
            user.Id = entity.Id;
            user.Username = entity.Username;
            user.Password = entity.Password;
            user.State = entity.State;
            return user;
        }
        public async Task<User> Save(UserDto userDto)
        {
            User user = new User();
            user.CreateAt = DateTime.Now.AddHours(-5);
            user = this.MappingData(user, userDto);

            return await this.data.Save(user);
        }
        public async Task Update(UserDto userDto)
        {
            User user = await this.data.GetById(userDto.Id);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }
            user = this.MappingData(user, userDto);
            await this.data.Update(user);
        }
    }
}
