using System;
using System.Collections.Generic;
using UsersAndAwards.Entities;

namespace UsersAndAwards.BLL.Interfaces
{
    public interface IRegistratorLogic
    {
        void AddRoleGuest(Registrator regUser);
        void AddRoleUser(Guid iD);
        void AddRoleAdmin(Guid iD);
        string[] GetRoles(string name);
        IEnumerable<Registrator> GetAll();
        bool IsRole(string name, string role);
        bool ISAuth(string login, string Password);
        Registrator GetByLodin(string login);
    }
}