using InventoryManagementSystemProject.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemProject.Presentation
{
    public class ProductMenu
    {
        private ProductController _productController;

        public ProductMenu()
        {
            _productController = new ProductController();
        }

        public void ShowProductMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Product Management");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. View Product's Details");
                Console.WriteLine("5. View All Products");
                Console.WriteLine("6. Go Back to Main Menu");
                Console.Write("Enter your choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _productController.AddProduct();
                        break;
                    case "2":
                        _productController.UpdateProduct();
                        break;
                    case "3":
                        _productController.DeleteProduct();
                        break;
                    case "4":
                        _productController.ViewProductDetails();
                        break;
                    case "5":
                        _productController.ViewAllProducts();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
