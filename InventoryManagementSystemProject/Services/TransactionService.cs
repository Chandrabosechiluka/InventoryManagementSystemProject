using InventoryManagementSystemProject.Exceptions;
using InventoryManagementSystemProject.Models;
using InventoryManagementSystemProject.Repositories;
using InventoryManagementSystemProject.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemProject.Services
{
    internal class TransactionService
    {
        private readonly ProductRepository _productRepo;
        private readonly TransactionRepository _transactionRepo;

        public TransactionService()
        {
            _productRepo = new ProductRepository();
            _transactionRepo = new TransactionRepository();
        }


        public void UpdateTransaction(Models.Transaction transaction)
        {
            var existingTransaction = _transactionRepo.GetById(transaction.TransactionId);
            if (existingTransaction == null)
            {
                throw new Exception("Transaction not found.");
            }

            // Update the details of the transaction (ProductId, Quantity, Date)
            existingTransaction.ProductId = transaction.ProductId;
            existingTransaction.Quantity = transaction.Quantity;
            existingTransaction.Date = transaction.Date;

            _transactionRepo.Update(existingTransaction);
        }

        // Delete a transaction from the repository
        public void DeleteTransaction(int transactionId)
        {
            var transaction = _transactionRepo.GetById(transactionId);
            if (transaction == null)
            {
                throw new Exception("Transaction not found.");
            }

            _transactionRepo.Delete(transactionId);
        }

        public void AddStock(int productId, int quantity)
        {
            var product = _productRepo.GetAllProducts().FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                throw new ProductNotFoundException("Product not found.");
            }

            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }

            product.Quantity += quantity;

            var transaction = new Transaction
            {
                ProductId = productId,
                Quantity = quantity,
                Type = TransactionType.Add,
                Date = DateTime.Now
            };

            _transactionRepo.Add(transaction);
        }

        public void RemoveStock(int productId, int quantity)
        {
            var product = _productRepo.GetAllProducts().FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                throw new ProductNotFoundException("Product not found.");
            }

            if (product.Quantity < quantity)
            {
                throw new InsufficientStockException("Not enough stock to remove.");
            }

            product.Quantity -= quantity;

            var transaction = new Transaction
            {
                ProductId = productId,
                Quantity = quantity,
                Type = TransactionType.Remove,
                Date = DateTime.Now
            };

            _transactionRepo.Add(transaction);
        }

        public List<Transaction> GetTransactionHistory(int productId)
        {
            return _transactionRepo.GetAll().Where(t => t.ProductId == productId).ToList();
        }


    }

}
