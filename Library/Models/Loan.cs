using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Library.Models;

public class Loan
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int BookId { get; set; }

    [ForeignKey("BookId")]
    public Book Book { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    [JsonPropertyName("customer_library_card_number")]
    public string CustomerLibraryCardNumber { get; set; } = null!;

    [ForeignKey("CustomerLibraryCardNumber")]
    public Customer Customer { get; set; } = null!;

    [Required]
    [JsonPropertyName("date_loaned")]
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime DateLoaned { get; set; }

    [Required]
    [JsonPropertyName("date_due")]
    public DateTime DateDue { get; set; }

    [JsonPropertyName("date_returned")]
    public DateTime? DateReturned { get; set; }
}
