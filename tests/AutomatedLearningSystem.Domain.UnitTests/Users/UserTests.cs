using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;
using FluentAssertions;
using NSubstitute;
using TestCommon.Constants;

namespace AutomatedLearningSystem.Domain.UnitTests.Users;

public class UserTests
{
    [Fact]
    public async void User_GivenValidData_ShouldCreateUser()
    {
        // Arrange
        var _emailService = Substitute.For<IEmailService>();
        _emailService.IsEmailUniqueAsync(Arg.Any<string>())
            .Returns(true);
        // Act

        var createUserResult = await User.CreateUser(_emailService,
            UserConstants.FirstName,
            UserConstants.LastName,
            UserConstants.Email, UserConstants.Role,
            UserConstants.Password);

        //Assert

        createUserResult.IsSuccess.Should().Be(true);


    }



    [Fact]
    public async void User_GivenDuplicateEmail_ShouldReturnError()
    {
        // Arrange
        var _emailService = Substitute.For<IEmailService>();
        _emailService.IsEmailUniqueAsync(Arg.Any<string>())
            .Returns(false);
        // Act

        var createUserResult = await User.CreateUser(_emailService,
            UserConstants.FirstName,
            UserConstants.LastName,
            UserConstants.Email, UserConstants.Role,
            UserConstants.Password);

        //Assert

        createUserResult.IsSuccess.Should().Be(false);
        
    }
}