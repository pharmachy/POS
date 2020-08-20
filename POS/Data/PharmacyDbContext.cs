using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using POS.Models;

namespace POS.Data
{
    public class POSDbContext : DbContext
    {
        public POSDbContext(DbContextOptions<POSDbContext> options)
            : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<TestChild> TestChilds { get; set; }
        public DbSet<TestParent> TestParent { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Pack> Pack { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<BrandModel> BrandModels { get; set; }
        public DbSet<PO> PO { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<SupplierA> SupplierA { get; set; }
        public DbSet<ContactPerson> ContactPerson { get; set; }

    }
}