namespace Common.GlobalResponses.Generics
{
    public class Result<T> : Result
    {
        public T? Data { get; set; }

        public Result() { }

        public Result(T data, string message = "Operation successful")
        {
            Data = data;
            IsSuccess = true;
            Errors = new List<string>();
            Message = message;
        }

        public Result(List<string> errors, string message = "operation failed!!!!!!") : base(errors, message) { }

        public static Result<T> Success(T data, string message = "Operation successful") =>
            new Result<T> { Data = data, IsSuccess = true, Message = message };

        public static Result<T> Failure(string error, string message = "operation failed!!!") =>
            new Result<T> { Data = default!, IsSuccess = false, Errors = new List<string> { error }, Message = message };
    }
}
