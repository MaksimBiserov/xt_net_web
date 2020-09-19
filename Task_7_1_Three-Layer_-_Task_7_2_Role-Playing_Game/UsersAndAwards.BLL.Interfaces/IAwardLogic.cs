using System;
using System.Collections.Generic;
using UsersAndAwards.Entities;

namespace UsersAndAwards.BLL.Interfaces
{
    public interface IAwardLogic
    {
        Guid Add(Award award);
        void DeleteById(Guid iD);
        IEnumerable<Award> GetAll();
        Award GetById(Guid iD);
        void EditAward(Guid awardID, string title);
    }
}