using System.Data.Entity.ModelConfiguration;

namespace BasicCrud.Data.Entities
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            HasKey(user => user.Id);

            Property(user => user.Name).HasMaxLength(50).IsRequired();
            Property(user => user.Email).IsRequired();
            Property(user => user.Surname).HasMaxLength(100).IsOptional();
            Property(user => user.Username).HasMaxLength(50).IsOptional();
            Property(user => user.Age).IsOptional();
            Property(user => user.Hash).IsRequired();
        }
    }
}
