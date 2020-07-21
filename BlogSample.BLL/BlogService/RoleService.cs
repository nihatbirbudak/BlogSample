using BlogSample.BLL.Abstract;
using BlogSample.Core.Data.UnitOfWork;
using BlogSample.DTO;
using BlogSample.Mapping.ConfigProfile;
using BlogSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSample.BLL.BlogService
{
    public class RoleService : IRoleService
    {
        private readonly IUnitofWork uow;
        public RoleService(IUnitofWork _uow)
        {
            uow = _uow;
        }
        public bool deleteRole(int roleId)
        {
            try
            {
                Role getRole = uow.GetRepository<Role>().Get(z => z.Id == roleId);
                uow.GetRepository<Role>().Delete(getRole);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<RoleDTO> getAll()
        {
            var roleListe = uow.GetRepository<Role>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<RoleDTO>>(roleListe);
        }

        public RoleDTO getRole(int Id)
        {
            var getRole = uow.GetRepository<Role>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<RoleDTO>(getRole);
        }

        public List<RoleDTO> getRoleName(string roleName)
        {
            var getRole = uow.GetRepository<Role>().Get(z => z.Name.Contains(roleName), null).ToList();
            return MapperFactory.CurrentMapper.Map<List<RoleDTO>>(getRole);
        }

        public RoleDTO newRole(RoleDTO role)
        {
            if (uow.GetRepository<Role>().GetAll().Any(z => z.Name == role.Name))
            {
                var adedRole = MapperFactory.CurrentMapper.Map<Role>(role);
                adedRole = uow.GetRepository<Role>().Add(adedRole);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<RoleDTO>(adedRole);
            }
            else
            {
                return null;
            }
        }

        public RoleDTO updateRole(RoleDTO role)
        {
            var selectedRole = uow.GetRepository<Role>().Get(z => z.Id == role.Id);
            selectedRole = MapperFactory.CurrentMapper.Map<Role>(role);
            uow.GetRepository<Role>().Update(selectedRole);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<RoleDTO>(selectedRole);
        }
    }
}
