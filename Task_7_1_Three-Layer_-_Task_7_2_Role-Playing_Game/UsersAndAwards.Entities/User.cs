using System;

namespace UsersAndAwards.Entities
{
    public class User
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
    }
}
