using BasicCrud.Data.Entities;
using System.Data.Entity;

namespace BasicCrud.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DataContext")
        {
            Database.SetInitializer<DataContext>(null);
        }

        #region entiteiten
        public IDbSet<User> Users { get; set; }
        public IDbSet<UserSession> UserSessions { get; set; }
        #endregion

        public IDbSet<T> GetDbSet<T>() where T : class => Set<T>();
        
        public void RemoveContext() => Dispose();
        
        /// <summary>
        /// Mapping of all entities.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new UserSessionMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
