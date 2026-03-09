using System;
using CORE.Entities;
using INFRASTRUCTURE.Datas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
  private readonly StoreContext _context;
  public ProductsController(StoreContext context)
  {
    _context = context;
  }
  //Dependency Injection


  [HttpGet]
    public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
    {
        return await _context.Product.ToListAsync();
    }
    //Getting The Rows From The Database


    [HttpGet("{id:int}")]
    public async Task<ActionResult<Products>> GetProducts(int id)
    {
        var get_items = await _context.Product.FindAsync(id);

        if(get_items == null)
        {
            return NotFound();
        }

        return get_items;
    }
    //Getting The Particular Product From The Database By Id


    [HttpPost]
    public async Task<ActionResult<Products>> CreateProducts(Products p)
    {
        _context.Product.Add(p);
        await _context.SaveChangesAsync();
        return p;
    }
    //Data To The DB  From The Client


    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Products>> DeleteProducts(int id)
    {
        var delete_items = await _context.Product.FindAsync(id);
        if(delete_items == null)
        {
            return NotFound();
        }
        _context.Product.Remove(delete_items);
        await _context.SaveChangesAsync();
        return NoContent();
    }//Delete Using Id


    [HttpPut("{id:int}")]
    public async Task<ActionResult<Products>> UpdateProducts(int id,Products p)
    {
        if(id != p.Id)
        {
            return BadRequest();
        }
        _context.Entry(p).State = EntityState.Modified; 
        await _context.SaveChangesAsync();
        return Ok(p);
    }//After Getting The Paticular Data By The Id Then We Update It
}
