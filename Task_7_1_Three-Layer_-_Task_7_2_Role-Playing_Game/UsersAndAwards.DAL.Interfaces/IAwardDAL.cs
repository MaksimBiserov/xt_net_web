using System;
using System.Collections.Generic;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAL.Interfaces
{
    public interface IAwardDAL
    {
        Guid Add(Award award);
        void DeleteById(Guid id);
        IEnumerable<Award> GetAll();

    }
}