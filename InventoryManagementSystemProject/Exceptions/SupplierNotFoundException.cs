using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemProject.Exceptions
{
    public class SupplierNotFoundException : Exception
    {
        public SupplierNotFoundException(string message) : base(message) { }
    }
}
