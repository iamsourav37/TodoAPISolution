namespace TodoAPI.Utility
{
    public class ApiResponse
    {
        public ApiResponse() { }

        public ApiResponse(int statusCode, string[] errors, object data)
        {
            StatusCode = statusCode;
            Errors = errors;
            Data = data;
        }


        public int StatusCode { get; set; }
        public string[]? Errors { get; set; }
        public object? Data { get; set; }
    }
}
