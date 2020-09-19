using System;
using System.Collections.Generic;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAL.Interfaces
{
    public interface IRegistratorDAL
    {
        void AddRoleGuest(Registrator regUser);
        void AddRoleUser(Guid iD);
        void AddRoleAdmin(Guid iD);
        IEnumerable<Registrator> GetAll();
    }
}