using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfigurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("question");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true);

            builder.Property(x => x.SurveyId).IsRequired(true);
            builder.HasOne(x => x.Survey)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.SurveyId);

            builder.HasMany(x => x.Answers)
                .WithOne(x => x.Question)
                .HasForeignKey(x => x.QuestionId);

            builder.Property(x => x.Title).IsRequired(true);
            builder.Property(x => x.Type).IsRequired(true);

            builder.Property(x => x.CreatedAt).IsRequired(true);
            builder.Property(x => x.UpdatedAt).IsRequired(true);
            builder.Property(x => x.IsDeleted).IsRequired(true);
        }
    }
}
