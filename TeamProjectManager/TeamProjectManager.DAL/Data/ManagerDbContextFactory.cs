using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace TeamProjectManager.DAL.Data;
public class ManagerDbContextFactory : IDesignTimeDbContextFactory<ManagerDbContext>
{
	public ManagerDbContext CreateDbContext(string[] args)
	{
		var options = new DbContextOptionsBuilder<ManagerDbContext>()
			.UseSqlite("Data Source=C:\\Projects\\TeamProjectManager\\TeamProjectManager\\Db\\Manager.db")
			.Options;
		return new ManagerDbContext(options);
	}
}