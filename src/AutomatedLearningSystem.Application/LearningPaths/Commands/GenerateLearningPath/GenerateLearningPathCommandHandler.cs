using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningItems.Services;
using AutomatedLearningSystem.Domain.LearningPaths;
using AutomatedLearningSystem.Domain.Questions;
using AutomatedLearningSystem.Domain.Users;
using MediatR;

namespace AutomatedLearningSystem.Application.LearningPaths.Commands.GenerateLearningPath;

public class GenerateLearningPathCommandHandler : IRequestHandler<GenerateLearningPathCommand,
Result>
{

    private readonly ILearningPathRepository _learningPathRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQuestionRepository _questionRepository;
    private readonly ILearningItemsRepository _learningItemsRepository;

    public GenerateLearningPathCommandHandler(ILearningPathRepository learningPathRepository, IUserRepository userRepository, IUnitOfWork unitOfWork, IQuestionRepository questionRepository, ILearningItemsRepository learningItemsRepository)
    {
        _learningPathRepository = learningPathRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _questionRepository = questionRepository;
        _learningItemsRepository = learningItemsRepository;
    }

    public async Task<Result> Handle(GenerateLearningPathCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (user is null)
        {
            return UserErrors.NotFound;
        }

        foreach (var answer in request.AnswersForQuestions)
        {
            var question = await _questionRepository.GetByIdAsync(answer.QuestionId);
            if (question is null)
            {
                return QuestionErrors.NotFound;
            }

            answer.Question = question;
        }

        var learningItems = await _learningItemsRepository.GetAllAsync(cancellationToken);

        var generatedLearningItems = LearningItemsGeneratorService.Generate(request.AnswersForQuestions, learningItems,
             request.Profile);

        var learningPath = LearningPath.CreateLearningPath();

        _learningPathRepository.Create(learningPath);

        foreach (var item in generatedLearningItems)
        {
            var addLearningItemResult = learningPath.AddLearningItem(item);
            if (addLearningItemResult.IsFailure)
            {
                return addLearningItemResult;
            }
        }

        var addLearningPathToUserResult = user.AddLearningPath(learningPath);

        if (addLearningPathToUserResult.IsFailure)
        {
            return addLearningPathToUserResult;
        }

        await _unitOfWork.CommitChangesAsync(cancellationToken);


        return Result.Success;
    }
}