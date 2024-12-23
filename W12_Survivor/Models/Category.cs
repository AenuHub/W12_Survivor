using System.ComponentModel.DataAnnotations;

namespace W12_Survivor.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
    public IEnumerable<Competitor> Competitors { get; set; }
}