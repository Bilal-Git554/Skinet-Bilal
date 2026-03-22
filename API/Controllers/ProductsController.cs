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
  private readonly IProductRepository _repo;
  public ProductsController(IProductRepository repo)
  {
    _repo = repo;
  }
  //Dependency Injection


  [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Products>>> GetProducts()
    {
        return Ok(await _repo.GetProductsAsync());
    }
    //Getting The Rows From The ProductRepository And Displaying It To The Client


    [HttpGet("{id:int}")]
    public async Task<ActionResult<Products>> GetProduct(int id)
    {
        var get_items = await _repo.GetProductByIdAsync(id);

        if(get_items == null)
        {
            return NotFound();
        }

        return get_items;
    }
    //Getting The Particular Product From The ProductRepository Using Id And Displaying It To The Client


    [HttpPost]
    public async Task<ActionResult<Products>> CreateProducts(Products p)
    {
        _repo.AddProduct(p);

        if(await _repo.SaveAllChangesAsync())
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
        var delete_items = await _repo.GetProductByIdAsync(id);

        if(delete_items == null)
        {
            return NotFound();
        }

        _repo.DeleteProduct(delete_items);

        if(await _repo.SaveAllChangesAsync())
        {
            return NoContent();
        }

        return BadRequest("Failed To Delete Product");
    }//Delete Using Id


    [HttpPut("{id:int}")]
    public async Task<ActionResult<Products>> UpdateProducts(int id,Products p)
    {
        if(!_repo.ProductExists(id))
        {
            return BadRequest("Product Not Found");
        }
 
         p.Id = id;    

         _repo.UpdateProduct(p);

         if(await _repo.SaveAllChangesAsync())
         {
            return NoContent();
         }

         return BadRequest("Failed To Update Product");
    }//After Getting The Paticular Data By The Id Then We Update It Through The ProductRepository 
    // And Display The Updated Data To The Client
}
