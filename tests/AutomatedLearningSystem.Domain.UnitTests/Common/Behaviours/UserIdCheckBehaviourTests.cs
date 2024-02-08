using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Application.Common.Behaviours;
using AutomatedLearningSystem.Application.LearningPaths.Commands.GenerateLearningPath;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;
using FluentAssertions;
using NSubstitute;
using TestCommon.Factories;

namespace AutomatedLearningSystem.Domain.UnitTests.Common.Behaviours;

public class UserIdCheckBehaviourTests
{

    private readonly IAuthenticatedUserProvider _authenticatedUserProvider = Substitute.For<IAuthenticatedUserProvider>();
    
    
    [Fact]

    public async void Handler_ShouldReturnUnauthorizedResponse_WhenAuthenticatedUserUsesDifferentUserId()
    {
        // Arrange
        _authenticatedUserProvider.GetAuthenticatedUser().Returns(new AuthenticatedUser()
        {
            Id = Guid.NewGuid(),
            Role = "student"
        });

        var command = GenerateLearningPathCommandFactory.Create();
        var userIdCheckerBehaviour = new UserIdCheckBehaviour<GenerateLearningPathCommand, Result>(
            _authenticatedUserProvider);

        // Act
        var result = await userIdCheckerBehaviour.Handle(command,default, default);
        
        // Assert
        result.IsFailure.Should().BeTrue();
        result.FirstError.Should().Be(UserErrors.UnAuthorized);
    }

}