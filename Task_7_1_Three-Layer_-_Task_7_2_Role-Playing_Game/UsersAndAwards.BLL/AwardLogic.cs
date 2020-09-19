using System;
using System.Collections.Generic;
using System.Linq;
using UsersAndAwards.Entities;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.DAL.Interfaces;

namespace UsersAndAwards.BLL
{
    public class AwardLogic : IAwardLogic
    {
        private readonly IAwardDAL awardDAL;

        public AwardLogic(IAwardDAL awardDAL)
        {
            this.awardDAL = awardDAL;
        }

        public Guid Add(Award award)
        {
            return awardDAL.Add(award);
        }

        public void DeleteById(Guid id)
        {
            awardDAL.DeleteById(id);
        }

        public IEnumerable<Award> GetAll()
        {
            return awardDAL.GetAll();
        }

        public Award GetById(Guid id)
        {
            return awardDAL.GetAll().FirstOrDefault(item => item.ID == id);
        }

        public void EditAward(Guid awardID, string title)
        {
            awardDAL.EditAward(awardID, title);
        }
    }
}