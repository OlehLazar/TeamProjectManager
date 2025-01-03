using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamProjectManager.DAL.Entities;

namespace TeamProjectManager.DAL.Data;

public class ManagerDbContext : IdentityDbContext<User>
{
    public ManagerDbContext(DbContextOptions<ManagerDbContext> options) 
        : base(options)
    {
        
    }

    public DbSet<Board> Boards { get; set; }

    public DbSet<Notification> Notifications { get; set; }

	public DbSet<Project> Projects { get; set; }

    public DbSet<Entities.Task> Tasks { get; set; }

	public DbSet<Team> Teams { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
        ArgumentNullException.ThrowIfNull(builder);
		base.OnModelCreating(builder);

		builder.Entity<User>(user =>
		{
			user.HasMany(u => u.Notifications)
				.WithOne(n => n.User)
				.HasForeignKey(n => n.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			user.HasMany(u => u.CreatedTasks)
				.WithOne(t => t.Creator)
				.HasForeignKey(t => t.CreatorId)
				.OnDelete(DeleteBehavior.Restrict);

			user.HasMany(u => u.AssignedTasks)
				.WithOne(t => t.Assignee)
				.HasForeignKey(t => t.AssigneeId)
				.OnDelete(DeleteBehavior.Restrict);

			user.HasMany(u => u.Teams)
				.WithMany(t => t.Members)
				.UsingEntity<Dictionary<string, object>>(
					"UserTeam",
					j => j.HasOne<Team>()
						  .WithMany()
						  .HasForeignKey("TeamId")
						  .OnDelete(DeleteBehavior.Cascade),
					j => j.HasOne<User>()
						  .WithMany()
						  .HasForeignKey("UserId")
						  .OnDelete(DeleteBehavior.Cascade)
				);
		});

		builder.Entity<Team>(team =>
		{
			team.HasOne(t => t.Leader)
				.WithMany()
				.HasForeignKey(t => t.LeaderId)
				.OnDelete(DeleteBehavior.Restrict);

			team.HasMany(t => t.Projects)
				.WithOne(p => p.Team)
				.HasForeignKey(p => p.TeamId);
		});

		builder.Entity<Entities.Task>(task =>
		{
			task.HasOne(t => t.Board)
				.WithMany(b => b.Tasks)
				.HasForeignKey(t => t.BoardId);

			task.HasOne(t => t.Creator)
				.WithMany(u => u.CreatedTasks)
				.HasForeignKey(t => t.CreatorId);

			task.HasOne(t => t.Assignee)
				.WithMany(u => u.AssignedTasks)
				.HasForeignKey(t => t.AssigneeId);
		});

		builder.Entity<Project>(project =>
		{
			project.HasMany(p => p.Boards)
				.WithOne(b => b.Project)
				.HasForeignKey(b => b.ProjectId);
		});

		builder.Entity<Notification>(notification =>
		{
			notification.Property(n => n.CreatedAt)
				.HasDefaultValueSql("datetime('now')");

			notification.HasOne(n => n.User)
				.WithMany(u => u.Notifications)
				.HasForeignKey(n => n.UserId);
		});

		builder.Entity<Board>(board =>
		{
			board.Property(b => b.CreatedDate)
				.HasDefaultValueSql("datetime('now')");

			board.HasMany(b => b.Tasks)
				.WithOne(t => t.Board)
				.HasForeignKey(t => t.BoardId);

			board.HasOne(b => b.Project)
				.WithMany(p => p.Boards)
				.HasForeignKey(b => b.ProjectId);
		});
	}
}
