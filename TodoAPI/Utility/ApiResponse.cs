namespace TodoAPI.Utility
{
    public class ApiResponse<T> where T : class
    {
        public ApiResponse() { }

        public ApiResponse(int statusCode, string[] errors, T data)
        {
            StatusCode = statusCode;
            Errors = errors;
            Data = data;
        }


        public int StatusCode { get; set; }
        public string[]? Errors { get; set; }
        public T? Data { get; set; }
    }
}
