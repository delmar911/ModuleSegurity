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
            var sql = @"SELECT Id, Name FROM departments
                   WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC;";

            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<DepartmentDto>> GetAll()
        {
            var sql = @"SELECT
                    	depa.Id,
                     depa.Name,
                     depa.CountryId,
                     cou.Name AS Country
                     FROM departments AS depa
                     INNER JOIN countries AS cou ON cou.Id = depa.CountryId
                      WHERE depa.DeletedAt IS NULL AND depa.State = 1 ";
            return await context.QueryAsync<DepartmentDto>(sql);
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
       
    }
   
}
