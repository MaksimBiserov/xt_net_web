using System;
using System.Collections.Generic;
using UsersAndAwards.Entities;

namespace UsersAndAwards.BLL.Interfaces
{
    public interface IBindingUserAwardLogic
    {
        void Add(Guid userID, Guid awardID);
        void DeleteByID(Guid userID, Guid awardID);
        void DeleteUser(Guid userID);
        void DeleteAward(Guid awardID);
        IEnumerable<BindingUserAward> GetAll(Guid userID);
    }
}