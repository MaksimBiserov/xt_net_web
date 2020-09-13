using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using UsersAndAwards.Entities;
using UsersAndAwards.DAL.Interfaces;

namespace UsersAndAwards.DAL
{
    public class BindingUserAwardDAL: IBindingUserAwardDAL
    {
        private static List<BindingUserAward> bindingEntities = new List<BindingUserAward>();
        
        public BindingUserAwardDAL()
        {
            CreatorDefault.CreateSourceFilesAndFolders();
            ReadDataFile();
        }

        public void Add(Guid userID, Guid awardID)
        {
            var user = new BindingUserAward()
            {
                UserID = userID,
                AwardID = awardID
            };

            using (var streamWriter = new StreamWriter(CreatorDefault.PathBindingUserAward))
            {
                var value = JsonConvert.SerializeObject(user);
                streamWriter.WriteLine(value);
                bindingEntities.Add(user);
            }
        }

        public void DeleteByID(Guid userID, Guid awardID)
        {
            bindingEntities.Remove(bindingEntities.Find(n => n.UserID == userID && n.AwardID == awardID));

            using (var streamWriter = new StreamWriter(CreatorDefault.PathBindingUserAward))
            {
                foreach (var item in bindingEntities)
                {
                    streamWriter.WriteLine(JsonConvert.SerializeObject(item));
                }
            }
        }

        public void DeleteUser(Guid userID)
        {
            foreach (var item in bindingEntities.FindAll(n => n.UserID == userID))
            {
                bindingEntities.Remove(item);
            }

            using (var streamWriter = new StreamWriter(CreatorDefault.PathBindingUserAward))
            {
                foreach (var item in bindingEntities)
                {
                    streamWriter.WriteLine(JsonConvert.SerializeObject(item));
                }
            }
        }

        public void DeleteAward(Guid awardID)
        {
            foreach (var item in bindingEntities.FindAll(n => n.AwardID == awardID))
            {
                bindingEntities.Remove(item);
            }

            using (var streamWriter = new StreamWriter(CreatorDefault.PathBindingUserAward))
            {
                foreach (var item in bindingEntities)
                {
                    streamWriter.WriteLine(JsonConvert.SerializeObject(item));
                }
            }
        }

        public IEnumerable<BindingUserAward> GetAll(Guid userID)
        {
            return bindingEntities.Where(n => n.UserID == userID);
        }

        private void ReadDataFile()
        {
            using (var streamReader = new StreamReader(CreatorDefault.PathBindingUserAward))
            {
                while (streamReader.Peek() >= 0)
                {
                    var user = JsonConvert.DeserializeObject<BindingUserAward>(streamReader.ReadLine());
                    bindingEntities.Add(user);
                }
            }
        }
    }
}