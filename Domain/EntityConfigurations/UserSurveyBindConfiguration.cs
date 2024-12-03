using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfigurations
{
    public class UserSurveyBindConfiguration : IEntityTypeConfiguration<UserSurveyBind>
    {
        public void Configure(EntityTypeBuilder<UserSurveyBind> builder)
        {
            builder.ToTable("user_survey_bind");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true);

            builder.Property(x => x.UserId).IsRequired(true);
            builder.HasOne(x => x.User)
                .WithMany(x => x.UserSurveyBinds)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(x => x.UserId);

            builder.Property(x => x.SurveyId).IsRequired(true);
            builder.HasOne(x => x.Survey)
                .WithMany(x => x.UserSurveyBinds)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(x => x.SurveyId);

            builder.Property(x => x.StartedAt).IsRequired(true);
            builder.Property(x => x.CompletedAt).IsRequired(false);
        }
    }
}
