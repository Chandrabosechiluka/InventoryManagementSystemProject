using InventoryManagementSystemProject.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemProject.Presentation
{
    public class TransactionMenu
    {
        private TransactionController _transactionController;

        public TransactionMenu()
        {
            _transactionController = new TransactionController();
        }

        public void ShowTransactionMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Transaction Management");
                Console.WriteLine("1. Add Stock");
                Console.WriteLine("2. Remove Stock");
                Console.WriteLine("3. View Transaction History");
                Console.WriteLine("4. Go Back to Main Menu");
                Console.Write("Enter your choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _transactionController.AddStock();
                        break;
                    case "2":
                        _transactionController.RemoveStock();
                        break;
                    case "3":
                        _transactionController.DisplayTransactionHistory();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

