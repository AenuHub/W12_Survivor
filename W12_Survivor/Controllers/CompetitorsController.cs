using Microsoft.AspNetCore.Mvc;
using W12_Survivor.Data;
using W12_Survivor.Models;

namespace W12_Survivor.Controllers;

[ApiController]
[Route("[controller]")]
public class CompetitorsController : Controller
{
    private readonly SurvivorContext _context;
    
    public CompetitorsController(SurvivorContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Competitors);
    }
    
    [HttpGet("{id:int:min(1)}")]
    public IActionResult GetById(int id)
    {
        var competitor = _context.Competitors.Find(id);
        if (competitor is null)
            return NotFound();
        return Ok(competitor);
    }
    
    [HttpGet("Categories/{categoryId:int:min(1)}")]
    public ActionResult<IEnumerable<Competitor>> GetByCategoryId(int categoryId)
    {
        var category = _context.Categories.Find(categoryId);
        if (category is null)
            return NotFound();
        
        var competitors = _context.Competitors.Where(c => c.CategoryId == categoryId)
                                                            .Select(c => new Competitor
                                                            {
                                                                Id = c.Id, 
                                                                FirstName = c.FirstName, 
                                                                LastName = c.LastName,
                                                                CategoryId = c.CategoryId,
                                                                CreatedDate = c.CreatedDate,
                                                                ModifiedDate = c.ModifiedDate,
                                                                IsDeleted = c.IsDeleted
                                                            }).ToList();
        return Ok(competitors);
    }

    [HttpPost]
    public IActionResult Create(Competitor competitor)
    {
        _context.Competitors.Add(competitor);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = competitor.Id }, competitor);
    }
    
    [HttpPut("{id:int:min(1)}")]
    public IActionResult Update(int id, Competitor competitor)
    {
        if (id != competitor.Id)
            return BadRequest();
        
        var existing = _context.Competitors.Find(id);
        if (existing is null)
            return NotFound();
        
        existing.FirstName = competitor.FirstName;
        existing.LastName = competitor.LastName;
        existing.CategoryId = competitor.CategoryId;
        existing.ModifiedDate = DateTime.Now;
        
        _context.SaveChanges();
        return NoContent();
    }
    
    [HttpDelete("{id:int:min(1)}")]
    public IActionResult Delete(int id)
    {
        var competitor = _context.Competitors.Find(id);
        if (competitor is null)
            return NotFound();
        
        _context.Competitors.Remove(competitor);
        _context.SaveChanges();
        return NoContent();
    }
}