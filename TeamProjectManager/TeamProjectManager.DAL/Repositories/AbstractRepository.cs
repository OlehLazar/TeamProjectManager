using TeamProjectManager.DAL.Data;

namespace TeamProjectManager.DAL.Repositories;

public class AbstractRepository(ManagerDbContext context)
{
	protected readonly ManagerDbContext _context = context;
}