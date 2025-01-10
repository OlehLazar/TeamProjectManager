using System.Linq.Expressions;
using TeamProjectManager.BLL.Models;

namespace TeamProjectManager.BLL.Utilities;

public static class FilterBuilder
{
	public static IQueryable<T> ApplyFilters<T>(IQueryable<T> query,FilterModel filter,
	params Expression<Func<T, bool>>[] filterExpressions)
	{
		foreach (var filterExpression in filterExpressions)
		{
			query = query.Where(filterExpression);
		}

		if (!string.IsNullOrWhiteSpace(filter.SortBy))
		{
			query = ApplySorting(query, filter.SortBy, filter.IsDescending);
		}

		if (filter.Page > 0 && filter.PageSize > 0)
		{
			query = query.Skip((filter.Page - 1) * filter.PageSize)
						 .Take(filter.PageSize);
		}

		return query;
	}

	private static IQueryable<T> ApplySorting<T>(IQueryable<T> query, string sortBy, bool isDescending)
	{
		var param = Expression.Parameter(typeof(T), "entity");
		var property = Expression.Property(param, sortBy);
		var keySelector = Expression.Lambda(property, param);

		var methodName = isDescending ? "OrderByDescending" : "OrderBy";
		var method = typeof(Queryable).GetMethods()
			.First(m => m.Name == methodName && m.GetParameters().Length == 2);

		var genericMethod = method.MakeGenericMethod(typeof(T), property.Type);

		return (IQueryable<T>)genericMethod.Invoke(null, new object[] { query, keySelector });
	}
}
