using AutomatedLearningSystem.Domain.Answers;
using AutomatedLearningSystem.Domain.Users;
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
            .HasForeignKey(x => x.QuestionId)
            .IsRequired();

        builder.Property(x => x.Answer)
            .IsRequired();

        builder.Property(x => x.AddedDateTime)
            .IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .IsRequired();
        ;

    }
}