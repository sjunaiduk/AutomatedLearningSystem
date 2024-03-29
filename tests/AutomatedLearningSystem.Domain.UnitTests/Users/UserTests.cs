﻿using AutomatedLearningSystem.Domain.Users;
using FluentAssertions;
using TestCommon.Constants;

namespace AutomatedLearningSystem.Domain.UnitTests.Users;

public class UserTests
{
    [Fact]
    public void User_GivenValidData_ShouldCreateUser()
    {

        // Act

        var createUserResult = User.Create(
            UserConstants.FirstName,
            UserConstants.LastName,
            UserConstants.Email, UserConstants.Role,
            UserConstants.Password);

        //Assert

        createUserResult.Should().NotBe(null);


    }




}