using Data.Interface;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class CityData : ICityData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public CityData(ApplicationDbContext context, IConfiguration configuration)
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
                City
                WHERE Deleted_at IS NULL AND State = 1
                ORDER BY Id ASC";

            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<City>> GetAll()
        {
            var sql = @"SELECT
                *
                FROM
                City
                WHERE Deleted_at IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<City>(sql);
        }
        public async Task<City> GetById(int id)
        {
            var sql = @"SELECT * FROM City WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<City>(sql, new
            {
                Id = id
            });
        }
        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro No encontrados");
            }
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            context.Cities.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<City> Save(City entity)

        {
            context.Cities.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task Update(City entity)
        {

            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
        Task<City> ICityData.Update(City entity)
        {
            throw new NotImplementedException();
        }

    }
}
