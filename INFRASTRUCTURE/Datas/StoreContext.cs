using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using CORE.Entities;

namespace INFRASTRUCTURE.Datas;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions options) : base (options)
    {}
    public DbSet<Products> Product { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Products>().Property(p => p.Price).HasPrecision(18,2);
    }

}
