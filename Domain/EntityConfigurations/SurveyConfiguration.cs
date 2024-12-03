using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfigurations
{
    public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.ToTable("survey");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true);

            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Description).IsRequired(false);

            builder.Property(x => x.CreatedAt).IsRequired(true);
            builder.Property(x => x.UpdatedAt).IsRequired(true);
            builder.Property(x => x.IsDeleted).IsRequired(true);
        }
    }
}
