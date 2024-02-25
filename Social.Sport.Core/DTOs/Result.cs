namespace Social.Sport.API.Helper
{
    public abstract class Result
    {
        public bool Success { get; protected set; }
    }

    public abstract class Result<T> : Result
    {
        public T Data { get; set; }

        protected Result(T data)
        {
            Data = data;
        }
    }

    public class SuccessResult : Result
    {
        public SuccessResult()
        {
            Success = true;
        }
    }

    public class SuccessResult<T> : Result<T>
    {
        public SuccessResult(T data) : base(data)
        {
            Success = true;
        }
    }

    public class ErrorResult : Result, IErrorResult
    {
        public ErrorResult(string message) : this(message, Array.Empty<Error>())
        {
        }

        public ErrorResult(string message, IReadOnlyCollection<Error> errors)
        {
            Message = message;
            Success = false;
            Errors = errors ?? Array.Empty<Error>();
        }

        public string Message { get; }
        public IReadOnlyCollection<Error> Errors { get; }
    }

    public class ErrorResult<T> : Result<T>, IErrorResult
    {
        public ErrorResult(string message) : this(message, Array.Empty<Error>())
        {
        }

        public ErrorResult(string message, IReadOnlyCollection<Error> errors) : base(default)
        {
            Message = message;
            Success = false;
            Errors = errors ?? Array.Empty<Error>();
        }

        public string Message { get; set; }
        public IReadOnlyCollection<Error> Errors { get; }
    }

    public class Error
    {
        public Error(string details) : this(null, details)
        {

        }

        public Error(string code, string details)
        {
            Code = code;
            Details = details;
        }

        public string Code { get; }
        public string Details { get; }
    }

    public interface IErrorResult
    {
        bool Success { get; }
        string Message { get; }
        IReadOnlyCollection<Error> Errors { get; }
    }
}