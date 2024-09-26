using Business.Interface;
using Data.Interface;
using Entity.Dto;
using Entity.Model.Security;
using System.Data;

namespace Business.Implements
{
    public class CityBusiness : ICityBusiness
    {
        protected readonly ICityData data;

        public CityBusiness(ICityData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await data.Delete(id);
        }
        public async Task<IEnumerable<CityDto>> GetAll()
        {
            IEnumerable<CityDto> cities = await this.data.GetAll();
           
            return cities;

        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<CityDto> GetById(int id)
        {
            City city = await this.data.GetById(id);
            if (city == null)
            {
                throw new Exception("El registro no existe");
            }
            CityDto cityDto = new CityDto();

            cityDto.Id = id;
            cityDto.Name = city.Name;
            cityDto.State = city.State;
            cityDto.DepartmentId = city.DepartmentId;



            return cityDto;
        }
        public City MappingData(City city, CityDto entity)
        {
            city.Id = entity.Id;
            city.Name = entity.Name;
            city.State = entity.State;
            city.DepartmentId = entity.DepartmentId;
           

            return city;
        } 
        public async Task<City>Save(CityDto entity)
        {
            City city = new City();
            city.CreateAt = DateTime.Now.AddHours(-5);
            city = this.MappingData(city, entity);

            return await this.data.Save(city);
        }
        public async Task Update(CityDto entity)
        {
            City city = await this.data.GetById(entity.Id);
            if (city == null)
            {
                throw new Exception("Registro no encontrado");
            }
            city = this.MappingData(city, entity);
            await this.data.Update(city);
        }

    }

    
}
