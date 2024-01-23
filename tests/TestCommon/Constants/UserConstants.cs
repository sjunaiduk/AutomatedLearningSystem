using AutomatedLearningSystem.Domain.Users;

namespace TestCommon.Constants;


    public static class UserConstants
    {
        public static Guid Id = Guid.NewGuid();
        public const string FirstName = "John";
        public const string LastName = "Doe";
        public const string Email = "myemail@gmail.com";
        public const string Password = "password123";
        public static Role Role = Role.Admin;
    }


