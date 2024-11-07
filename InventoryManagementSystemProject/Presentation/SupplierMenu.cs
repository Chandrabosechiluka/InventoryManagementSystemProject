using InventoryManagementSystemProject.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemProject.Presentation
{
    public class SupplierMenu
    {
        private SupplierController _supplierController;

        public SupplierMenu()
        {
            _supplierController = new SupplierController();
        }

        public void ShowSupplierMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Supplier Management");
                Console.WriteLine("1. Add Supplier");
                Console.WriteLine("2. Update Supplier");
                Console.WriteLine("3. Delete Supplier");
                Console.WriteLine("4. View Supplier's Details");
                Console.WriteLine("5. View All Suppliers");
                Console.WriteLine("6. Go Back to Main Menu");
                Console.Write("Enter your choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _supplierController.AddSupplier();
                        break;
                    case "2":
                        _supplierController.UpdateSupplier();
                        break;
                    case "3":
                        _supplierController.DeleteSupplier();
                        break;
                    case "4":
                        _supplierController.GetAllSuppliers();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
