using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using commerce.DAL.Data.Model;

namespace commerce.DAL.Context
{
    public class EcommerceContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<ProductOrder> ProductOrders => Set<ProductOrder>();
        public DbSet<ProductCart> ProductCarts => Set<ProductCart>();
        public DbSet<Category> Categories => Set<Category>();

        public EcommerceContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite keys
            modelBuilder.Entity<ProductCart>()
                .HasKey(pc => new { pc.ProductId, pc.CartId });

            modelBuilder.Entity<ProductOrder>()
                .HasKey(po => new { po.ProductId, po.OrderId });

            // Relationships
            modelBuilder.Entity<ProductCart>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.productCarts)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCart>()
                .HasOne(pc => pc.cart)
                .WithMany(c => c.CartItem)
                .HasForeignKey(pc => pc.CartId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Product)
                .WithMany(p => p.productOrders)
                .HasForeignKey(po => po.ProductId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(po => po.OrderId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.user)
                .WithOne(u => u.cart)
                .HasForeignKey<Cart>(c => c.userId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.user)
                .WithMany(u => u.orders)
                .HasForeignKey(o => o.userId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // Seed data for Categories
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "clothes" },
                new Category { Id = 2, Name = "shoes" },
                new Category { Id = 3, Name = "watches" }
            };

            // Seed data for Products
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "t-shirt", Description = "cotton t-shirt", Color = "red", CategoryId = 1, Size = "20", Price = 3000 },
                new Product { Id = 2, Name = "dress", Description = "black child dress", Color = "black", CategoryId = 3, Size = "20", Price = 40000 },
                new Product { Id = 3, Name = "watch", Description = "good product apple", Color = "white", CategoryId = 2, Size = "20", Price = 90000 }
            };

            // Seed data for Users (example)
            var users = new List<User>
            {
                new User { Id = "1", UserName = "user1", Email = "user1@example.com", NormalizedUserName = "USER1", NormalizedEmail = "USER1@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAEHGVQf/...", SecurityStamp = "XYZ", ConcurrencyStamp = "ABC" },
                new User { Id = "2", UserName = "user2", Email = "user2@example.com", NormalizedUserName = "USER2", NormalizedEmail = "USER2@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAEHGVQf/...", SecurityStamp = "XYZ", ConcurrencyStamp = "DEF" }
            };

            // Seed data for Carts
            var carts = new List<Cart>
            {
                new Cart { Id = 1, userId = "1" },
                new Cart { Id = 2, userId = "2" }
            };

            // Seed data for Orders
            var orders = new List<Order>
            {
                new Order { Id = 1, userId = "1", CeartionDateTime = new DateTime(2024, 4, 24) },
                new Order { Id = 2, userId = "2", CeartionDateTime = new DateTime(2024, 3, 24) }
            };

            // Seed data for ProductCarts
            var productCarts = new List<ProductCart>
            {
                new ProductCart { ProductId = 1, CartId = 1, ProductQuntity = 3 },
                new ProductCart { ProductId = 2, CartId = 2, ProductQuntity = 2 }
            };

            // Seed data for ProductOrders
            var productOrders = new List<ProductOrder>
            {
                new ProductOrder { ProductId = 1, OrderId = 1, ProductQuntity = 1 },
                new ProductOrder { ProductId = 2, OrderId = 2, ProductQuntity = 2 }
            };

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Cart>().HasData(carts);
            modelBuilder.Entity<Order>().HasData(orders);
            modelBuilder.Entity<ProductCart>().HasData(productCarts);
            modelBuilder.Entity<ProductOrder>().HasData(productOrders);
        }
    }
}
