using BlogSample.Core.Services;
using BlogSample.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.BLL.Abstract
{
    public interface IRoleService : IServiceBase
    {
        List<RoleDTO> getAll();
        RoleDTO getRole(int Id);
        List<RoleDTO> getRoleName(string roleName);
        RoleDTO newRole(RoleDTO role);
        RoleDTO updateRole(RoleDTO role);
        bool deleteRole(int roleId);

    }
}
