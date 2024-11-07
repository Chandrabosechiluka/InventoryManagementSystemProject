using InventoryManagementSystemProject.Exceptions;
using InventoryManagementSystemProject.Models;
using InventoryManagementSystemProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemProject.Services
{
    internal class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        // Get product by ID
        public Product GetProductById(int productId)
        {
            return _productRepository.GetProductById(productId);
        }

        // Get all products
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        // Add product
        public void AddProduct(Product product)
        {
            // Check if the product already exists
            var existingProduct = _productRepository.GetAllProducts()
                .FirstOrDefault(p => p.Name == product.Name);

            if (existingProduct != null)
            {
                throw new DuplicateProductException("Product already exists.");
            }

            // Add the new product
            _productRepository.AddProduct(product);
        }

        // Update product
        public void UpdateProduct(Product product)
        {
            var existingProduct = _productRepository.GetProductById(product.ProductId);

            if (existingProduct == null)
            {
                throw new ProductNotFoundException("Product not found.");
            }

            // Update product in repository
            _productRepository.UpdateProduct(product);
        }

        // Delete product
        public void DeleteProduct(int productId)
        {
            var product = _productRepository.GetProductById(productId);

            if (product == null)
            {
                throw new ProductNotFoundException("Product not found.");
            }

            _productRepository.DeleteProduct(productId);
        }
    }




}
