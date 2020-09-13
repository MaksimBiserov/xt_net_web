using System;
using System.Collections.Generic;
using UsersAndAwards.Entities;
using UsersAndAwards.DAL.Interfaces;
using System.IO;
using Newtonsoft.Json;

namespace UsersAndAwards.DAL
{
    public class UserDAL: IUserDAL
    {
        private static Dictionary<Guid, User> users = new Dictionary<Guid, User>();

        public UserDAL()
        {
            CreatorDefault.CreateSourceFilesAndFolders();
            ReadDataFile();
        }

        public Guid Add(User user)
        {
            user.ID = Guid.NewGuid();
            user.Age = DateTime.Now.Year - user.DateOfBirth.Year;

            using (var streamWriter = new StreamWriter(CreatorDefault.PathUser))
            {
                streamWriter.WriteLine(JsonConvert.SerializeObject(user));
                users.Add(user.ID, user);
            }
            return user.ID;
        }

        public void DeleteById(Guid id)
        {
            users.Remove(id);

            using (var streamWriter = new StreamWriter(CreatorDefault.PathUser))
            {
                foreach (var item in users.Values)
                {
                    streamWriter.WriteLine(JsonConvert.SerializeObject(item));
                }
            }
        }

        public IEnumerable<User> GetAll()
        {
            return users.Values;
        }

        private void ReadDataFile()
        {
            using (var streamReader = new StreamReader(CreatorDefault.PathUser))
            {
                while (streamReader.Peek() >= 0)
                {
                    var user = JsonConvert.DeserializeObject<User>(streamReader.ReadLine());
                    users?.Add(user.ID, user);
                }
            }
        }
    }
}
