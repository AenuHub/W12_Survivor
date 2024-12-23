using System.ComponentModel.DataAnnotations;

namespace W12_Survivor.Models;

public class Competitor
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}