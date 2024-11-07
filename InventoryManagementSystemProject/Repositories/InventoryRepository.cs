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
    internal class InventoryRepository
    {
        private InventoryContext _context;

        public InventoryRepository()
        {
            _context = new InventoryContext();
        }

        public List<Inventory> GetAll()
        {
            return _context.Inventories.ToList();
        }

        public void Add(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            _context.SaveChanges();
        }

        public void Update(Inventory inventory)
        {
            var existingInventory = _context.Inventories.Find(inventory.InventoryId);
            if (existingInventory != null)
            {
                existingInventory.Location = inventory.Location;
                _context.SaveChanges();
            }
        }

        public void Delete(int inventoryId)
        {
            var inventory = _context.Inventories.Find(inventoryId);
            if (inventory != null)
            {
                _context.Inventories.Remove(inventory);
                _context.SaveChanges();
            }
        }
    }

}
