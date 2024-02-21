using AutomatedLearningSystem.Domain.LearningPaths;
using AutomatedLearningSystem.Domain.UserLearningItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomatedLearningSystem.Infrastructure.UserLearningItems.Persistence;

public class UserLearningItemConfigurations : IEntityTypeConfiguration<UserLearningItem>
{
    public void Configure(EntityTypeBuilder<UserLearningItem> builder)
    {

        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.LearningItem);

        builder.HasOne<LearningPath>()
            .WithMany(lp => lp.UserLearningItems);

    }
}
