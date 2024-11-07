using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemProject.Presentation
{
    
    internal class MainMenu
    {
        private ProductMenu _productMenu;
        private SupplierMenu _supplierMenu;
        private TransactionMenu _transactionMenu;
        private ReportMenu _reportMenu;

        public MainMenu()
        {
            _productMenu = new ProductMenu();
            _supplierMenu = new SupplierMenu();
            _transactionMenu = new TransactionMenu();
            _reportMenu = new ReportMenu();
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Inventory Management System");
                Console.WriteLine("1. Product Management");
                Console.WriteLine("2. Supplier Management");
                Console.WriteLine("3. Transaction Management");
                Console.WriteLine("4. Generate Report");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _productMenu.ShowProductMenu();
                        break;
                    case "2":
                        _supplierMenu.ShowSupplierMenu();
                        break;
                    case "3":
                        _transactionMenu.ShowTransactionMenu();
                        break;
                    case "4":
                        _reportMenu.GenerateReport();
                        break;
                    case "5":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
    

}
