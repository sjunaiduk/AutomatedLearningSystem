using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningPaths;
using AutomatedLearningSystem.Domain.Users;
using MediatR;

namespace AutomatedLearningSystem.Application.LearningPaths.Queries.GetLearningPathsByUserId;

public class GetLearningPathsQueryHandler : IRequestHandler<GetLearningPathsByUserIdQuery, Result<List<LearningPath>>>
{

    private readonly ILearningPathRepository _learningPathRepository;
    private readonly IUserRepository _userRepository;

    public GetLearningPathsQueryHandler(ILearningPathRepository learningPathRepository,
    IUserRepository userRepository)
    {
        _learningPathRepository = learningPathRepository;
        _userRepository = userRepository;
    }

    public async Task<Result<List<LearningPath>>> Handle(GetLearningPathsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
        {
            return UserErrors.NotFound;
        }
        var learningPaths = await _learningPathRepository.GetAllByUserId(request.UserId);

        return learningPaths;
    }
}