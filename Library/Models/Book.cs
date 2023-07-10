using System.ComponentModel.DataAnnotations;

namespace consolidation_csharp_mini_project_3.Models;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Title { get; set; }

    [Required]
    [MaxLength(255)]
    public string Author { get; set; }

    [Required]
    [MaxLength(1000)]
    public string Description { get; set; }

    public List<Loan> Loans { get; set; } = new List<Loan>();
}
