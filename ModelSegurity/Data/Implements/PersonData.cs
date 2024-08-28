using Data.Interface;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.Extensions.Configuration;

namespace Data.Implements
{
    public class PersonData : IPersonData
    {

        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;


        public PersonData(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()

        {
            var sql = @"SELECT
                Id,
                CONCAT(FirstName, ' -', LastName, ' -', Email, ' -' ,
                        Address,' -' ,TypeDocument,' -' ,Document,' -' ,
                        BirthOfDate,' -' ,Phone )
                FROM
                Person
                WHERE Deleted_at IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<Person>> GetAll()

        {
            var sql = @"SELECT
                *
                FROM
                Person
                WHERE Deleted_at IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<Person>(sql);
        }

        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            context.Persons.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<Person> GetById(int id)
        {
            var sql = @"SELECT * FROM Person WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Person>(sql, new
            {
                Id = id
            });
        }

        public async Task<Person> Save(Person entity)

        {
            context.Persons.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }


        public async Task Update(Person entity)
        {

            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        Task<Person> IPersonData.Update(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
