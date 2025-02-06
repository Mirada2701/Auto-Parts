using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public class AutoPartsDbContext:DbContext
    {
        
        public AutoPartsDbContext(DbContextOptions options) : base(options) { }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.SeedCategories();
            modelBuilder.SeedSubCategories();
            modelBuilder.SeedProducers();
            modelBuilder.SeedProviders();
            modelBuilder.SeedParts();

            modelBuilder.Entity<SparePart>().HasOne(sp => sp.Category).WithMany(sp => sp.SpareParts).HasForeignKey(sp => sp.CategoryId);
            modelBuilder.Entity<SparePart>().HasOne(sp => sp.Producer).WithMany(sp => sp.Parts).HasForeignKey(sp => sp.ProducerId);
            modelBuilder.Entity<SparePart>().HasOne(sp => sp.Provider).WithMany(sp => sp.Parts).HasForeignKey(sp => sp.ProviderId);

            modelBuilder.Entity<Category>().HasMany(c => c.SubCategories).WithOne(c => c.Category).HasForeignKey(c => c.CategoryId);
        }

    }
}
