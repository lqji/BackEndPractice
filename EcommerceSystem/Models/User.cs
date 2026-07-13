using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceSystem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; } // system generated

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } // user input

        [Required]
        [MaxLength(150)]
        public string Email { get; set; } // user input

        [Required]
        [MaxLength(256)]
        public string PasswordHash { get; set; } // system generated

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } // user input

        [MaxLength(20)]
        public string PhoneNumber { get; set; } // user input

        [MaxLength(300)]
        public string Address { get; set; } // user input

        [Required]
        public DateTime RegistrationDate { get; set; } // system generated

        public bool IsActive { get; set; } = true; // default value

        // Navigation Properties
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>(); // system generated
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>(); // system generated
    }
}