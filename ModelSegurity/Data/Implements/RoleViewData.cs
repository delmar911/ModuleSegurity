using Data.Interface;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.Extensions.Configuration;

namespace Data.Implements
{
    public class RoleViewData : IRoleViewData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;


        public RoleViewData(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()

        {
            var sql = @"SELECT
                Id
                FROM
                RoleView
                WHERE Deleted_at IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<RoleView>> GetAll()

        {
            var sql = @"SELECT
            *
            FROM
            RoleView
            WHERE Deleted_at IS NULL AND State = 1
            ORDER BY Id ASC";
            return await context.QueryAsync<RoleView>(sql);
        }

        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            context.RoleViews.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<RoleView> GetById(int id)
        {
            var sql = @"SELECT * FROM RoleView WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<RoleView>(sql, new
            {
                Id = id
            });
        }

        public async Task<RoleView> Save(RoleView entity)

        {
            context.RoleViews.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(RoleViewData entity)
        {

            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        Task<RoleView> IRoleViewData.Update(RoleView entity)
        {
            throw new NotImplementedException();
        }

 
    }
}
