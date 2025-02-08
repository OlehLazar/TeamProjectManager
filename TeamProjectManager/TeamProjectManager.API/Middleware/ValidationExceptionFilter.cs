using Microsoft.AspNetCore.Mvc.Filters;
using FluentValidation;
using FluentValidation.Results;

namespace TeamProjectManager.API.Middleware;

public class ValidationExceptionFilter : IActionFilter
{
	public void OnActionExecuting(ActionExecutingContext context)
	{
		if (!context.ModelState.IsValid)
		{
			var errors = context.ModelState.Values
				.SelectMany(v => v.Errors)
				.Select(e => e.ErrorMessage)
				.ToList();

			throw new ValidationException(errors.Select(e => new ValidationFailure("", e)).ToList());
		}
	}

	public void OnActionExecuted(ActionExecutedContext context) { }
}
