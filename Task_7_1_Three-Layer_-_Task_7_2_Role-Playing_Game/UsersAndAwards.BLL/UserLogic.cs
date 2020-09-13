using System;
using System.Collections.Generic;
using System.Linq;
using UsersAndAwards.Entities;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.DAL.Interfaces;

namespace UsersAndAwards.BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDAL userDAL;

        public UserLogic(IUserDAL userDAL)
        {
            this.userDAL = userDAL;
        }
        public Guid Add(User user)
        {
            return userDAL.Add(user);
        }
        public void DeleteById(Guid id)
        {
            userDAL.DeleteById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return userDAL.GetAll();
        }

        public User GetById(Guid id)
        {
            return userDAL.GetAll().FirstOrDefault(item => item.ID == id);
        }
    }
}