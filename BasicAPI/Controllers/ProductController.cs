using BasicAPI.Data;
using BasicAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ProductController (ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpGet("urunler")]
        public async Task<ActionResult<IEnumerable<Product>>>GetProduct()
        {

            return await _context.Product.ToListAsync();
        }

        [HttpGet("urunler/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {

            var product=await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound(new {Message=$"aradığınız ürüne ulaşamadım"});
            }
            
            
            return Ok(new { Success = true, Message = $"Ürün Bulundu", Data = product });
        }


        [HttpPost("urunler")]
        public async Task<ActionResult> PostProduct(Product product)
        {

            _context.Product.Add(product);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetProduct",new {id=product},new { Success = true, Message = "Ürün Eklendi",Data=product });
        }
    }
}
