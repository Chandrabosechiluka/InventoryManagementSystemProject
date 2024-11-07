using InventoryManagementSystemProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemProject.Services
{
    public class ReportService
    {
        private readonly ProductRepository _productRepo;
        private readonly SupplierRepository _supplierRepo;
        private readonly TransactionRepository _transactionRepo;

        public ReportService()
        {
            _productRepo = new ProductRepository();
            _supplierRepo = new SupplierRepository();
            _transactionRepo = new TransactionRepository();
        }

        public void GenerateInventoryReport()
        {
            var products = _productRepo.GetAllProducts();
            var suppliers = _supplierRepo.GetAll();
            var transactions = _transactionRepo.GetAll();

            Console.WriteLine("Inventory Report");
            Console.WriteLine("-----------------");

            Console.WriteLine("Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.Name}, Quantity: {product.Quantity}, Price: {product.Price}");
            }

            Console.WriteLine("Suppliers:");
            foreach (var supplier in suppliers)
            {
                Console.WriteLine($"Supplier ID: {supplier.SupplierId}, Name: {supplier.Name}");
            }

            Console.WriteLine("Transactions:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"Transaction ID: {transaction.TransactionId}, Product ID: {transaction.ProductId}, Quantity: {transaction.Quantity}, Date: {transaction.Date}");
            }
        }
    }

}
