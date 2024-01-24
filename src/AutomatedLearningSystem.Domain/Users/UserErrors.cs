using AutomatedLearningSystem.Domain.Common;

namespace AutomatedLearningSystem.Domain.Users;

public class UserErrors
{
    public static Error DuplicateEmail =>
        new Error("User.DuplicateEmail", "Email is not unique", ErrorType.Validation);

    public static Error AdminPasswordTooShort =>
        new Error("User.AdminPasswordTooShort", "Admin password is less than 8 characters",
            ErrorType.Validation);

    public static Error UserAlreadyExists =>
        new Error("User.Exists", "User already exists, cannot create the user", ErrorType.Conflict);
    public static Error NotFound =>
        Error.NotFound();
}