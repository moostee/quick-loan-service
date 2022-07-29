using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using QLS.Shared;
using QLS.Shared.Exceptions;
using QLS.Application.Exceptions;

namespace QLS.Api
{
    internal class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;
        private readonly IWebHostEnvironment _env;
        public ErrorHandlerMiddleware(RequestDelegate next,
            ILogger<ErrorHandlerMiddleware> logger,
            IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (QLSException error)
            {
                if (error.ValidationErrors != null) error.StatusMessage = error.FormattedError;

                //_logger.LogError(error, error.Message);
                var response = context.Response;
                response.ContentType = "application/json";

                Result<string> serviceResponse = new()
                {
                    StatusCode = error.StatusCode,
                    StatusMessage = error.StatusMessage,

                };

                response.StatusCode = (int)HttpStatusCode.BadRequest;
                var result = JsonSerializer.Serialize(serviceResponse);

                await response.WriteAsync(result);

            }
            catch (DuplicateEntryException error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                Result<string> serviceResponse = new()
                {
                    StatusCode = QLS.Shared.StatusCodes.INVALID_REQUEST,
                    StatusMessage = error.Message,

                };

                response.StatusCode = (int)HttpStatusCode.BadRequest;
                var result = JsonSerializer.Serialize(serviceResponse);

                await response.WriteAsync(result);
            }
            catch (NotFoundException error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                Result<string> serviceResponse = new()
                {
                    StatusCode = QLS.Shared.StatusCodes.INVALID_REQUEST,
                    StatusMessage = error.Message,

                };

                response.StatusCode = (int)HttpStatusCode.NotFound;
                var result = JsonSerializer.Serialize(serviceResponse);

                await response.WriteAsync(result);
            }
            catch (Exception error)
            {
                //_logger.LogError(error, error.Message);
                var response = context.Response;
                response.ContentType = "application/json";

                Result<string> serviceResponse = new()
                {
                    StatusCode = QLS.Shared.StatusCodes.INVALID_REQUEST,
                };


                serviceResponse.StatusMessage = error.Message;


                // unhandled error
                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var result = JsonSerializer.Serialize(serviceResponse);

                await response.WriteAsync(result);
            }
        }
    }
}
