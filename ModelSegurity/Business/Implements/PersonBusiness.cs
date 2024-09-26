using Business.Interface;
using Data.Interface;
using Entity.Dto;
using Entity.Model.Security;

namespace Business.Implements
{
    public class PersonBusiness : IPersonBusiness
    {
        protected readonly IPersonData data;
        public PersonBusiness(IPersonData data)
        {
            this.data = data;
        }
        public async Task Deleted(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<PersonDto>> GetAll()
        {
            IEnumerable<PersonDto> persons = await this.data.GetAll();
         
            return persons;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<PersonDto> GetById(int id)
        {
            
            Person person = await this.data.GetById(id);
            if (person == null)
            {
                throw new Exception("El registro no existe");
            }
            PersonDto PersonDto = new PersonDto();

            PersonDto.Id = person.Id;
            PersonDto.FirstName = person.FirstName;
            PersonDto.LastName = person.LastName;
            PersonDto.Email = person.Email;
            PersonDto.Address = person.Address;
            PersonDto.TypeDocument = person.TypeDocument;
            PersonDto.Document = person.Document;
            PersonDto.BirthOfDate = person.BirthOfDate;
            PersonDto.Phone = person.Phone;
            PersonDto.State = person.State;
            PersonDto.CityId = person.CityId;
            return PersonDto;
        }
        public Person MappingData(Person person, PersonDto entity)
        {
            person.Id = entity.Id;
            person.FirstName = entity.FirstName;
            person.LastName = entity.LastName;
            person.Email = entity.Email;
            person.Address = entity.Address;
            person.TypeDocument = entity.TypeDocument;
            person.Document = entity.Document;
            person.BirthOfDate = entity.BirthOfDate;
            person.Phone = entity.Phone;
            person.State = entity.State;
            person.CityId = entity.CityId;
            return person;
        }
        public async Task<Person> Save(PersonDto entity)
        {
            Person person = new Person();
            person.CreateAt = DateTime.Now.AddHours(-5);
            person = this.MappingData(person, entity);
            
            return await this.data.Save(person);
        }
        public async Task Update(PersonDto entity)
        {
            Person person = await this.data.GetById(entity.Id);
            if (person == null)
            {
                throw new Exception("Registro no encontrado");
            }
            person = this.MappingData(person, entity);
            await this.data.Update(person);
        }

       

    }
}
