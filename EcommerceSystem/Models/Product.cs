using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceSystem.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; } // system generated

        [Required]
        [MaxLength(150)]
        public string ProductName { get; set; } // user input

        [MaxLength(1000)]
        public string Description { get; set; } // user input

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; } // user input

        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; } = 0; // default value

        [MaxLength(300)]
        public string ImageUrl { get; set; } // user input

        [Required]
        public int CategoryId { get; set; } // foreign key

        [Required]
        public DateTime CreatedAt { get; set; } // system generated

        public bool IsAvailable { get; set; } = true; // default value

        // Navigation Properties
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; } // system generated

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>(); // system generated
        
        // Updated collection property name to reference OrderItem
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>(); // system generated
    }
}