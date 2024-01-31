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
    }
}