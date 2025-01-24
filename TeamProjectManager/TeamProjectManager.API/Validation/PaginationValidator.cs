using FluentValidation;
using TeamProjectManager.API.DTOs.Pagination;

namespace TeamProjectManager.API.Validation;

public class PaginationValidator : AbstractValidator<PaginationDto>
{
    public PaginationValidator()
    {
		RuleFor(x => x.Page)
			.GreaterThan(0).WithMessage("Page must be greater than 0");

		RuleFor(x => x.PageSize)
			.GreaterThan(0).WithMessage("Page size must be greater than 0");
	}
}
