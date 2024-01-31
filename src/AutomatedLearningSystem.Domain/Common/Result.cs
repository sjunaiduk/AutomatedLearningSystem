namespace AutomatedLearningSystem.Domain.Common;

public class Result
{

    public bool IsSuccess { get; init; }

    public bool IsFailure => !IsSuccess;

    protected List<Error> Errors { get; } = null!;
    public Error? FirstError => Errors.FirstOrDefault();

    public static Result Success => new Result(true);


    protected Result(bool isSuccess, List<Error> errors)
    {
        if (isSuccess && errors.Any())
        {
            throw new InvalidOperationException("Can't create successful result with errors");

        }
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public TResponse MatchAll<TResponse>(Func<TResponse> onValue,
        Func<List<Error>, TResponse> onErrors)
    {
        if (IsSuccess)
        {
            return onValue();
        }

        return onErrors(Errors);
    }

    protected Result(bool isSuccess)
    {
        this.IsSuccess = isSuccess;

    }


    public static implicit operator Result(Error error) => new Result(false, [error]);
    public static implicit operator Result(List<Error> errors) => new Result(false, errors);


}


public class Result<TValue> : Result
{

    private TValue? _value { get; init; }
    protected Result(bool isSuccess, List<Error> errors, TValue value) : base(isSuccess, errors)
    {
        _value = value;
    }



    private Result(bool isSuccess, TValue value) : base(isSuccess)
    {
        _value = value;
    }

    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException(
            "Cannot access the value from a failure result");


    public TResponse MatchAll<TResponse>(Func<TValue, TResponse> onValue,
        Func<List<Error>, TResponse> onErrors)
    {
        if (IsSuccess)
        {
            return onValue(Value);
        }

        return onErrors(Errors);
    }


    public static implicit operator Result<TValue>(TValue value) =>
        new Result<TValue>(true, value);

    public static implicit operator Result<TValue>(Error error) =>
        new Result<TValue>(false, [error], default!);


    public static implicit operator Result<TValue>(List<Error> errors) =>
        new Result<TValue>(false, errors, default!);

}
