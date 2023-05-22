using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace E_Mart.Models
{
    public class GrocceryContext : DbContext
    {
        public DbSet<Groccery> Products { get; set; }
        public GrocceryContext() { }

        public GrocceryContext(DbContextOptions<GrocceryContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\\ProjectModels;Initial Catalog=Emart;Integrated Security=True");
        }
    }
}
