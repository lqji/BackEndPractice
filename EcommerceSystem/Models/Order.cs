using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceSystem.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; } // system generated

        [Required]
        public int UserId { get; set; } // foreign key

        [Required]
        public DateTime OrderDate { get; set; } // system generated

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal TotalAmount { get; set; } // calculated

        [Required]
        [MaxLength(30)]
        public string Status { get; set; } = "Pending"; // default value

        [Required]
        [MaxLength(300)]
        public string ShippingAddress { get; set; } // user input

        [Required]
        [MaxLength(50)]
        public string PaymentMethod { get; set; } // user input

        // Navigation Properties
        [ForeignKey("UserId")]
        public virtual User User { get; set; } // system generated

        // Updated collection property name to reference OrderItem
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>(); // system generated
    }
}