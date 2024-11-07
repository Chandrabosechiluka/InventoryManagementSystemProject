using InventoryManagementSystemProject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using InventoryManagementSystemProject.Models;

namespace InventoryManagementSystemProject.Repositories
{
    internal class TransactionRepository
    {
        private InventoryContext _context;

        public TransactionRepository()
        {
            _context = new InventoryContext();
        }

        public List<Models.Transaction> GetAll()
        {
            return _context.Transactions.Include(t => t.Product).ToList();
        }

        public void Add(Models.Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public void Update(Models.Transaction transaction)
        {
            var existingTransaction = _context.Transactions.Find(transaction.TransactionId);
            if (existingTransaction != null)
            {
                existingTransaction.Quantity = transaction.Quantity;
                existingTransaction.Date = transaction.Date;
                existingTransaction.ProductId = transaction.ProductId;
             
                _context.SaveChanges();
            }
        }

        public void Delete(int transactionId)
        {
            var transaction = _context.Transactions.Find(transactionId);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                _context.SaveChanges();
            }
        }

        public Models.Transaction GetById(int transactionId)
        {
            return _context.Transactions.Include(t => t.Product).FirstOrDefault(t => t.TransactionId == transactionId);
        }

        

    }


}
