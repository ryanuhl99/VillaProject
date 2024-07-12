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
        public DbSet<VillaNumber> VillaNumbers { get; set; }

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

        public async Task SeedVillaNumberDataAsync()
        {
            if (!await VillaNumbers.AnyAsync())
            {
                var villaNumber = GenerateVillaNumber(100);
                await VillaNumbers.AddRangeAsync(villaNumber);
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

        private List<VillaNumber> GenerateVillaNumber(int count)
        {
            List<VillaNumber> villaNumbers = new List<VillaNumber>();

            string[] details = new[] 
            {
                "Three-Story, Spiral Staircase",
                "Two-Story, Fruit Trees",
                "Ocean View, Ample Closet Space",
                "Forest View, Jacuzzi Tub",
                "Backyard, Garden",
                "Basement, Garden",
                "Ample Closet Space, Ocean View",
                "ADA Compliant, Balcony",
                "Jacuzzi Tub, Infinity Pool",
                "Air Conditioning, Pool"
            };

            for (int i = 100; i < count; i++)
            {
                villaNumber.Add(new VillaNumber 
                {
                    VillaNo = i,
                    SpecialDetails = GenerateSpecialDetails(details),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null
                });
            }

            return villaNumber;
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


        private string GenerateSpecialDetails(string[] details)
        {
            Random random = new Random();
            int index = random.Next(details.Length);
            return details[index];
        }
    }
}