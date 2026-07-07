using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceSystem.Models
{
    public class OrderItem
    {
        [Required]
        public int OrderId { get; set; } // foreign key

        [Required]
        public int ProductId { get; set; } // foreign key

        [Required]
        [Range(1, 999)]
        public int Quantity { get; set; } // user input

        // Navigation Properties
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; } // system generated

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } // system generated
    }
}