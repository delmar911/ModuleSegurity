using Data.Interface;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.Extensions.Configuration;

namespace Data.Implements
{
    public class UserRoleData : IUserRoleData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;


        public UserRoleData(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()

        {
            var sql = @"SELECT  Id, UserId, RoleId 
                        FROM  userroles 
                        ORDER BY 
                        Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);

        }
        public async Task<IEnumerable<UserRoleDto>> GetAll()

        {
            var sql = @"SELECT  usrol.RoleId, usrol.UserId, usr.Username AS User, rol.Name as Role
                        FROM
                        userroles as usrol
                        INNER JOIN roles AS rol ON rol.Id = usrol.RoleId 
			            INNER JOIN users AS usr ON usr.Id = usrol.UserId
                        WHERE usrol.DeletedAt IS NULL AND usrol.State = 1
                        ORDER BY usrol.Id ASC";
            return await context.QueryAsync<UserRoleDto>(sql);
        }

        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            context.UserRoles.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<UserRole> GetById(int id)
        {
            var sql = @"SELECT * FROM userroles WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<UserRole>(sql, new
            {
                Id = id
            });
        }

        public async Task<UserRole> Save(UserRole entity)

        {
            context.UserRoles.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }


        public async Task Update(UserRole entity)
        {

            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

       
    }
}

