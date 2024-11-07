using InventoryManagementSystemProject.Models;
using InventoryManagementSystemProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemProject.Controllers
{
    internal class InventoryController
    {
        private InventoryRepository _inventoryRepository;

        public InventoryController()
        {
            _inventoryRepository = new InventoryRepository();
        }

        public void GetAllInventories()
        {
            var inventories = _inventoryRepository.GetAll();

            foreach (var inventory in inventories)
            {
                Console.WriteLine($"Inventory ID: {inventory.InventoryId}, Location: {inventory.Location}");
            }
        }

        public void AddInventory()
        {
            Console.Write("Enter Inventory Location: ");
            string location = Console.ReadLine();

            var inventory = new Inventory()
            {
                Location = location
            };

            _inventoryRepository.Add(inventory);
            Console.WriteLine("Inventory successfully added.");
        }

        public void UpdateInventory()
        {
            Console.Write("Enter Inventory ID to update: ");
            int inventoryId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter new Location: ");
            string location = Console.ReadLine();

            var inventory = new Inventory
            {
                InventoryId = inventoryId,
                Location = location
            };

            _inventoryRepository.Update(inventory);
            Console.WriteLine("Inventory successfully updated.");
        }

        public void DeleteInventory()
        {
            Console.Write("Enter Inventory ID to delete: ");
            int inventoryId = Convert.ToInt32(Console.ReadLine());

            _inventoryRepository.Delete(inventoryId);
            Console.WriteLine("Inventory successfully deleted.");
        }
    }

}
