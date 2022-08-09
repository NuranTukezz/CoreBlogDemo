using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-G2007Q5;Initial Catalog=CoreBlogApiDemoDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
