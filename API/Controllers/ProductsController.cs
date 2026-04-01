using System;
using CORE.Entities;
using CORE.Interface;
using INFRASTRUCTURE.Datas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
  private readonly IGenericRepository<Products> _repo;
  public ProductsController(IGenericRepository<Products> repo)
  {
    _repo = repo;
  }
  //Dependency Injection


  [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Products>>> GetProducts(string? brand , string? type,
     string? sort)
    {
        return Ok(await _repo.ListAllAsync());
    }
    //Getting The Rows From The ProductRepository And Displaying It To The Client


    [HttpGet("{id:int}")]
    public async Task<ActionResult<Products>> GetProduct(int id)
    {
        var get_items = await _repo.GetByIdAsync(id);

        if(get_items == null)
        {
            return NotFound();
        }

        return get_items;
    }
    //Getting The Particular Product From The ProductRepository Using Id And Displaying It To The Client

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
    {
        return Ok("Brand Controller Is Working");
    }//Getting The Brands From The ProductRepository And Displaying It To The Client


    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
    {
        return Ok("Types Controller Is Working");
    }//Getting The Types From The ProductRepository And Displaying It To The Client

    [HttpPost]
    public async Task<ActionResult<Products>> CreateProducts(Products p)
    {
        _repo.Add(p);

        if(await _repo.SaveAllAsync())
        {
            return CreatedAtAction("GetProduct", new { id = p.Id }, p);
        }

        return BadRequest("Failed To Create Product");
    }
    //Data To The DB  From The Client Through The ProductRepository And Passing The Created Data And The Id To The 
    //GetProduct Action To Display The Created Data To The Client


    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Products>> DeleteProducts(int id)
    {
        var delete_items = await _repo.GetByIdAsync(id);

        if(delete_items == null)
        {
            return NotFound();
        }

        _repo.Remove(delete_items);

        if(await _repo.SaveAllAsync())
        {
            return NoContent();
        }

        return BadRequest("Failed To Delete Product");
    }//Delete Using Id


    [HttpPut("{id:int}")]
    public async Task<ActionResult<Products>> UpdateProducts(int id,Products p)
    {
        if(!_repo.Exists(id))
        {
            return BadRequest("Product Not Found");
        }
 
         p.Id = id;    

         _repo.Update(p);

         if(await _repo.SaveAllAsync())
         {
            return NoContent();
         }

         return BadRequest("Failed To Update Product");
    }//After Checking The Paticular Data By The Id Then We Update It Through The ProductRepository 
    // And Display The Updated Data To The Client
}
