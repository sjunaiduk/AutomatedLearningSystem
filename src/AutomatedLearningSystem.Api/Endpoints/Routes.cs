﻿using AutomatedLearningSystem.Domain.Users;

namespace AutomatedLearningSystem.Api.Endpoints;

public static class Routes
{
    public const string Base = "/api";

    public static class UserRoutes
    {

        private const string UserBase = $"{Base}/users";

        public const string Get = $"{UserBase}/{{id:guid}}";

        public const string Create = $"{UserBase}";

        public const string Delete = $"{UserBase}/{{id:guid}}";
    }
}