using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true);

            builder.Property(x => x.Username).IsRequired(true);
            builder.HasIndex(x => x.Username).IsUnique(true);

            builder.Property(x => x.PasswordHash).IsRequired(true);
            builder.Property(x => x.PasswordSalt).IsRequired(true);
        }
    }
}
