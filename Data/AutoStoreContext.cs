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
    }
}