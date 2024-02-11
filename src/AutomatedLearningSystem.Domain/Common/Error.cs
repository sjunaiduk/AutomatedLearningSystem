namespace AutomatedLearningSystem.Domain.Common;

public record Error(string Code, string Description, ErrorType ErrorType)
{
    public static Error NotFound(string code = "General.NotFound",
        string description = "A NotFound error has occured") =>
        new(code, description, ErrorType.NotFound);

    public static Error Conflict(string code = "General.Conflict",
        string description = "A Conflict error has occured") =>
        new(code, description, ErrorType.Conflict);

    public static Error Validation(string code = "General.Validation",
        string description = "A Validation error has occured") =>
        new(code, description, ErrorType.NotFound);
}