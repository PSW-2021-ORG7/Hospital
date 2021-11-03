using Hospital_Class_Library.Graphical_Editor.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Class_Library.Graphical_Editor.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Building> Buildings { get; set; }

        // only for testing purposes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>().HasData(
                new Building { Id = "b1", Name = "Oasis Main Building", Description = "The administrative center of Oasis Healthcare"},
                new Building { Id = "b2", Name = "Oasis Treatment Center", Description = "The treatment facility of Oasis Healthcare"}
            );
        }
    }
}
