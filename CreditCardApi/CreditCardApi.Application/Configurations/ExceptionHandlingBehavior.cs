
using CreditCardApi.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace CreditCardApi.Application.Configurations;


public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ExceptionHandlingBehavior(ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> logger, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (BaseExeption ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred while processing the request.");

            var errorResponse = new
            {
                status = ex.HttpStatusCode,
                timestamp = DateTime.UtcNow,
                error = ex.GetType().Name,
                message = ex.Message
            };

            var jsonResponse = JsonConvert.SerializeObject(errorResponse);

            var httpContext = _httpContextAccessor.HttpContext;

            httpContext!.Response.StatusCode = ex.HttpStatusCode;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsync(jsonResponse);

            return default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred while processing the request.");

            var errorResponse = new
            {
                status = HttpStatusCode.ServiceUnavailable,
                timestamp = DateTime.UtcNow,
                error = ex.GetType().Name,
                message = ex.Message
            };

            var jsonResponse = JsonConvert.SerializeObject(errorResponse);

            var httpContext = _httpContextAccessor.HttpContext;

            httpContext!.Response.StatusCode = (int) HttpStatusCode.ServiceUnavailable;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsync(jsonResponse);

            return default;
        }
    }

}