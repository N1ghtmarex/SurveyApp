using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfigurations
{
    public class UserTestBindConfiguration : IEntityTypeConfiguration<UserTestBind>
    {
        public void Configure(EntityTypeBuilder<UserTestBind> builder)
        {
            builder.ToTable("user_test_bind");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true);

            builder.Property(x => x.UserId).IsRequired(true);
            builder.HasOne(x => x.User)
                .WithMany(x => x.UserTestBinds)
                .HasForeignKey(x => x.UserId);

            builder.Property(x => x.TestId).IsRequired(true);
            builder.HasOne(x => x.Test)
                .WithMany(x => x.UserTestBinds)
                .HasForeignKey(x => x.TestId);

            builder.Property(x => x.Answers).IsRequired(true);

            builder.Property(x => x.CompletedAt).IsRequired(true);
        }
    }
}
