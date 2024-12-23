namespace W12_Survivor.Models;

public class Category : BaseModel
{
    public string Name { get; set; }
    public IEnumerable<Competitor> Competitors { get; set; }
}