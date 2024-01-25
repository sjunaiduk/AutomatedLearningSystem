using AutomatedLearningSystem.Domain.Answers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomatedLearningSystem.Infrastructure.Answers.Persistence;

public class AnswerForQuestionConfigurations : IEntityTypeConfiguration<AnswerForQuestion>
{
    public void Configure(EntityTypeBuilder<AnswerForQuestion> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Question)
            .WithMany()
            .IsRequired();

        builder.Property(x => x.Response)
            .IsRequired();

        builder.Property(x => x.AddedDateTime)
            .IsRequired();

    }
}