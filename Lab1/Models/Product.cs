using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab1.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; } = null!;
        public int? SupplierId { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        [Required]
        public string? QuantityPerUnit { get; set; }
        [Required]
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
