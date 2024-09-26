using Data.Interface;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.Extensions.Configuration;

namespace Data.Implements
{
    public class ViewData : IViewData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;


        public ViewData(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()

        {
            var sql = @"SELECT
                        Id,
                        Name,  Description,  ModuleId
                        FROM
                        views
                        
                        ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<ViewDto>> GetAll()

        {
            var sql = @"SELECT
            *
            FROM
            views
            
            ORDER BY Id ASC";
            return await context.QueryAsync<ViewDto>(sql);
        }

        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            context.Views.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<View> GetById(int id)
        {
            var sql = @"SELECT * FROM views WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<View>(sql, new
            {
                Id = id
            });
        }

        public async Task<View> Save(View entity)

        {
            context.Views.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }


        public async Task Update(View entity)
        {

            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

    }
}
