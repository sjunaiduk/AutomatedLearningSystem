using System.Diagnostics;
using AutomatedLearningSystem.Domain.LearningPaths;
using AutomatedLearningSystem.Domain.UserLearningItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomatedLearningSystem.Infrastructure.UserLearningItems.Persistence;

public class UserLearningItemConfigurations : IEntityTypeConfiguration<UserLearningItem>
{
    public void Configure(EntityTypeBuilder<UserLearningItem> builder)
    {

        builder.Property(x => x.Id)
            .ValueGeneratedNever();
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.LearningItem);

    


    }
}
