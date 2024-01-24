using AutomatedLearningSystem.Application.Users.Commands.CreateUser;
using AutomatedLearningSystem.Domain.Users;
using TestCommon.Constants;

namespace TestCommon.Factories;

public static class UserCommandsFactory
{
    public static class CreateUserCommandFactory
    {
        public static CreateUserCommand Create(
            string firstName = UserConstants.FirstName,
            string lastName = UserConstants.LastName,
            string email = UserConstants.Email,
            string password = UserConstants.Password,
            Role role = Role.Student)
        {
            return new CreateUserCommand(firstName,
                lastName,
                email,
                password,
                role);
        }
    }
}