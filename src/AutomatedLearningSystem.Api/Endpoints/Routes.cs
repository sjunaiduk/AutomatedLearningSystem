using AutomatedLearningSystem.Api.Endpoints.Auth;

namespace AutomatedLearningSystem.Api.Endpoints;

public static class Routes
{
    public const string Base = "/api";

    public static class User
    {

        private const string UserBase = $"{Base}/users";

        public const string Get = $"{UserBase}/{{id:guid}}";

        public const string GetAll = $"{UserBase}";

        public const string Create = $"{UserBase}";

        public const string Delete = $"{UserBase}/{{id:guid}}";

        public const string Update = $"{UserBase}/{{id:guid}}";
        public static class LearningPaths
        {

            private const string LearningPathBase = $"{UserBase}/{{userId:guid}}/learning-paths";

            public const string GetAll = $"{LearningPathBase}";
            public const string Create = $"{LearningPathBase}";
        }
    }

    public static class Questions
    {
        private const string QuestionsBase = $"{Base}/questions";
        public const string GetAll = $"{QuestionsBase}";
    }

    public static class LearningPaths
    {
        private const string LearningPathsBase = $"{Base}/learning-paths";
        public const string GetAll = $"{Base}";


    }

    public static class UserLearningItems
    {
        private const string UserLearningItemsBase = $"{Base}/user-learning-items";
        public const string Update = $"{UserLearningItemsBase}/{{userLearningItemId:guid}}";
    }

    public const string Login = $"/auth/login";

    public const string Logout = $"/auth/logout";
    public const string Register = "/auth/register";

    public static class LearningItems
    {
        public const string GetAll = $"{Base}/learning-items";
    }
}