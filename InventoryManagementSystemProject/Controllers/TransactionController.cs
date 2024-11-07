using InventoryManagementSystemProject.Repositories;
using InventoryManagementSystemProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemProject.Controllers
{
    internal class TransactionController
    {
        private readonly TransactionService _transactionService;

        public TransactionController()
        {
            _transactionService = new TransactionService();
        }

        // Display all transactions in the system
        public void DisplayAllTransactions()
        {
            try
            {
                Console.Write("Enter Product ID to view transaction history: ");
                int productId = Convert.ToInt32(Console.ReadLine());

                var transactions = _transactionService.GetTransactionHistory(productId);

                if (transactions.Count == 0)
                {
                    Console.WriteLine("No transactions found for this product.");
                }
                else
                {
                    Console.WriteLine($"Transaction History for Product ID: {productId}");
                    foreach (var transaction in transactions)
                    {
                        Console.WriteLine($"Transaction ID: {transaction.TransactionId}");
                        Console.WriteLine($"Product ID: {transaction.ProductId}");
                        Console.WriteLine($"Quantity: {transaction.Quantity}");
                        Console.WriteLine($"Date: {transaction.Date}");
                        Console.WriteLine($"Type: {transaction.Type}");
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Add stock to a product
        public void AddStock()
        {
            try
            {
                Console.Write("Enter Product ID to add stock: ");
                int productId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Quantity to add: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                _transactionService.AddStock(productId, quantity);
                Console.WriteLine("Stock added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Remove stock from a product
        public void RemoveStock()
        {
            try
            {
                Console.Write("Enter Product ID to remove stock: ");
                int productId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Quantity to remove: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                _transactionService.RemoveStock(productId, quantity);
                Console.WriteLine("Stock removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Update a transaction (if needed)
        public void UpdateTransaction()
        {
            try
            {
                Console.Write("Enter Transaction ID to update: ");
                int transactionId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter New Product ID: ");
                int productId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter New Quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter New Transaction Date (yyyy-MM-dd): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                var transaction = new Models.Transaction
                {
                    TransactionId = transactionId,
                    ProductId = productId,
                    Quantity = quantity,
                    Date = date
                };

                _transactionService.UpdateTransaction(transaction);
                Console.WriteLine("Transaction updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Delete a transaction
        public void DeleteTransaction()
        {
            try
            {
                Console.Write("Enter Transaction ID to delete: ");
                int transactionId = Convert.ToInt32(Console.ReadLine());

                _transactionService.DeleteTransaction(transactionId);
                Console.WriteLine("Transaction deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void DisplayTransactionHistory()
        {
            try
            {
                Console.Write("Enter Product ID to view transaction history: ");
                int productId = Convert.ToInt32(Console.ReadLine());

                var transactions = _transactionService.GetTransactionHistory(productId);

                if (transactions.Count == 0)
                {
                    Console.WriteLine("No transactions found for this product.");
                }
                else
                {
                    Console.WriteLine($"Transaction History for Product ID: {productId}");
                    foreach (var transaction in transactions)
                    {
                        Console.WriteLine($"Transaction ID: {transaction.TransactionId}");
                        Console.WriteLine($"Product ID: {transaction.ProductId}");
                        Console.WriteLine($"Quantity: {transaction.Quantity}");
                        Console.WriteLine($"Transaction Type: {transaction.Type}"); // Add Type (Add/Remove)
                        Console.WriteLine($"Date: {transaction.Date}");
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }


}
