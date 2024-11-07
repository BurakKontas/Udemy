namespace Udemy.Common.Result;

public static class CommonResults
{
    public static Result Unauthorized()
    {
        return Result.Failure("Unauthorized access.", 401);
    }

    public static Result ValidationError(string message = "Validation error occurred.")
    {
        return Result.Failure(message, 400);
    }

    public static Result<T> NotFound<T>(string message = "Requested item not found.")
    {
        return Result<T>.Failure(message, 404);
    }
}