using System;

namespace BasicCrud.Data.Domain
{
    public class UserDomain : IDomain
    {
        public int Id { get; set; }

        // Profile information
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        // Only in domain
        public string Password { get; set; }

        // Hash
        public byte[] Hash { get; set; }
    }
}
