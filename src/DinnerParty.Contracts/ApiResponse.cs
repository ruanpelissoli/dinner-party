namespace DinnerParty.Contracts;

public record ApiResponse<T>
{
    public bool Success { get; init; }
    public T? Data { get; init; }
    public string? ErrorMessage { get; init; }

    private ApiResponse(T data)
    {
        Success = true;
        Data = data;
    }

    private ApiResponse(string errorMessage)
    {
        Success = false;
        ErrorMessage = errorMessage;
    }

    public static ApiResponse<T> Ok(T data) => new(data);

    public static ApiResponse<T> Error(string errorMessage) => new(errorMessage);
}
