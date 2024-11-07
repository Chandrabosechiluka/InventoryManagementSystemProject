using InventoryManagementSystemProject.Data;
using InventoryManagementSystemProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemProject.Repositories
{
    internal class SupplierRepository
    {
        private InventoryContext _context;

        public SupplierRepository()
        {
            _context = new InventoryContext();
        }

        public List<Supplier> GetAll()
        {
            return _context.Suppliers.ToList();
        }

        public void Add(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void Update(Supplier supplier)
        {
            var existingSupplier = _context.Suppliers.Find(supplier.SupplierId);
            if (existingSupplier != null)
            {
                existingSupplier.Name = supplier.Name;
                existingSupplier.ContactInfo = supplier.ContactInfo;
                _context.SaveChanges();
            }
        }

        public void Delete(int supplierId)
        {
            var supplier = _context.Suppliers.Find(supplierId);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
        }
    }

}
