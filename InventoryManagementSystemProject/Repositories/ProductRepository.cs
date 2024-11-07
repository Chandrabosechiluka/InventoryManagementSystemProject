using InventoryManagementSystemProject.Data;
using InventoryManagementSystemProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemProject.Repositories
{
    internal class ProductRepository
    {
        private readonly InventoryContext _context;

        public ProductRepository()
        {
            _context = new InventoryContext();
        }

        // Get a product by ID
        public Product GetProductById(int productId)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == productId);
        }

     

        // Get all products
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        // Add a product
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        // Update a product
        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        // Delete a product
        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }


}
