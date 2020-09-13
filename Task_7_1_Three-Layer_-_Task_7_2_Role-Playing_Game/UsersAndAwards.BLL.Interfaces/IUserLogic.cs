using System;
using System.Collections.Generic;
using UsersAndAwards.Entities;

namespace UsersAndAwards.BLL.Interfaces
{
    public interface IUserLogic
    {
        Guid Add(User user);
        void DeleteById(Guid id);
        IEnumerable<User> GetAll();
        User GetById(Guid id);
    }
}