using System.Net;
using System.Text.Json;
using Application.Responses;
using ApplicationException = Application.Exceptions.ApplicationException;

namespace Onion.Architecture.Api.Middlewares;

public class ApiExceptionMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ApplicationException ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest);
        }
        catch (UnauthorizedAccessException ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.Unauthorized);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode statusCode)
    {
        var message = (int)statusCode >= 500 ? $"Status code: {statusCode}" : ex.Message;
        var result = new BaseResponseDto(false, statusCode, message);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(JsonSerializer.Serialize(result));
    }
}