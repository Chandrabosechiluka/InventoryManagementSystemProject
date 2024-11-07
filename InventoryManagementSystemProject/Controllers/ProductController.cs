using InventoryManagementSystemProject.Models;
using InventoryManagementSystemProject.Repositories;
using InventoryManagementSystemProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemProject.Controllers
{
    internal class ProductController
    {
        private readonly ProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
        }

        // Add a new product
        public void AddProduct()
        {
            try
            {
                Console.Write("Enter Product Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Product Description: ");
                string description = Console.ReadLine();

                Console.Write("Enter Product Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Console.Write("Enter Product Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                var product = new Product
                {
                    Name = name,
                    Description = description,
                    Quantity = quantity,
                    Price = price
                };

                _productService.AddProduct(product);
                Console.WriteLine("Product added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Update product details
        public void UpdateProduct()
        {
            try
            {
                Console.Write("Enter Product ID to Update: ");
                int productId = int.Parse(Console.ReadLine());

                var existingProduct = _productService.GetProductById(productId);

                if (existingProduct == null)
                {
                    Console.WriteLine("Product not found.");
                    return;
                }

                Console.Write("Enter New Product Name (Leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) existingProduct.Name = name;

                Console.Write("Enter New Product Description (Leave blank to keep current): ");
                string description = Console.ReadLine();
                if (!string.IsNullOrEmpty(description)) existingProduct.Description = description;

                Console.Write("Enter New Product Quantity (Leave blank to keep current): ");
                string quantityInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(quantityInput)) existingProduct.Quantity = int.Parse(quantityInput);

                Console.Write("Enter New Product Price (Leave blank to keep current): ");
                string priceInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(priceInput)) existingProduct.Price = decimal.Parse(priceInput);

                _productService.UpdateProduct(existingProduct);
                Console.WriteLine("Product updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Delete a product
        public void DeleteProduct()
        {
            try
            {
                Console.Write("Enter Product ID to Delete: ");
                int productId = int.Parse(Console.ReadLine());

                var existingProduct = _productService.GetProductById(productId);

                if (existingProduct == null)
                {
                    Console.WriteLine("Product not found.");
                    return;
                }

                _productService.DeleteProduct(productId);
                Console.WriteLine("Product deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // View product details by ID
        public void ViewProductDetails()
        {
            try
            {
                Console.Write("Enter Product ID to View: ");
                int productId = int.Parse(Console.ReadLine());

                var product = _productService.GetProductById(productId);

                if (product == null)
                {
                    Console.WriteLine("Product not found.");
                    return;
                }

                Console.WriteLine($"Product ID: {product.ProductId}");
                Console.WriteLine($"Product Name: {product.Name}");
                Console.WriteLine($"Description: {product.Description}");
                Console.WriteLine($"Quantity: {product.Quantity}");
                Console.WriteLine($"Price: {product.Price:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // View all products
        public void ViewAllProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();

                if (products.Count == 0)
                {
                    Console.WriteLine("No products found.");
                    return;
                }

                foreach (var product in products)
                {
                    Console.WriteLine($"Product ID: {product.ProductId}");
                    Console.WriteLine($"Product Name: {product.Name}");
                    Console.WriteLine($"Description: {product.Description}");
                    Console.WriteLine($"Quantity: {product.Quantity}");
                    Console.WriteLine($"Price: {product.Price:C}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }


}
