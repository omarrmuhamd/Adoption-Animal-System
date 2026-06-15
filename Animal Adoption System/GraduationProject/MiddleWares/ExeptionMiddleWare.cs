using GraduationProject.Errors;
using System.Net;
using System.Text.Json;

namespace GraduationProject.MiddleWares
{
    public class ExeptionMiddleWare
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExeptionMiddleWare> logger;
        private readonly IHostEnvironment environment;

        public ExeptionMiddleWare(RequestDelegate Next, ILogger<ExeptionMiddleWare> Logger, IHostEnvironment Environment)
        {
            next = Next;
            logger = Logger;
            environment = Environment;
        }

        //InvokeAsync
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                //Production => Log Error DataBase
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                if (environment.IsDevelopment())
                {
                    var Response = new ApiExeptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString());
                }
                else
                {
                    var Response = new ApiExeptionResponse((int)HttpStatusCode.InternalServerError, null, null);
                    var jsonResponse = JsonSerializer.Serialize(Response);
                    await context.Response.WriteAsync(jsonResponse);


                }

            }

        }

    }
}
