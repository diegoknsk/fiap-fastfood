using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastFood.Domain.Entities.CustomerIdentification;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Infra.Data.Context
{
    public class FastFoodDbContext : DbContext
    {
        public DbSet<Customer> Customers => Set<Customer>();

        public FastFoodDbContext(DbContextOptions<FastFoodDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FastFoodDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
