using AutomatedLearningSystem.Domain.Users;

namespace AutomatedLearningSystem.Api.Endpoints;

public static class Routes
{
    public const string Base = "/api";

    public static class UserRoutes
    {
        public const string UserBase = $"{Base}/users";
    }
}