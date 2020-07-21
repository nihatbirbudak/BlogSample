using BlogSample.Core.Services;
using BlogSample.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.BLL.Abstract
{
    public interface IUserService : IServiceBase
    {
        List<UserDTO> getAll();
        UserDTO getUser(int Id);
        List<UserDTO> getUserName(string Name);
        UserDTO newUser(UserDTO User);
        UserDTO updateUser(UserDTO User);
        bool deleteUser(int Id);

        UserDTO FindwithUsernameandMail(string mailorUserName, string password);
        List<UserDTO> getAllUserinRole(int RoleID);
    }
}
