using BehinRahkar.Infrastructure.Shared.Helpers;
using Framework.Core.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Serilog;
using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BehinRahkar.Infrastructure.Shared.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly IHostingEnvironment _env;
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandlingMiddleware(
            IHostingEnvironment env,
            RequestDelegate next,
            ILogger logger)
        {
            _env = env;
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();
                await _next(context);
            }
            catch (ExceptionBase ex)
            {
                await HandleExceptionAsync(ex, context);
            }
            catch (Exception ex)
            {
                LogExceptionAsync(ex, context);
                await HandleExceptionAsync(ex, context);
            }
        }

        private async Task HandleExceptionAsync(Exception exception, HttpContext context)
        {
            HttpStatusCode code;
            Exception jsonException;

            switch (exception)
            {
                case BadRequestException badRequestException:
                    code = badRequestException.Code;
                    jsonException = new BadRequestException(
                        badRequestException.Message
                    );
                    break;
                case ForbiddenException forbiddenException:
                    code = forbiddenException.Code;
                    jsonException = new ForbiddenException(
                        forbiddenException.Message
                    );
                    break;
                case UnauthorizedException unauthorizedException:
                    code = unauthorizedException.Code;
                    jsonException = new UnauthorizedException(
                        unauthorizedException.Message
                    );
                    break;
                // this is the bad request thrown directly by the Kestrel web server
                case RequestEntityTooLargeException requestEntityTooLargeException:
                    code = requestEntityTooLargeException.Code;
                    jsonException = new RequestEntityTooLargeException(
                        requestEntityTooLargeException.Message
                    );
                    break;
                case NotFoundException notFoundException:
                    code = notFoundException.Code;
                    jsonException = new NotFoundException(
                        notFoundException.Message
                    );
                    break;
                case BadHttpRequestException badHttpRequestException:
                    code = (HttpStatusCode)typeof(BadHttpRequestException)
                        .GetProperty("StatusCode", BindingFlags.NonPublic | BindingFlags.Instance)
                        .GetValue(badHttpRequestException);

                    switch (code)
                    {
                        case HttpStatusCode.RequestEntityTooLarge:
                            jsonException = new RequestEntityTooLargeException(
                                badHttpRequestException.Message
                            );
                            break;
                        default:
                            jsonException = new BadRequestException(
                                badHttpRequestException.Message
                            );
                            break;
                    }

                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    if (_env.IsProduction())
                        jsonException = new InternalServerException(
                            exception.Message
                        );
                    else
                        jsonException = new InternalServerException(
                            exception.Message,
                            exception.StackTrace
                        );

                    break;
            }

            var result = JsonSerializer.Serialize(
                jsonException,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    IgnoreNullValues = true
                });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            await context.Response.WriteAsync(result);
        }

        private async Task LogExceptionAsync(Exception exception, HttpContext context)
        {
            var msg = new StringBuilder();
            msg.AppendLine();
            msg.AppendLine("An unhandled exception occurred.");

            if (context.Request.Path.HasValue)
                msg.AppendLine($"Request: {context.Request.Path.Value}");

            if (context.Request.QueryString.HasValue)
                msg.AppendLine($"QueryString: {context.Request.QueryString.Value}");

            if (context.Request.Method is "POST" or "PUT")
            {
                var body = await HttpHelper.GetRequestBodyAsync(context.Request);
                msg.AppendLine($"Body: {body}");
            }

            _logger.Error(exception, msg.ToString());
        }
    }
}
