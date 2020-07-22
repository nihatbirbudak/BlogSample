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
    public class UserService : IUserService
    {
        private readonly IUnitofWork uow;
        public UserService(IUnitofWork _uow)
        {
            uow = _uow;
        }
        public bool deleteUser(int userId)
        {
            try
            {
                User getUser = uow.GetRepository<User>().Get(z => z.Id == userId);
                uow.GetRepository<User>().Delete(getUser);
                uow.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public List<UserDTO> getAll()
        {
            var userList = uow.GetRepository<User>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<UserDTO>>(userList);
        }

        public UserDTO getUser(int Id)
        {
            var getUser = uow.GetRepository<User>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<UserDTO>(getUser);
        }

        public List<UserDTO> getUserName(string UserName)
        {
            var getName = uow.GetRepository<User>().Get(z => z.UserName.Contains(UserName), null).ToList();
            return MapperFactory.CurrentMapper.Map<List<UserDTO>>(getName);

        }

        public UserDTO newUser(UserDTO user)
        {
            if (!uow.GetRepository<User>().GetAll().Any(z => z.UserName == user.UserName))
            {
                var addedUser = MapperFactory.CurrentMapper.Map<User>(user);
                addedUser.RoleId = 2;
                addedUser = uow.GetRepository<User>().Add(addedUser);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<UserDTO>(addedUser);
            }
            else
            {
                return null;
            }
        }

        public UserDTO updateUser(UserDTO user)
        {
            var selectedUser = uow.GetRepository<User>().Get(z => z.Id == user.Id);
            selectedUser = MapperFactory.CurrentMapper.Map<User>(user);
            uow.GetRepository<User>().Update(selectedUser);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<UserDTO>(selectedUser);
        }

        public UserDTO FindwithUsernameandMail(string mailorUserName, string password)
        {
            var getUser = uow.GetRepository<User>().Get(z =>
                 (z.Mail == mailorUserName || z.UserName == mailorUserName) && z.Password == password);
            return MapperFactory.CurrentMapper.Map<UserDTO>(getUser);
        }

        public List<UserDTO> getAllUserinRole(int RoleID)
        {
            throw new NotImplementedException();
        }
    }
}
