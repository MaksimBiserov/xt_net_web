using System;
using System.Collections.Generic;
using System.Linq;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.Entities;

namespace UsersAndAwards.BLL
{
    public class RegistratorLogic : IRegistratorLogic
    {
        private readonly IRegistratorDAL registratorDAL;

        public RegistratorLogic(IRegistratorDAL registratorDAL)
        {
            this.registratorDAL = registratorDAL;
        }

        public void AddRoleGuest(Registrator regUser)
        {
            registratorDAL.AddRoleGuest(regUser);
        }

        public void AddRoleUser(Guid iD)
        {
            registratorDAL.AddRoleUser(iD);
        }

        public void AddRoleAdmin(Guid iD)
        {
            registratorDAL.AddRoleAdmin(iD);
        }

        public IEnumerable<Registrator> GetAll()
        {
            return registratorDAL.GetAll();
        }

        public Registrator GetByLodin(string login)
        {
            return registratorDAL.GetAll().FirstOrDefault(item => item.Login == login);
        }

        public string[] GetRoles(string name)
        {
            var user = GetByLodin(name);
            return user != null ? user.Role: new string[] { };
        }

        public bool ISAuth(string login, string Password)
        {
            var user = GetByLodin(login);
            return user != null ? user.Password == Password: false;
        }

        public bool IsRole(string name, string role)
        {
            var user = GetByLodin(name);
            return user != null ? user.Role.Contains(role): false;
        }
    }
}