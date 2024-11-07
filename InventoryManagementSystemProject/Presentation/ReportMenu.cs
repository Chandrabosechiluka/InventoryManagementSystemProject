using InventoryManagementSystemProject.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemProject.Presentation
{
    public class ReportMenu
    {
        private ProductController _productController;
        private SupplierController _supplierController;
        private TransactionController _transactionController;

        public ReportMenu()
        {
            _productController = new ProductController();
            _supplierController = new SupplierController();
            _transactionController = new TransactionController();
        }

        public void GenerateReport()
        {
            Console.Clear();
            Console.WriteLine("Generating Report...");

            Console.WriteLine("Inventory Details:");
            _productController.ViewAllProducts();
            _supplierController.GetAllSuppliers();
            _transactionController.DisplayTransactionHistory();

            Console.WriteLine("Report generated successfully.");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }
    }
}

