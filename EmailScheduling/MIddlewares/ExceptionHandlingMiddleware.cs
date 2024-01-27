using EmailScheduling.Exceptions;
using System.Text.Json;

namespace EmailScheduling.MIddlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            dynamic response = new System.Dynamic.ExpandoObject();
            response.StatusCode = StatusCodes.Status500InternalServerError;
            response.Message = "Internal Server Error.";

            if (exception is EntityNotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.Message = "Entity not found.";
            } else if (exception is ValidationException)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Message = "One or more validation errors occurred.";
                response.Errors = ((ValidationException) exception).errors;
            }

            context.Response.StatusCode = response.StatusCode;
            context.Response.ContentType = "application/json";

            string responseJson = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(responseJson);
        }
    }
}
