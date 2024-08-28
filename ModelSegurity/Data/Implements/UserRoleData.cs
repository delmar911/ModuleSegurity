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
            var sql = @"SELECT
            Id,
            CONCAT(PersonId, ' -', Person)
            FROM
            UserRole
            WHERE Deleted_at IS NULL AND State = 1
            ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<UserRole>> GetAll()

        {
            var sql = @"SELECT
            *
            FROM
            UserRole
            WHERE Deleted_at IS NULL AND State = 1
            ORDER BY Id ASC";
            return await context.QueryAsync<UserRole>(sql);
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
            var sql = @"SELECT * FROM UserRole WHERE Id = @Id ORDER BY Id ASC";
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

        Task<UserRole> IUserRoleData.Update(UserRole entity)
        {
            throw new NotImplementedException();
        }
    }
}

