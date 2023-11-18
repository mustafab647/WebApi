namespace WebApi.Models
{
    public class ResultException : Exception
    {
        public Exception Exception { get; set; }
        public int ErrorCode { get; set; }
        public ResultException() { }
        public ResultException(string message) : base(message)
        {
        }
        public ResultException(int code, string message) : base(message)
        {
            this.ErrorCode = code;
        }
        public ResultException(Exception exception) { 
            this.Exception = exception;
        }
    }
}
