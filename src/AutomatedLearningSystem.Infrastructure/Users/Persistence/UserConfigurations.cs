﻿using AutomatedLearningSystem.Domain.LearningPaths;
using AutomatedLearningSystem.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomatedLearningSystem.Infrastructure.Users.Persistence;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(x => x.LearningPaths)
            .WithOne()
            .OnDelete(DeleteBehavior.ClientSetNull)
            .IsRequired(false);

        builder.Property(u => u.Email)
            .IsRequired();

        builder.HasKey(u => u.Id);

        builder.Property("_password")
            .HasColumnName("password")
            .IsRequired();
    }
}