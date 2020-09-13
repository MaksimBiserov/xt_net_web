using System;
using System.Collections.Generic;
using UsersAndAwards.Entities;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.DAL.Interfaces;

namespace UsersAndAwards.BLL
{
    public class BindingUserAwardLogic : IBindingUserAwardLogic
    {
        private readonly IBindingUserAwardDAL bindingDAL;

        public BindingUserAwardLogic(IBindingUserAwardDAL bindingDAL)
        {
            this.bindingDAL = bindingDAL;
        }

        public void Add(Guid userID, Guid awardID)
        {
            bindingDAL.Add(userID, awardID);
        }

        public void DeleteByID(Guid userID, Guid awardID)
        {
            bindingDAL.DeleteByID(userID, awardID);
        }

        public void DeleteUser(Guid userID)
        {
            bindingDAL.DeleteUser(userID);
        }

        public void DeleteAward(Guid awardID)
        {
            bindingDAL.DeleteAward(awardID);
        }

        public IEnumerable<BindingUserAward> GetAll(Guid userID)
        {
            return bindingDAL.GetAll(userID);
        }
    }
}