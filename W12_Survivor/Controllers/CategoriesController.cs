using Microsoft.AspNetCore.Mvc;
using W12_Survivor.Data;
using W12_Survivor.Models;

namespace W12_Survivor.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : Controller
{
    private readonly SurvivorContext _context;
    
    public CategoriesController(SurvivorContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Categories);
    }
    
    [HttpGet("{id:int:min(1)}")]
    public IActionResult GetById(int id)
    {
        var category = _context.Categories.Find(id);
        if (category is null)
            return NotFound();
        return Ok(category);
    }
    
    [HttpPost]
    public IActionResult Create(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }
    
    [HttpPut("{id:int:min(1)}")]
    public IActionResult Update(int id, Category category)
    {
        if (id != category.Id)
            return BadRequest();
        
        var existing = _context.Categories.Find(id);
        if (existing is null)
            return NotFound();
        
        existing.Name = category.Name;
        existing.ModifiedDate = DateTime.Now;
        
        _context.SaveChanges();
        return NoContent();
    }
    
    [HttpDelete("{id:int:min(1)}")]
    public IActionResult Delete(int id)
    {
        var category = _context.Categories.Find(id);
        if (category is null)
            return NotFound();
        
        _context.Categories.Remove(category);
        _context.SaveChanges();
        return NoContent();
    }
}