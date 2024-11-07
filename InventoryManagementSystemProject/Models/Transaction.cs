using InventoryManagementSystemProject.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemProject.Models
{
    internal class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public TransactionType Type { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }
        public Inventory? Inventory { get; set; }
    }
}
