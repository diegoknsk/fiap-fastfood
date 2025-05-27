using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastFood.Domain.Entities.CustomerIdentification;
using FastFood.Domain.Entities.DeliveryManagement;
using FastFood.Domain.Entities.OrderManagement;
using FastFood.Domain.Entities.OrderManagement.Ingredients;
using FastFood.Domain.Entities.PaymentManagement;
using FastFood.Domain.Entities.PreparationManagement;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Infra.Data.Context
{
    public class FastFoodDbContext : DbContext
    {
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderedProduct> OrderedProducts => Set<OrderedProduct>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Preparation> Preparations => Set<Preparation>();
        public DbSet<Delivery> Deliveries => Set<Delivery>();
        public DbSet<ProductBaseIngredient> ProductBaseIngredients => Set<ProductBaseIngredient>();
        public DbSet<AddedIngredient> AddedIngredients => Set<AddedIngredient>();
        public DbSet<RemovedIngredient> RemovedIngredients => Set<RemovedIngredient>();


        public FastFoodDbContext(DbContextOptions<FastFoodDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FastFoodDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
