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
     
        // Act

        var createUserResult = User.CreateUser(
            UserConstants.FirstName,
            UserConstants.LastName,
            UserConstants.Email, UserConstants.Role,
            UserConstants.Password);

        //Assert

        createUserResult.Should().NotBe(null);


    }



   
}