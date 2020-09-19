using System;
using System.Collections.Generic;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAL.Interfaces
{
    public interface IUserDAL
    {
        Guid Add(User user);
        void DeleteById(Guid id);
        IEnumerable<User> GetAll();
        void EditUser(Guid userID, string name, DateTime dateOfBirth);
    }
}