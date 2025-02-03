using System.Net;
using System.Text.Json;
using TeamProjectManager.BLL.Validation;

namespace TeamProjectManager.API.Middleware;

public class ErrorHandler(RequestDelegate next)
{
	private readonly RequestDelegate _next = next;

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (AppException ex)
		{
			await HandleExceptionAsync(context, ex.Message, HttpStatusCode.BadRequest);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, "An unexpected error occurred.", HttpStatusCode.InternalServerError, ex.Message);
		}
	}

	private Task HandleExceptionAsync(HttpContext context, string message, HttpStatusCode statusCode, string? errorDetails = null)
	{
		context.Response.ContentType = "application/json";
		context.Response.StatusCode = (int)statusCode;

		var response = new
		{
			message,
			error = errorDetails
		};

		return context.Response.WriteAsync(JsonSerializer.Serialize(response));
	}
}
