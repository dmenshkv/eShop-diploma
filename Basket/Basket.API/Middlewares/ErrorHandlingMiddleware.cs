using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Basket.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private const string ContentType = "application/problem+json";

        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int httpStatusCode;
            ProblemDetails problemDetails;

            switch (exception)
            {
                case ArgumentNullException:
                    httpStatusCode = StatusCodes.Status400BadRequest;
                    problemDetails = GetArgumentNullProblemDetails(exception.Message, context.Request.Path.Value!);
                    break;
                default:
                    httpStatusCode = StatusCodes.Status500InternalServerError;
                    problemDetails = GetDefaultProblemDetails(exception.Message, context.Request.Path.Value!);
                    break;
            }

            context.Response.StatusCode = httpStatusCode;

            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            await context.Response.WriteAsJsonAsync(problemDetails, serializerOptions, ContentType);
        }

        private ProblemDetails GetArgumentNullProblemDetails(string message, string instance)
        {
            return new ProblemDetails
            {
                Title = nameof(HttpStatusCode.BadRequest),
                Detail = message,
                Instance = instance
            };
        }

        private ProblemDetails GetDefaultProblemDetails(string message, string instance)
        {
            return new ProblemDetails
            {
                Title = nameof(HttpStatusCode.InternalServerError),
                Detail = message,
                Instance = instance
            };
        }
    }
}
