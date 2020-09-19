using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAL
{
    public class RegistratorDAL : IRegistratorDAL
    {
        private static Dictionary<Guid, Registrator> regUsers = new Dictionary<Guid, Registrator>();

        public RegistratorDAL()
        {
            CreatorDefault.CreateSourceFilesAndFolders();
            ReadDataFile();
        }

        public void AddRoleGuest(Registrator regUser)
        {
            regUser.ID = Guid.NewGuid();

            using (var streamWriter = new StreamWriter(CreatorDefault.PathRegistrator))
            {
                streamWriter.WriteLine(JsonConvert.SerializeObject(regUser));
                regUsers.Add(regUser.ID, regUser);
            }
        }

        public void AddRoleUser(Guid iD)
        {
            var user = regUsers[iD];
            regUsers[iD] = new Registrator()
            {
                ID = user.ID,
                Login = user.Login,
                Password = user.Password,
                Role = new string[] { "User" }
            };

            using (var streamWriter = new StreamWriter(CreatorDefault.PathRegistrator))
            {
                foreach (var item in regUsers.Values)
                {
                    streamWriter.WriteLine(JsonConvert.SerializeObject(item));
                }
            }
        }

        public void AddRoleAdmin(Guid iD)
        {
            var admin = regUsers[iD];
            regUsers[iD] = new Registrator()
            {
                ID = admin.ID,
                Login = admin.Login,
                Password = admin.Password,
                Role = new string[] { "Admin" }
            };

            using (var streamWriter = new StreamWriter(CreatorDefault.PathRegistrator))
            {
                foreach (var item in regUsers.Values)
                {
                    streamWriter.WriteLine(JsonConvert.SerializeObject(item));
                }
            }
        }

        public IEnumerable<Registrator> GetAll()
        {
            return regUsers.Values;
        }

        private void ReadDataFile()
        {
            using (var streamReader = new StreamReader(CreatorDefault.PathRegistrator))
            {
                while (streamReader.Peek() >= 0)
                {
                    var user = JsonConvert.DeserializeObject<Registrator>(streamReader.ReadLine());
                    regUsers.Add(user.ID, user);
                }
            }
        }
    }
}