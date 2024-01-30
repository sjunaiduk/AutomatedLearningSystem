﻿using AutomatedLearningSystem.Domain.Answers;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;

namespace AutomatedLearningSystem.Application.LearningPaths.Commands;

public record GenerateLearningPathCommand(Guid UserId,
    List<AnswerForQuestion> AnswersForQuestions,
    UserProficiencyProfile Profile) : ICommand<Result> {}