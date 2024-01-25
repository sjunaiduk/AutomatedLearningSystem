using AutomatedLearningSystem.Domain.LearningItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomatedLearningSystem.Infrastructure.LearningItems.Persistence;

public class LearningItemConfigurations : IEntityTypeConfiguration<LearningItem>
{
    public void Configure(EntityTypeBuilder<LearningItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Category).IsRequired();
        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(x => x.Description)
            .HasMaxLength(300);

        builder.Ignore(x => x.Score);

    }
}