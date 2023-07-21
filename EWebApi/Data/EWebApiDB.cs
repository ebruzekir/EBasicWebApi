using EWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EWebApi.Data
{
    public class EWebApiDB : DbContext
    {
        public EWebApiDB(DbContextOptions<EWebApiDB> context) : base(context)
        {
        }
        public DbSet<Company> Company { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Country> Country { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
            .HasOne(_ => _.Company)
            .WithMany(a => a.contacts)
            .HasForeignKey(p => p.CompanyId);
            modelBuilder.Entity<Contact>()
            .HasOne(_ => _.Country)
            .WithMany(a => a.contacts)
            .HasForeignKey(p => p.CountryId);

        }

    }

}
