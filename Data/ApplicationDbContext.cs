
namespace RESTAPIProject.Data.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Villa> Villas { get; set; }
    }
}