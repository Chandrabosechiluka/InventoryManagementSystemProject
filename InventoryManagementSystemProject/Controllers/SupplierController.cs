using InventoryManagementSystemProject.Models;
using InventoryManagementSystemProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemProject.Controllers
{
    internal class SupplierController
    {
        private SupplierRepository _supplierRepository;

        public SupplierController()
        {
            _supplierRepository = new SupplierRepository();
        }

        public void GetAllSuppliers()
        {
            var suppliers = _supplierRepository.GetAll();

            foreach (var supplier in suppliers)
            {
                Console.WriteLine($"Supplier ID: {supplier.SupplierId}, Name: {supplier.Name}, Contact Info: {supplier.ContactInfo}");
            }
        }

        public void AddSupplier()
        {
            Console.Write("Enter Supplier Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Contact Info: ");
            string contactInfo = Console.ReadLine();

            var supplier = new Supplier()
            {
                Name = name,
                ContactInfo = contactInfo
            };

            _supplierRepository.Add(supplier);
            Console.WriteLine("Supplier successfully added.");
        }

        public void UpdateSupplier()
        {
            Console.Write("Enter Supplier ID to update: ");
            int supplierId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter new Supplier Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter new Contact Info: ");
            string contactInfo = Console.ReadLine();

            var supplier = new Supplier
            {
                SupplierId = supplierId,
                Name = name,
                ContactInfo = contactInfo
            };

            _supplierRepository.Update(supplier);
            Console.WriteLine("Supplier successfully updated.");
        }

        public void DeleteSupplier()
        {
            Console.Write("Enter Supplier ID to delete: ");
            int supplierId = Convert.ToInt32(Console.ReadLine());

            _supplierRepository.Delete(supplierId);
            Console.WriteLine("Supplier successfully deleted.");
        }
    }

}
