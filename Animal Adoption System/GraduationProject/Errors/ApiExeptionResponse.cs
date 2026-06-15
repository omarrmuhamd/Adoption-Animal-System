namespace GraduationProject.Errors
{
    public class ApiExeptionResponse : ApiResponse
    {
        public ApiExeptionResponse(int? statusCode, string? Message, string? Details) : base(statusCode, Message)
        {
            details = Details;
        }
        public string? details { get; set; }

    }
}
