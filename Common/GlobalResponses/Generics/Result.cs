namespace Common.GlobalResponses.Generics
{
    public class Result<T> : Result
    {
        public T Data { get; set; }

        public Result() { }

        public Result(T data)
        {
            Data = data;
            IsSuccess = true;
            Errors = new List<string>();
        }

        public Result(List<string> errors) : base(errors) { }

        public static Result<T> Success(T data) => new Result<T> { Data = data };


        public static Result<T> Failure(string error) => new Result<T> { IsSuccess = false, Errors = new List<string> { error } };
    }
}
