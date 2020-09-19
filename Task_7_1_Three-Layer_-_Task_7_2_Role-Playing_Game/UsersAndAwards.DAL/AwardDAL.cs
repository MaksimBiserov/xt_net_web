using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAL
{
    public class AwardDAL: IAwardDAL
    {
        private static Dictionary<Guid, Award> awards = new Dictionary<Guid, Award>();

        public AwardDAL()
        {
            CreatorDefault.CreateSourceFilesAndFolders();
            ReadDataFile();
        }

        public Guid Add(Award award)
        {
            award.ID = Guid.NewGuid();
            using (var streamWriter = new StreamWriter(CreatorDefault.PathAward))
            {
                streamWriter.WriteLine(JsonConvert.SerializeObject(award));
                awards.Add(award.ID, award);
            }

            return award.ID;
        }

        public void DeleteById(Guid id)
        {
            awards.Remove(id);

            using (var streamWriter = new StreamWriter(CreatorDefault.PathAward))
            {
                foreach (var item in awards.Values)
                {
                    streamWriter.WriteLine(JsonConvert.SerializeObject(item));
                }
            }
        }

        public IEnumerable<Award> GetAll()
        {
            return awards.Values;
        }
        
        private void ReadDataFile()
        {
            using (var reader = new StreamReader(CreatorDefault.PathAward))
            {
                while (reader.Peek() >= 0)
                {
                    var award = JsonConvert.DeserializeObject<Award>(reader.ReadLine());
                    awards?.Add(award.ID, award);
                }
            }
        }

        public void EditAward(Guid awardID, string title)
        {
            awards[awardID] = new Award()
            {
                ID = awardID,
                Title = title
            };

            using (var streamWriter = new StreamWriter(CreatorDefault.PathAward))
            {
                foreach (var item in awards.Values)
                {
                    streamWriter.WriteLine(JsonConvert.SerializeObject(item));
                }
            }
        }
    }
}