using Data.Interface;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.Extensions.Configuration;

namespace Data.Implements
{
    public class UserData : IUserData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;


        public UserData(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()

        {
            var sql = @"SELECT 
            Id, 
            CONCAT(Username, ' - ', Password, ' - ', PersonId, ' - ', State) AS TextoMostrar 
            FROM 
                users 
            WHERE 
                DeletedAt IS NULL AND State = 1 
            ORDER BY 
                Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);

        }
        public async Task<IEnumerable<UserDto>> GetAll()

        {
            var sql = @"SELECT
                   	us.Id,
                    us.Username,
                    us.Password,
                    us.State,
                    us.PersonId,
                    per.FirstName AS NamePerson

                    FROM users AS us
                    INNER JOIN persons AS per ON per.Id = us.PersonId
                    WHERE us.DeletedAt IS NULL AND us.State = 1 ";

            return await context.QueryAsync<UserDto>(sql);

        }

        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            context.Users.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<User> GetById(int id)
        {
            var sql = @"SELECT * FROM users WHERE Id = @Id ORDER BY Id ASC ";
            return await this.context.QueryFirstOrDefaultAsync<User>(sql, new
            {
                Id = id
            });
        }

        public async Task<User> Save(User entity)

        {
            context.Users.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }


        public async Task Update(User entity)
        {

            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

    
    }
}
