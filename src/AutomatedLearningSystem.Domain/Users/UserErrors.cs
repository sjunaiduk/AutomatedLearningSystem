using AutomatedLearningSystem.Domain.Common;

namespace AutomatedLearningSystem.Domain.Users;

public class UserErrors
{
    public static Error DuplicateEmail =>
        new("User.DuplicateEmail", "Email is not unique", ErrorType.Validation);

    public static Error AdminPasswordTooShort =>
        new("User.AdminPasswordTooShort", "Admin password is less than 8 characters",
            ErrorType.Validation);

    public static Error UserAlreadyExists =>
        new("User.Exists", "User already exists, cannot create the user", ErrorType.Conflict);

    public static Error NotFound =>
        new("User.NotFound", "User was not found", ErrorType.NotFound);

    public static Error UnAuthorized => new("User.UnAuthorized", "User is unauthorized to complete this action",
        ErrorType.UnAuthorized);
}