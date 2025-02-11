using System;
using AutoStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoStore.Data
{
    public class AutoStoreContext : DbContext
    {
        public AutoStoreContext(DbContextOptions<AutoStoreContext> options) 
            : base(options)
        {
        }

        public DbSet<Part> Parts => Set<Part>();
        public DbSet<PartType> PartTypes => Set<PartType>();

        public DbSet<Order> Orders=> Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartType>().HasData(
                new {Id=1, Name="Engine"},
                new {Id=2, Name="Transmission"},
                new {Id=3, Name="Suspension"},
                new {Id=4, Name="Brakes"}
            );
        }
    }
}