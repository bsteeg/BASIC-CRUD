using System;

namespace BasicCrud.Data.Entities
{
    public class UserSession : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime TokenCreated { get; set; }

        public DateTime LastActivity { get; set; }

        public Guid Token { get; set; }
        
        public virtual User User { get; set; }
    }
}
