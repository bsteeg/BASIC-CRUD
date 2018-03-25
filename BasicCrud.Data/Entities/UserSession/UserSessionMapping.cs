using System.Data.Entity.ModelConfiguration;

namespace BasicCrud.Data.Entities
{
    public class UserSessionMapping : EntityTypeConfiguration<UserSession>
    {
        public UserSessionMapping()
        {
            HasKey(UserSession => UserSession.Id);

            Property(UserSession => UserSession.TokenCreated).IsRequired();
            Property(UserSession => UserSession.LastActivity).IsRequired();
            Property(UserSession => UserSession.Token).IsRequired();

            HasRequired(UserSession => UserSession.User)
                .WithMany()
                .HasForeignKey(UserSession => UserSession.UserId);
        }
    }
}
