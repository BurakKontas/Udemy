namespace Udemy.Common.Result;

public class Result<T> : Result
{
    public T Value { get; }

    protected Result(T value, bool isSuccess, string message, int code)
        : base(isSuccess, message, code)
    {
        Value = value;
    }

    public static Result<T> Success(T value, string message = "Operation completed successfully.", int code = 0)
    {
        return new Result<T>(value, true, message, code);
    }

    public static Result<T> Failure(string message = "Operation failed.", int code = -1)
    {
        return new Result<T>(default, false, message, code);
    }
}
