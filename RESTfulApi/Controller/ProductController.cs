using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTfulApi.Data;
using RESTfulApi.Models;

namespace RESTfulApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController :ControllerBase
    {
       private readonly AppDBContext _dbContext;
        
        public ProductController(AppDBContext context)
        {
           _dbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _dbContext.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product==null)
            {
                return NotFound("Ürün Bulunamadı");
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Add (Products product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update (int id, Products products)
        {
            if (id!= products.Id)
            {
                return BadRequest("ID'ler uyuşmuyor.");
            }

            _dbContext.Entry(products).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete (int id)
        {
            var products = await _dbContext.Products.FindAsync(id);
            if(products==null) 
            {
            return NotFound("Silenecek ürün bulunamadı.");
            }

            _dbContext.Remove(products);
            await _dbContext.SaveChangesAsync();
            return NoContent() ;
        }

    }
}
