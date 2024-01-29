﻿using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;

namespace AutomatedLearningSystem.Application.Users.Commands.UpdateUser;

public record UpdateUserCommand(Guid Id,
    string? FirstName,
    string? LastName,
    string? Email,
    string? Password,
    Role? role
    ) : ICommand<Result> {}



