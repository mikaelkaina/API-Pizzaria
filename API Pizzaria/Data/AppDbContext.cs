using API_Pizzaria.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Pizzaria.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<PizzaModel> Pizzas { get; set; }
	}
}
