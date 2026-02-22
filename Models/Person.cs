namespace MvcDapperDemo.Models;

using System.ComponentModel.DataAnnotations;

public class Person
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [Range(0, 150, ErrorMessage = "Age must be between 0 and 150.")]
    public int Age { get; set; }
}
