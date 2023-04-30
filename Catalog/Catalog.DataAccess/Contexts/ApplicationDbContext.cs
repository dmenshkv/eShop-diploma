using System.Diagnostics.CodeAnalysis;
using Catalog.Entites.Common;
using Catalog.Entites.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Catalog.DataAccess.Contexts
{
    [ExcludeFromCodeCoverage]
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> databaseContextOptions)
            : base(databaseContextOptions)
        {
        }

        public DbSet<BoardGame> BoardGames { get; set; } = null!;

        public DbSet<Brand> Brands { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Mechanic> Mechanics { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BoardGameEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BrandEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MechanicEntityTypeConfiguration());
        }
    }
}