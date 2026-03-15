using GameTournamentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTournamentApi.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Tournament> Tournaments { get; set; }
	}
}