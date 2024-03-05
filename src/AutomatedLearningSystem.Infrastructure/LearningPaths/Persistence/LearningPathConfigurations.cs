using AutomatedLearningSystem.Domain.LearningPaths;
using AutomatedLearningSystem.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomatedLearningSystem.Infrastructure.LearningPaths.Persistence;

public class LearningPathConfigurations : IEntityTypeConfiguration<LearningPath>

{
    public void Configure(EntityTypeBuilder<LearningPath> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired();

        builder.HasMany(lp => lp.UserLearningItems)
            .WithOne();
    }
}