using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace consolidation_csharp_mini_project_3.Models;

public class Customer
{
    [Key]
    [MaxLength(10)]
    [JsonPropertyName("library_card_number")]
    public string LibraryCardNumber { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    [Required]
    [MaxLength(255)]
    [EmailAddress]
    public string Email { get; set; }

    public List<Loan> Loans { get; set; }
}
