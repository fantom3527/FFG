using System.Net;
using System.Text.Json;

namespace FFG.Presentation.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        /// <summary>
        /// Метод для обработки исключений
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            context.Response.ContentType = "application/json";

            //TODO: зарядить сюда ошибки флюента.

            //switch (exception)
            //{
            //    case FluentValidation.ValidationException validationException:
            //        code = HttpStatusCode.BadRequest;
            //        result = JsonSerializer.Serialize(validationException.Errors);
            //        break;
            //    case NotFoundException:
            //        code = HttpStatusCode.NotFound;
            //        Log.Information("Not Found");
            //        break;
            //    case OperationCanceledException or TaskCanceledException:
            //        context.Response.StatusCode = (int)HttpStatusCode.NoContent;
            //        Log.Information("Task cancelled");
            //        return Task.CompletedTask;
            //}
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
                result = JsonSerializer.Serialize(new { errpr = exception.Message });

            return context.Response.WriteAsync(result);
        }
    }
}
