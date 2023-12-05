using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(255)]
    public string Author { get; set; } = null!;

    [Required]
    [MaxLength(1000)]
    public string Description { get; set; } = null!;

    public List<Loan> Loans { get; set; } = new();
}
