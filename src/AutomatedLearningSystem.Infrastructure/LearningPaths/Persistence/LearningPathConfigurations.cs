﻿using AutomatedLearningSystem.Domain.LearningItems;
using AutomatedLearningSystem.Domain.LearningPaths;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomatedLearningSystem.Infrastructure.LearningPaths.Persistence;

public class LearningPathConfigurations : IEntityTypeConfiguration<LearningPath>

{
    public void Configure(EntityTypeBuilder<LearningPath> builder)
    {

        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.LearningItems)
            .WithMany();



    }
}