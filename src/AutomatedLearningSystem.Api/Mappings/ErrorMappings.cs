﻿using AutomatedLearningSystem.Domain.Common;

namespace AutomatedLearningSystem.Api.Mappings;

public static class ErrorMappings
{
    public static IResult ToProblemDetails(this List<Error> errors)
    {
        if (!errors.Any())
        {
            throw new ArgumentException("A failure result had no error objects");
        }

        if (errors.Count == 1)
        {
            var error = errors[0];
            return error.ToProblemDetails();
        }

        return Results.Problem(
            statusCode: StatusCodes.Status400BadRequest,
            extensions: new Dictionary<string, object?>()
            {
                {"errors", errors}
            });

    }

    public static IResult ToProblemDetails(this Error error)
    {
        return Results.Problem(
            statusCode: error.GetStatusCode(),
            title: error.Code,
            detail: error.Description
        );
    }

    public static int GetStatusCode(this Error error)
    {
        return error.ErrorType switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError

        };
    }
}