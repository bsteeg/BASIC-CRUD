using System;

namespace BasicCrud.Data.Domain
{
    public class UserSessionDomain : IDomain
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime TokenCreated { get; set; }

        public DateTime LastActivity { get; set; }

        public Guid Token { get; set; }

        public virtual UserDomain User { get; set; }
    }
}
