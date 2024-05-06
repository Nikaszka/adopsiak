using AdoPsiak.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdoPsiak.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalPhoto> AnimalPhotos { get; set; }
        public DbSet<AdoptionForm> AdoptionForms { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<MonetarySupport> MonetarySupportEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasMany<AdoptionForm>(a => a.AdoptionForms);
        }
    }
}
