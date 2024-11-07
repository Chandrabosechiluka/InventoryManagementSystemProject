using InventoryManagementSystemProject.Models;
using Microsoft.IdentityModel.Protocols;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemProject.Data
{
    internal class InventoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.AppSettings["connString"]);
        }
    }
}
