using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;

        public DbInitializer(ApplicationDbContext db)
        {
            _db = db;
        }


        public void Initialize()
        {
            _db.Database.EnsureCreated();

            //migrations if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Any())
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {

            }

            if (!_db.Categories.Any())
            {
                var Categories = new List<Category>
                {
                    new Category { Name = "Non-Alcoholic Beverages", DisplayOrder = 1 },
                    new Category { Name = "Wine", DisplayOrder = 2 },
                    new Category { Name = "Snacks", DisplayOrder = 3 }
                };

                foreach (var c in Categories)
                {
                    _db.Categories.Add(c);
                }
            }

            if (!_db.Manufacturers.Any())
            {
                var Manufacturers = new List<Manufacturer>
                {
                    new Manufacturer { Name = "Coca-Cola" },
                    new Manufacturer { Name = "Frito-Lay" },
                    new Manufacturer { Name = "Kroger" }
                };

                foreach (var m in Manufacturers)
                {
                    _db.Manufacturers.Add(m);
                }

            }

            _db.SaveChanges();
        }
    }
}