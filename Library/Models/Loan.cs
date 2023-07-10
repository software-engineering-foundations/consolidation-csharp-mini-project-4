using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace consolidation_csharp_mini_project_3.Models;

public class Loan
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int BookId { get; set; }
    [ForeignKey("BookId")]
    public Book Book { get; set; }

    [Required]
    [MaxLength(50)]
    [JsonPropertyName("customer_library_card_number")]
    public string CustomerLibraryCardNumber { get; set; }
    [ForeignKey("CustomerLibraryCardNumber")]
    public Customer Customer { get; set; }

    [Required]
    [JsonPropertyName("date_loaned")]
    [System.Text.Json.Serialization.JsonConverter(typeof(DateJsonConverter))]
    public DateTime DateLoaned { get; set; }

    [Required]
    [JsonPropertyName("date_due")]
    public DateTime DateDue { get; set; }

    [JsonPropertyName("date_returned")]
    public DateTime? DateReturned { get; set; }
}
