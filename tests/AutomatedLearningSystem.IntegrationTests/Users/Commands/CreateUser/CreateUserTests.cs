using AutomatedLearningSystem.Domain.Users;
using AutomatedLearningSystem.IntegrationTests.Infrastructure;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using TestCommon.Factories;

namespace AutomatedLearningSystem.FunctionalTests.Users.Commands.CreateUser;

public class CreateUserTests : BaseIntegrationTest
{
    public CreateUserTests(IntegrationTestWebApplicationFactory factory) : base(factory)
    {

    }

    [Fact]

    public async void Handler_WhenValidUser_ShouldCreateUser()
    {
        // Arrange
        var createUserCommand = UserCommandsFactory.CreateUserCommandFactory
            .Create();
        
        // Act
        var createUserResult = await Sender.Send(createUserCommand);
        var createdUser = await DbContext
            .Set<User>()
            .FirstOrDefaultAsync(x => x.Email == createUserCommand.Email);
        // Assert
        createUserResult.IsSuccess.Should().BeTrue();
        createdUser.Should().NotBeNull();

    }

}