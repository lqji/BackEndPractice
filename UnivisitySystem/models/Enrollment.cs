using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using UnivisitySystem.models;

public class Enrollment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int enrollmentId { get; set; } // system generated

    [Required]
    public int studentId { get; set; } // from list / user input

    [Required]
    public int courseId { get; set; } // from list / user input

    [Required]
    public DateTime enrollmentDate { get; set; } // system generated / calculated

    [MaxLength(2)]
    public string finalGrade { get; set; } // user input / calculated

    [Required]
    [MaxLength(20)]
    public string status { get; set; } = "In Progress"; // default value


    
    [ForeignKey("studentId")]
    public Student Student { get; set; } // system generated

    [ForeignKey("courseId")]
    public Course Course { get; set; } // system generated
}