using AutomatedLearningSystem.Api.Endpoints;
using AutomatedLearningSystem.Contracts.Users;
using AutomatedLearningSystem.FunctionalTests.Infrastructure;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using AutomatedLearningSystem.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace AutomatedLearningSystem.FunctionalTests.Users;

public class CreateUserTests(FunctionalTestWebApplicationFactory factory) : BaseFunctionalTest(factory)
{
    [Fact]
    public async void Create_WhenValidUser_ShouldCreateUser()
    {
        // Arrange

        var createUserRequest = new CreateUserRequest(
            "First Name",
            "Last Name",
            "test@gmail.com",
            "password",
            RoleDto.Student,
            null);

        // Act
        
        var result = await HttpClient.PostAsJsonAsync(Routes.User.Create,
            createUserRequest);

        // Assert


        result.StatusCode.Should().Be(HttpStatusCode.Created);

    }

    [Fact]
    public async void Create_WhenValidToken_ShouldCreateUserAsAdmin()
    {
        // Arrange

        var createUserRequest = new CreateUserRequest(
            "Bobo",
            "Last Name",
            "test123@gmail.com",
            "password",
            RoleDto.Student,
            "123");

        // Act

        var result = await HttpClient.PostAsJsonAsync(Routes.Register,
            createUserRequest);

        // Assert

        var registeredUser = await DbContext.Set<User>().FirstOrDefaultAsync(x => x.FirstName == "Bobo");
        registeredUser?.Role.Should().Be(Role.Admin);
        result.StatusCode.Should().Be(HttpStatusCode.Created);

    }
}