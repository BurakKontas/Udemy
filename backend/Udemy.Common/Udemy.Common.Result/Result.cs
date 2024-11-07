namespace Udemy.Common.Result;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess; 
    public string Message { get; }
    public int Code { get; }

    protected Result(bool isSuccess, string message, int code)
    {
        IsSuccess = isSuccess;
        Message = message;
        Code = code;
    }

    public static Result Success(string message = "Operation completed successfully.", int code = 0)
    {
        return new Result(true, message, code);
    }

    public static Result Failure(string message = "Operation failed.", int code = -1)
    {
        return new Result(false, message, code);
    }
}