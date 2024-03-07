using FluentValidation;

namespace AutomatedLearningSystem.Application.LearningPaths.Commands.GenerateLearningPath;

public class GenerateLearningPathCommandValidator : AbstractValidator<GenerateLearningPathCommand>
{
    public GenerateLearningPathCommandValidator()
    {
        RuleFor(x => x.LearningPathName)
            .NotEmpty();
    }

}