﻿using Business.Interface;
using Data.Interface;
using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class DepartmentBusiness : IDepartmetBusiness
    {
        protected readonly IDepartmentData data;
        public DepartmentBusiness(IDepartmentData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await data.Delete(id);
        }
        public async Task<IEnumerable<DepartmentDto>>GetAll()
        {
            IEnumerable<Department>departments = await data.GetAll();
            var departmentDtos = departments.Select(department => new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,

            });
            return departmentDtos;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<DepartmentDto> GetById(int id)
        {
            Department department = await data.GetById(id);
            DepartmentDto departmentDto = new DepartmentDto();

            departmentDto.Id = id;
            departmentDto.Name = department.Name;

            return departmentDto;
        }
        public Department MappingData(Department department, DepartmentDto entity)
        {
            department.Id = entity.Id;
            department.Name = entity.Name;

            return department;
        }
        public async Task<Department> Save(DepartmentDto entity)
        {
            Department department = new Department();
            department.CreateAt = DateTime.Now.AddHours(-5);
            department = this.MappingData(department, entity);

            return await this.data.Save(department);
        }
        public async Task Update(DepartmentDto entity)
        {
            Department department = await this.data.GetById(entity.Id);
            if (department == null)
            {
                throw new Exception("Registro no encontrado");
            }
            department = this.MappingData(department, entity);
            await this.data.Update(department);
        }
    }
}
