namespace TeamProjectManager.BLL.Models;

public class FilterModel
{
	public int Page { get; set; }

	public int PageSize { get; set; }

	public string? Name { get; set; }

	public string? Description { get; set; }

	public string? SortBy { get; set; }

	public bool IsDescending { get; set; }
}
