using Microsoft.EntityFrameworkCore;
using PetUci.Models;
using System.Collections.Generic;

namespace PetUci.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<ImageFiles> ImageFiles { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Disease>().ToTable("Diseases");
            modelBuilder.Entity<Forum>().ToTable("Forums");
            modelBuilder.Entity<ImageFiles>().ToTable("ImageFiles");
            modelBuilder.Entity<Pet>().ToTable("Pets");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Rol>().ToTable("Roles");
            modelBuilder.Entity<Treatment>().ToTable("Treatments");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Vaccine>().ToTable("Vaccines");

            modelBuilder.Entity<ImageFiles>()
                .HasOne(i => i.Product)
                .WithOne(p => p.ImageFile)
                .HasForeignKey<ImageFiles>(i => i.ProductId)
                .HasForeignKey<ImageFiles>(i=>i.PetId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(u => u.RolObj)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Forum>()
                .HasOne(f => f.User)
                .WithMany(u => u.Forums)
                .HasForeignKey(f => f.IdUser)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Treatment>()
         .HasOne(t => t.Disease)
         .WithMany()
         .HasForeignKey(t => t.IdDisease)
         .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

