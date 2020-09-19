using System;

namespace UsersAndAwards.Entities
{
    public class Registrator
    {
        public Guid ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string[] Role { get; set; }
    }
}