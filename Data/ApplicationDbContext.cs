using Microsoft.EntityFrameworkCore;
using RESTAPIProject.Models.Villa;
using System.Collections.Generic;


namespace RESTAPIProject.Data.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
            {
            }
        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // var villas = GenerateVilla(100);
            // modelBuilder.Entity<Villa>().HasData(villas);
        }

        public async Task SeedDataAsync()
        {
            if (!await Villas.AnyAsync())
            {
                var villas = GenerateVilla(100);
                await Villas.AddRangeAsync(villas);
                await SaveChangesAsync();
            }
        }

        private List<Villa> GenerateVilla(int count)
        {
            Random random = new Random();
            List<Villa> villas = new List<Villa>();

            for (int i = 0; i < count; i++)
            {
                villas.Add(new Villa
                {
                    Name = GenerateName(random),
                    Details = GenerateDescription(random),
                    Rate = Math.Round(random.NextDouble() * 900 + 100, 2),
                    Sqft = random.Next(500, 50001),
                    Occupancy = random.Next(2, 100),
                    ImageUrl = string.Empty,
                    Amenity = string.Empty,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null
                });
            }
            return villas;
        }

        private string GenerateName(Random random)
        {
            int length = random.Next(2, 8);
            var name = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ", length)
                        .Select(x => x[random.Next(x.Length)]).ToArray());
            return $"{name} Villa";
        }

        private string GenerateDescription(Random random)
        {
            int length = random.Next(10, 20);
            var description = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ ", length)
                            .Select(x => x[random.Next(x.Length)]).ToArray());
            return description;
        }
    }
}