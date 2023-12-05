using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Library.Models;

public class Customer
{
    [Key]
    [MaxLength(14)]
    [JsonPropertyName("library_card_number")]
    public string LibraryCardNumber { get; set; } = null!;

    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(255)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    public List<Loan> Loans { get; set; } = new();
}
