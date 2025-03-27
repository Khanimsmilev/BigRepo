namespace Common.GlobalResponses
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }


        public Result()
        {
            Errors = new List<string>();
            IsSuccess = true;
        }


        public Result(List<string> errors) //message de elave edecem
        {
            Errors = errors ?? new List<string>();
            IsSuccess = false;
        }


        public static Result Success() => new Result();
        public static Result Failure(List<string> errors) => new Result(errors);
    }
}
