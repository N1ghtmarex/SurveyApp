using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfigurations
{
    public class ChoiceConfiguration : IEntityTypeConfiguration<Choice>
    {
        public void Configure(EntityTypeBuilder<Choice> builder)
        {
            builder.ToTable("choice");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true);

            builder.Property(x => x.UserId).IsRequired(true);
            builder.HasOne(x => x.User)
                .WithMany(x => x.Choices)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.AnswerId).IsRequired(true);
            builder.HasOne(x => x.Answer)
                .WithMany(x => x.Choices)
                .HasForeignKey(x => x.AnswerId);
        }
    }
}
