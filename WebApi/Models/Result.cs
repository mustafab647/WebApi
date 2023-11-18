namespace WebApi.Models
{
    public class Result
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public Dictionary<string, string> Headers { get; set; }
    }
}
