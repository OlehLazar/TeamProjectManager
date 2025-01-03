using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TeamProjectManager.DAL.Data;

public class ManagerDbContextFactory : IDesignTimeDbContextFactory<ManagerDbContext>
{
	public ManagerDbContext CreateDbContext(string[] args)
	{
		var options = new DbContextOptionsBuilder<ManagerDbContext>()
			.UseSqlite("Data Source=../db/Manager.db")
			.Options;

		return new ManagerDbContext(options);
	}
}
