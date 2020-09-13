using System;

namespace UsersAndAwards.Entities
{
    public class BindingUserAward
    {
        public Guid UserID { get; set; }
        public Guid AwardID { get; set; }
    }
}