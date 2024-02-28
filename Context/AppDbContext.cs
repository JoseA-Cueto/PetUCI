using Microsoft.EntityFrameworkCore;
using PetUci.Models;

namespace PetUci.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<ImageFiles> ImageFiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.id); // Definir la clave primaria de Product

            modelBuilder.Entity<Pet>()
                .HasKey(p => p.id); // Definir la clave primaria de Pet

            modelBuilder.Entity<User>()
                .HasKey(u => u.id); // Definir la clave primaria de User

            modelBuilder.Entity<Rol>()
                .HasKey(r => r.id); // Definir la clave primaria de Rol

            modelBuilder.Entity<Vaccine>()
                .HasKey(v => v.id); // Definir la clave primaria de Vaccine

            modelBuilder.Entity<Disease>()
                .HasKey(d => d.Id); // Definir la clave primaria de Disease

            modelBuilder.Entity<Treatment>()
                .HasKey(t => t.id); // Definir la clave primaria de Treatment

            modelBuilder.Entity<Forum>()
                .HasKey(f => f.id); // Definir la clave primaria de Forum

            modelBuilder.Entity<Treatment>()
    .HasOne(t => t.disease)
    .WithOne(d => d.treatment)
    .HasForeignKey<Disease>(d => d.idTreatment)
    .IsRequired()
    .OnDelete(DeleteBehavior.Cascade);



        }

    }
}
