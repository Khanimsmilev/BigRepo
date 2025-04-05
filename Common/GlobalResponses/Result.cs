namespace Common.GlobalResponses
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; }


        public Result()
        {
            Errors = new List<string>();
            IsSuccess = true;
            Message = string.Empty;
        }


        public Result(List<string> errors, string message = "")
        {
            Errors = errors ?? new List<string>();
            IsSuccess = false;
            Message = message;
        }


        public static Result Success(string message = "Operation successful") => new Result { Message = message };

        public static Result Failure(List<string> errors, string message = "operation failed!!") => new Result(errors, message);

        public static Result Failure(string message)
        { 
            return new Result
            {
                IsSuccess = false,
                Errors = new List<string> { message }
            };
        }
    }
}
