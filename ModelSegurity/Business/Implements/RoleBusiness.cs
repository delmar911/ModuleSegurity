﻿using Business.Interface;
using Data.Interface;
using Entity.Dto;
using Entity.Model.Security;

namespace Business.Implements
{
    public class RoleBusiness : IRoleBusiness
    {
        protected readonly IRoleData data;
        public RoleBusiness(IRoleData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<RoleDto>> GetAll()
        {
            IEnumerable<RoleDto> roles = await this.data.GetAll();
            
            return roles;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<RoleDto>GetById(int id)
        {
            Role role = await this.data.GetById(id);
            if (role == null)
            {
                throw new Exception("Registro no encontrado");
            }
            RoleDto RoleDto = new RoleDto();
            RoleDto.Id = id;
            RoleDto.Name = role.Name;
            RoleDto.Description = role.Description;
            RoleDto.State = role.State;

            return RoleDto;
        }
        public Role MappingData(Role role, RoleDto entity) 
        {
            role.Id = entity.Id;
            role.Name = entity.Name;
            role.Description = entity.Description;
            role.State = entity.State;
            
            return role;
        }
        public async Task<Role> Save(RoleDto entity)
        {
            Role role = new Role();
            role.CreateAt = DateTime.Now.AddHours(-5);
            role = this.MappingData(role, entity);

            return await this.data.Save(role);
        }

        public async Task Update(RoleDto entity)
        {
            Role role = await this.data.GetById(entity.Id);
            if(role == null)
            {
                throw new Exception("Registro no encontrado");
            }
            role = this.MappingData(role, entity);  
            await this.data.Update(role);
        }

        
    }
}
