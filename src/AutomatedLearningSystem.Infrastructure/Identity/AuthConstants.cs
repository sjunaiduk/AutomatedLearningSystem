namespace AutomatedLearningSystem.Infrastructure.Identity;

public static class AuthConstants
{

    public const string DefaultCookieScheme = "cookie";
    public static class Policies
    {
        public const string Privileged = "privileged";

        public const string Protected = "protected";
    }


    public static class Roles
    {
        public const string Admin = "admin";
        public const string Student = "student";
    }
    
 
}