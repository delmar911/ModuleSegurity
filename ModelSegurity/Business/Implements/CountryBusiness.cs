using Business.Interface;
using Data.Interface;
using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class CountryBusiness : ICountryBusiness
    {
        protected readonly ICountryData data;
        public CountryBusiness(ICountryData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<CountryDto>> GetAll()
        {
            IEnumerable<Country> countries = await this.data.GetAll();
            var countryDtos = countries.Select(country => new CountryDto
            {
                Id = country.Id,
                Name = country.Name,
                isoCode = country.isoCode,
                Currency = country.Currency

            });
            return countryDtos;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<CountryDto>GetById(int id)
        {
            Country country = await this.data.GetById(id);
            CountryDto countryDto = new CountryDto();

            countryDto.Id = id;
            countryDto.Name = country.Name;
            countryDto.isoCode = country.isoCode;
            countryDto.Currency = country.Currency;

            return countryDto;
        }
        public Country MappingData(Country country, CountryDto entity)
        {
            country.Id = entity.Id;
            country.Name = entity.Name;
            country.isoCode= entity.isoCode;
            country.Currency = entity.Currency;

            return country;
        }
        public async Task<Country>Save(CountryDto entity)
        {
            Country country = new Country();
            country.CreateAt = DateTime.Now.AddHours(-5);
            country = this.MappingData(country, entity);

            return await this.data.Save(country);
        }
        public async Task Update(CountryDto entity)
        {
            Country country = await this.data.GetById(entity.Id);
            if (country == null)
            {
                throw new Exception("Registro no encontrado");
            }
            country = this.MappingData(country, entity);
            await this.data.Update(country);
        }
    }
}
