namespace GraduationProject.Errors
{
    public class ApiResponse
    {
        public int? StatusCode { get; set; }
        public string? Message { get; set; }
        public ApiResponse(int? statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }
        private string? GetDefaultMessageForStatusCode(int? statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request",

                401 => "Unauthorized",

                403 => "Forbidden",

                404 => "Not Found",

                405 => "Method Not Allowed",

                408 => "Request Timeout",

                409 => "Conflict",

                422 => "Validation Error",

                500 => "Internal Server Error",

                502 => "Bad Gateway",

                503 => "Service Unavailable",

                504 => "Gateway Timeout",
                _ => null
            };
        }
    }
}
