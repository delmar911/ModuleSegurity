using Data.Interface;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.Extensions.Configuration;


namespace Data.Implements
{
    public class CountryData : ICountryData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public CountryData(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT
                Id,
                Name,
                isoCode,
                Currency
                FROM
                Country
                WHERE Deleted_at IS NULL AND State = 1
                ORDER BY Id ASC";

            return await context.QueryAsync<DataSelectDto>(sql);

        }
        public async Task<IEnumerable<Country>> GetAll()
        {
            var sql = @"SELECT
                *
                FROM
                Country
                WHERE Deleted_at IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<Country>(sql);
        }
        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro No encontrados");
            }
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            context.Countries.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<Country>GetById(int id)
        {
            var sql = @"SELECT * FROM Country WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Country>(sql, new
            {
                Id = id
            });
        }
        public async Task<Country> Save(Country entity)

        {
            context.Countries.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task Update(Country entity)
        {

            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
        Task<Country> ICountryData.Update(Country entity)
        {
            throw new NotImplementedException();
        }


    }
}
