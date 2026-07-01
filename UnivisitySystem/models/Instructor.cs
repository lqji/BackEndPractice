using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using UnivisitySystem.models;

public class Instructor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int instructorId { get; set; } // system generated

    [Required]
    [MaxLength(100)]
    public string fullName { get; set; } // user input

    [Required]
    [MaxLength(150)]
    public string email { get; set; } // user input

    [MaxLength(20)]
    public string officeNumber { get; set; } // user input

    [Required]
    public DateTime hireDate { get; set; } // user input

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Salary must be greater than 0")]
    public decimal salary { get; set; } // user input

    [Required]
    [MaxLength(50)]
    public string academicTitle { get; set; } // user input


    public Department DepartmentHeadOf { get; set; } // system generated
        
    public ICollection<Course> TaughtCourses { get; set; } // system generated
}