using Data.Interface;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.Extensions.Configuration;

namespace Data.Implements
{
    public class DepartmentData : IDepartmentData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public DepartmentData(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
            } 
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT
                    Id,
                    Name
                    FROM
                    Departament
                    WHERE Deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";

            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<Department>> GetAll()
        {
            var sql = @"SELECT
                    *
                    FROM
                    Department
                    WHERE Deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<Department>(sql);
        }
        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro No encontrados");
            }
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            context.Departments.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<Department> GetById(int id)
        {
            var sql = @"SELECT * FROM Department WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Department>(sql, new
            {
                Id = id
            });
        }
        public async Task<Department> Save(Department entity)

        {
            context.Departments.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task Update(Department entity)
        {

            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
        Task<Department> IDepartmentData.Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
   
}
